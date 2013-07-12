using System;
using System.Xml;

namespace Wbm.TencV2SDK.Helpers
{
    /// <summary>
    /// XML 文件操作助手
    /// </summary>
    public class XmlHelper
    {
        private XmlDocument xmlDoc = null;

        public XmlHelper()
        {
            xmlDoc = new XmlDocument();
        }
        /// <summary>
        /// 加载xml文件
        /// </summary>
        /// <param name="fileName">xml 文件路径</param>

        public void Load(string fileName)
        {
            xmlDoc.Load(fileName);
        }

        /// <summary>
        /// 读取xml内容
        /// </summary>
        /// <param name="xml">xml 内容</param>
        public void LoadXml(string xml)
        {
            xmlDoc.LoadXml(xml);
        }

        /// <summary>
        /// xpath 是否存在
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public bool IsExists(string xpath)
        {
            return xmlDoc.DocumentElement.SelectSingleNode(xpath) != null ? true : false;
        }

        /// <summary>
        /// xpath 是否存在
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public bool IsExists(XmlNode xn, string xpath)
        {
            return xn.SelectSingleNode(xpath) != null ? true : false;
        }
        /// <summary>
        /// 选择指定节点
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public XmlNodeList SelectNodes(string xpath)
        {
            return xmlDoc.DocumentElement.SelectNodes(xpath);
        }

        /// <summary>
        /// 选择指定节点
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public XmlNodeList SelectNodes(XmlNode xn, string xpath)
        {
            return xn.SelectNodes(xpath);
        }

        /// <summary>
        /// 选择单节点
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XmlNode SelectSingleNode(string xpath)
        {
            return xmlDoc.DocumentElement.SelectSingleNode(xpath);
        }

        /// <summary>
        /// 选择单节点
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XmlNode SelectSingleNode(XmlNode xn, string xpath)
        {
            return xn.SelectSingleNode(xpath);
        }

        /// <summary>
        /// 选择单节点本文
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public string SelectSingleNodeText(string xpath)
        {
            return IsExists(xpath) ? xmlDoc.DocumentElement.SelectSingleNode(xpath).InnerText : string.Empty;
        }

        /// <summary>
        /// 选择单节点本文
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public string SelectSingleNodeText(XmlNode xn, string xpath)
        {
            return IsExists(xn, xpath) ? xn.SelectSingleNode(xpath).InnerText : string.Empty;
        }

        /// <summary>
        /// 选择节点所有属性
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public XmlAttributeCollection SelectSingleNodeAttributes(string xpath)
        {
            return IsExists(xpath) ? xmlDoc.DocumentElement.SelectSingleNode(xpath).Attributes : null;
        }

        /// <summary>
        /// 选择节点属性
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        public XmlAttribute SelectSingleNodeAttributes(string xpath, string attrName)
        {
            return SelectSingleNodeAttributes(xpath) != null ? SelectSingleNodeAttributes(xpath)[attrName] : null;
        }

        /// <summary>
        /// 选择节点属性值
        /// </summary>
        /// <param name="xpath">xpath 路径</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        public string SelectSingleNodeAttributesValue(string xpath, string attrName)
        {
            return SelectSingleNodeAttributes(xpath, attrName) != null ? SelectSingleNodeAttributes(xpath, attrName).Value : string.Empty;
        }

        /// <summary>
        /// 选择节点所有属性
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <returns></returns>
        public XmlAttributeCollection SelectSingleNodeAttributes(XmlNode xn, string xpath)
        {
            return IsExists(xn, xpath) ? xn.SelectSingleNode(xpath).Attributes : null;
        }

        /// <summary>
        /// 选择节点属性
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        public XmlAttribute SelectSingleNodeAttributes(XmlNode xn, string xpath, string attrName)
        {
            return SelectSingleNodeAttributes(xn, xpath) != null ? SelectSingleNodeAttributes(xn, xpath)[attrName] : null;
        }

        /// <summary>
        /// 选择节点属性值
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="xpath">xpath 路径</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        public string SelectSingleNodeAttributesValue(XmlNode xn, string xpath, string attrName)
        {
            return SelectSingleNodeAttributes(xn, xpath, attrName) != null ? SelectSingleNodeAttributes(xn, xpath, attrName).Value : string.Empty;
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */