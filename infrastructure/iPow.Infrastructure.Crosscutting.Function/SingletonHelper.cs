using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SingletonHelper<T> where T : class,new()
    {
        // 类型T的唯一实例
        /// <summary>
        /// 
        /// </summary>
        private static T instance;

        // 用于lock块的对象
        /// <summary>
        /// 
        /// </summary>
        private static readonly object sync = new object();

        // 私有的默认构造
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonHelper&lt;T&gt;"/> class.
        /// </summary>
        private SingletonHelper() { }

        /// <summary>
        /// 获取类型T的唯一实例
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}

