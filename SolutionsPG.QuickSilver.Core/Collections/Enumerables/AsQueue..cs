using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    /// <summary>
    /// This is a specialized type of <see cref="IEnumerable{T}"/> meant to be used as a queue. Once an item is read, it
    /// is poped from it. It enables scenario like doing something special with the first element, then do something
    /// else with the rest without including a condition in the loop that will never be met again or having to skip the
    /// element.
    /// </summary>
    /// <typeparam name="T">Type of the elements returned</typeparam>
    public interface IQueuedEnumerable<out T> : IEnumerable<T>
    {
        //bool Any(); //To prevent to lose the first item for this common scenario. Maybe just popit with the IEnumarator.Current... something like that
        //bool Any(Func<T, bool> predicate);
        IQueuedEnumerable<T> Reset();
    }

    /// <summary>
    /// With AsQueue, the user can compose its enumerable in new ways since computed element won't be computed again. 
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region | Public methods |

        /// <summary>
        /// Allow the user to compose its enumerable in new ways since computed element won't be computed again.
        /// It creates a specialized type of <see cref="IEnumerable{T}"/> meant to be used as a queue. Once an item is
        /// read, it is poped from it. It enables scenario like doing something special with the first element, then do
        /// something else with the rest without including a condition in the loop that will never be met again or
        /// having to skip the element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueuedEnumerable<T> AsQueue<T>(this IEnumerable<T> enumerable)
        {
            return new QueueIterator<T>(enumerable.ThrowIfArgumentNull(nameof(enumerable)));
        }

        #endregion //Public methods

        #region | Private types |

        /// <summary>
        /// Implementation of <see cref="IQueuedEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">Type of the elements returned</typeparam>
        private class QueueIterator<T> : IQueuedEnumerable<T>
        {
            #region " Const "

            private enum State
            {
                NotStarted = 0,
                Resetted,
                InProgress,
                Completed
            }
            private static readonly IEnumerable<T> Empty = Enumerable.Empty<T>();

            #endregion //Const

            #region " Variables "

            private readonly IEnumerable<T> _source;

            private IEnumerator<T> _sourceEnumerator;
            private IEnumerable<T> _iterator;
            private State _state = State.NotStarted;
            private int _position = -1;

            #endregion //Variables

            #region " Constructors "

            public QueueIterator(IEnumerable<T> source)
            {
                this._source = source;
            }

            #endregion //Constructors

            #region " Public methods "

            public int Position => _position;

            public IEnumerator<T> GetEnumerator()
            {
                IEnumerator<T> enumerator = null;

                switch (_state)
                {
                    case State.NotStarted:
                        _iterator = this.Iterator();
                        goto case State.InProgress;

                    case State.Resetted:
                        goto case State.InProgress;

                    case State.InProgress:
                        return _iterator.GetEnumerator();

                    case State.Completed:
                        return Empty.GetEnumerator();

                        //default:
                        //    break;
                }

                return enumerator;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public IQueuedEnumerable<T> Reset()
            {
                if (_state != State.NotStarted)
                {
                    _state = State.Resetted;
                    _sourceEnumerator?.Dispose();
                    _sourceEnumerator = null;
                    _position = -1;
                }

                return this;
            }

            #endregion //Public methods

            #region " Private methods "

            private IEnumerable<T> Iterator()
            {
                switch (_state)
                {
                    case State.NotStarted:
                    case State.Resetted:
                        _sourceEnumerator = _source.GetEnumerator();
                        _state = State.InProgress;
                        goto case State.InProgress;

                    case State.InProgress:
                        while (_sourceEnumerator.MoveNext())
                        {
                            ++_position;
                            yield return _sourceEnumerator.Current;
                        }
                        _state = State.Completed;
                        _sourceEnumerator.Dispose();
                        _sourceEnumerator = null;
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

        #endregion //Private types
    }
}
