using System;
using System.Collections.Generic;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    ///  表示键和值的集合。
    /// </summary>
    /// <typeparam name="TKey">字典中的键的类型。</typeparam>
    /// <typeparam name="TValue">字典中的值的类型</typeparam>
    [Serializable]
    public class TencMDic<TKey, TValue> : Dictionary<TKey, TValue>
    {

    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */
