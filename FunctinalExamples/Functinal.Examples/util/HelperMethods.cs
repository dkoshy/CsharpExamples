using System.ComponentModel;

namespace Functinal.Examples.util
{
    public static class HelperMethods
    {
        public static TResult Using<TDisposable,TResult>(
            Func<TDisposable> factory,
            Func<TDisposable,TResult> map) where TDisposable : IDisposable
        {
            using var tDisposable = factory();
            return map(tDisposable);
        }
    }
}
