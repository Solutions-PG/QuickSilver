using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IComposable<TResource> Using<TResource>(Func<TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TResource>(getResource, null);
        }

        public static IComposable<TResource> Using<TResource>(this IComposable obj, Func<TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TResource>(getResource, obj);
        }

        public static IComposable<TResource> Using<TSource, TResource>(this IComposable<TSource> obj, Func<TSource, TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TSource, TResource>(getResource, obj);
        }

        #endregion //Public methods

        #region | Private methods |

        private class UsingHelper<TResource> : IUsing<TResource> where TResource : IDisposable
        {
            private readonly Func<TResource> _getResource;
            private readonly IComposable _source;

            public UsingHelper(Func<TResource> getResource, IComposable source)
            {
                _getResource = getResource;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction()
                {
                    using (_getResource())
                    {
                        return action();
                    }
                }

                return this._source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TResource, TDoResult> action)
            {
                TDoResult DoAction()
                {
                    using (var r = _getResource())
                    {
                        return action(r);
                    }
                }

                return _source.Execute(DoAction);
            }
        }

        private class UsingHelper<TSource, TResource> : IUsing<TResource> where TResource : IDisposable
        {
            private readonly Func<TSource, TResource> _getResource;
            private readonly IComposable<TSource> _source;

            public UsingHelper(Func<TSource, TResource> getResource, IComposable<TSource> source)
            {
                _getResource = getResource;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    using (_getResource(source))
                    {
                        return action();
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    using (var r = _getResource(source))
                    {
                        return action(r);
                    }
                }

                return _source.Execute(DoAction);
            }
        }

        #endregion //Private methods
    }
}
