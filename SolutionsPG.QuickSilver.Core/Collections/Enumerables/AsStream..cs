using System.Collections.Generic;

using SolutionsPG.QuickSilver.Core.Delegates;
using SolutionsPG.QuickSilver.Core.Exceptions;
using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace SolutionsPG.QuickSilver.Core.Collections
{
    public interface IStreamed<T> : IEnumerable<T>
    {
        IStreamed<T> Reset();
    }

    public static partial class EnumerableExtensions
    {
        #region " Public methods "

        public static IStreamed<T> AsStream<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfArgumentNull(nameof(enumerable));

            return new StreamIterator<T>(enumerable);
        }

        #endregion //Public methods

        #region " Private methods "

        #endregion //Private methods

        private class StreamIterator<T> : IStreamed<T>
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

            public StreamIterator(IEnumerable<T> source)
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

            public IStreamed<T> Reset()
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
    }
}
