using System;

namespace SolutionsPG.QuickSilver.Core.Composition
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static IUsing<TResource> Using<TResource>(Func<TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TResource>(getResource, null);
        }

        public static IComposable<TResource> Using<TResource>(this IComposable obj, Func<TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TResource>(getResource, obj);
        }

        public static IComposable<TSource, TResource> Using<TSource, TResource>(this IComposable<TSource> obj, Func<TSource, TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TSource, TResource>(getResource, obj);
        }

        public static IComposable<TSource1, TSource2, TResource> Using<TSource1, TSource2, TResource>(this IComposable<TSource1, TSource2> obj, Func<TSource1, TSource2, TResource> getResource) where TResource : IDisposable
        {
            return new UsingHelper<TSource1, TSource2, TResource>(getResource, obj);
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

        private class UsingHelper<TSource, TResource> : IUsing<TSource, TResource> where TResource : IDisposable
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

            public TDoResult Execute<TDoResult>(Func<TSource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    using (_getResource(source))
                    {
                        return action(source);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource, TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource source)
                {
                    using (var r = _getResource(source))
                    {
                        return action(source, r);
                    }
                }

                return _source.Execute(DoAction);
            }
        }

        private class UsingHelper<TSource1, TSource2, TResource> : IUsing<TSource1, TSource2, TResource> where TResource : IDisposable
        {
            private readonly Func<TSource1, TSource2, TResource> _getResource;
            private readonly IComposable<TSource1, TSource2> _source;

            public UsingHelper(Func<TSource1, TSource2, TResource> getResource, IComposable<TSource1, TSource2> source)
            {
                _getResource = getResource;
                _source = source;
            }

            public TDoResult Execute<TDoResult>(Func<TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (_getResource(source1, source2))
                    {
                        return action();
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (var r = _getResource(source1, source2))
                    {
                        return action(r);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (_getResource(source1, source2))
                    {
                        return action(source1);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (_getResource(source1, source2))
                    {
                        return action(source2);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (_getResource(source1, source2))
                    {
                        return action(source1, source2);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (var r = _getResource(source1, source2))
                    {
                        return action(source1, r);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource2, TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (var r = _getResource(source1, source2))
                    {
                        return action(source2, r);
                    }
                }

                return _source.Execute(DoAction);
            }

            public TDoResult Execute<TDoResult>(Func<TSource1, TSource2, TResource, TDoResult> action)
            {
                TDoResult DoAction(TSource1 source1, TSource2 source2)
                {
                    using (var r = _getResource(source1, source2))
                    {
                        return action(source1, source2, r);
                    }
                }

                return _source.Execute(DoAction);
            }
        }

        #endregion //Private methods
    }
}
