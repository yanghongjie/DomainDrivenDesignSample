using System;

namespace Infrastructure.Utility.Extensions
{
    public static class ParamterCheckExtensions
    {
        /// <summary>
        /// 验证指定值的断言<paramref name="assertion"/>是否为真，如果不为真，抛出指定消息<paramref name="message"/>的指定类型<typeparamref name="TException"/>异常
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="message">异常消息。</param>
        private static void Require<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
            {
                return;
            }
            var exception = (TException)Activator.CreateInstance(typeof(TException), message);
            throw exception;
        }
        /// <summary>
        /// 检查参数不能为空引用，否则抛出<see cref="ArgumentNullException"/>异常。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName">参数名称</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CheckNotNull<T>(this T value, string paramName)
        {
            Require<ArgumentNullException>((object)value != null, string.Format("参数“{0}”不能为空引用。", paramName));
        }
    }
}