using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace azure_m.Views
{
    public static class Helpers
    {
        //public static void jumpHook(Action callback,  Page srcPage)
        //{
        //    callback.Invoke();
        //    srcPage.Navigation.PushAsync(desPage).Wait();
        //}

        /// <summary>
        /// 在跳转之前执行一个异步回调函数。
        /// 如果是同步函数请用task包一下。
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="desPageClass"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static async Task AsyncbeforeJump(INavigation navigation, Type desPageClass, Func<Task> asyncCallback)
        {
            await asyncCallback();
            await navigation.PushAsync(Activator.CreateInstance(desPageClass) as Page);
        }

    }
}
