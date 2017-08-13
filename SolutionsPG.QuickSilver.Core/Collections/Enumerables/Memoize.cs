using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public interface IMemoized<T> : IList<T>, IReadOnlyList<T> { }

    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static IMemoized<T> Memoize<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));
            
            return new MemoizeIterator<T>(enumerable);
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods

        private class MemoizeIterator<T> : IMemoized<T>
        {
            #region " Const "

            private enum State
            {
                NotStarted = 0,
                InProgress,
                Completed
            }

            #endregion //Const

            #region " Variables "

            private readonly IStreamed<T> _streamedSource;
            private readonly List<T> _cache;
            
            private IEnumerable<T> _iterator;
            private State _state;

            #endregion //Variables

            #region " Constructors "

            public MemoizeIterator(IEnumerable<T> source)
            {
                _streamedSource = source.AsStream();
                _cache = new List<T>();
            }

            #endregion //Constructors

            #region " Public methods "

            public T this[int index] { get => GetItem(index); set => throw new NotSupportedException(); }

            public int Count => GetCount();

            bool ICollection<T>.IsReadOnly => true;

            void ICollection<T>.Add(T item) => throw new NotSupportedException();

            void ICollection<T>.Clear() => throw new NotSupportedException();

            bool ICollection<T>.Contains(T item)
            {
                return (((IList<T>)this).IndexOf(item) != -1);
            }

            void ICollection<T>.CopyTo(T[] array, int arrayIndex)
            {
                array.ThrowIfArgumentNull(nameof(array));
                arrayIndex.ThrowIfArgument(arrayIndex < 0, nameof(arrayIndex), $"Invalid index ({arrayIndex}).");
                array.ThrowIfArgument(array.Length - arrayIndex < Count, nameof(array), "Not enough elements after arrayIndex in the destination array.");

                switch (_state)
                {
                    case State.Completed:
                        _cache.CopyTo(array, arrayIndex);
                        break;

                    default:
                        foreach (var currentItem in this) { array[arrayIndex++] = currentItem; }
                        break;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                IEnumerator<T> enumerator = null;

                switch (_state)
                {
                    case State.NotStarted:
                        _iterator = this.Iterator();
                        goto case State.InProgress;

                    case State.InProgress:
                        return _iterator.GetEnumerator();

                    case State.Completed:
                        return _cache.GetEnumerator();

                        //default:
                        //    break;
                }

                return enumerator;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            int IList<T>.IndexOf(T item)
            {
                switch (_state)
                {
                    case State.Completed:
                        return _cache.IndexOf(item);

                    default:
                        return this.GetDefaultIndexOf(item);
                }
            }

            void IList<T>.Insert(int index, T item) => throw new NotSupportedException();

            bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

            void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

            #endregion //Public methods

            #region " Private methods "

            private T GetItem(int index)
            {
                if (index >= 0)
                {
                    if (index < _cache.Count)
                        return _cache[index];
                    if (this.TryGetElementAt(index, out T item))
                        return item;
                }

                throw new IndexOutOfRangeException();
            }

            private int GetCount()
            {
                switch (_state)
                {
                    case State.Completed:
                        return _cache.Count;

                    default:
                        return this.Count();
                }
            }

            private int GetDefaultIndexOf(T item)
            {
                IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
                var itemHashcode = comparer.GetHashCode(item);

                int index = -1;
                foreach (var currentItem in this)
                {
                    ++index;

                    if (comparer.GetHashCode(currentItem) == itemHashcode && comparer.Equals(currentItem, item))
                        break;
                }
                return index;
            }

            private IEnumerable<T> Iterator()
            {
                int count = _cache.Count;
                for (int i = 0; i < count; ++i)
                {
                    yield return _cache[i];
                }

                switch (_state)
                {
                    case State.NotStarted:
                        _state = State.InProgress;
                        goto case State.InProgress;

                    case State.InProgress:
                        foreach(var item in _streamedSource) { yield return item; }
                        _state = State.Completed;
                        //goto case State.Completed;
                        break;

                        //case State.Completed:
                        //    break;

                        //default:
                        //    break;
                }
            }

            #endregion //Private methods
        }
    }
}
