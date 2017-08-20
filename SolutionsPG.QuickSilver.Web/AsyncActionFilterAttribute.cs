using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SolutionsPG.QuickSilver.Core.Async;

namespace SolutionsPG.QuickSilver.Web
{
    public abstract class AsyncActionFilterAttribute : ActionFilterAttribute
    {
        public sealed override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CallAwaitSync(this.OnActionExecutingAsync, filterContext);
        }

        public sealed override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            CallAwaitSync(this.OnActionExecutedAsync, filterContext);
        }

        public sealed override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            CallAwaitSync(this.OnResultExecutingAsync, filterContext);
        }

        public sealed override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            CallAwaitSync(this.OnResultExecutedAsync, filterContext);
        }

        public virtual Task OnActionExecutingAsync(ActionExecutingContext filterContext)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnActionExecutedAsync(ActionExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnResultExecutingAsync(ResultExecutingContext filterContext)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnResultExecutedAsync(ResultExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        private static void CallAwaitSync<TContext>(Func<TContext, Task> action, TContext filterContext) where TContext : ControllerContext
        {
            var httpContext = HttpContext.Current;

            Task Action() => action(filterContext);
            void ConfigureThreadStatic() => HttpContext.Current = httpContext;

            AsyncEx.AwaitSync(Action, ConfigureThreadStatic);

        }
    }
}
