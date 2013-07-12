using System;
using System.Data;
using System.IO;
using System.Xml;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 提供对XML文档的操作 , 操作之后,记得手动保存。
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlHelper"/> class.
        /// </summary>
        public XmlHelper()
        { }

        /// <summary>
        /// 若要用这个函数,传入XML文件路径初始化 FilePath这个属性
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public XmlHelper(string filePath)
        {
            try
            {
                doc.Load(filePath);
                this.FilePath = filePath;
            }
            catch (System.Exception ex)
            {
                this.Message = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static XmlDocument doc = new XmlDocument();

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }


        /// <summary>
        /// Instances this instance.
        /// </summary>
        public void Instance()
        {
            if (string.IsNullOrEmpty(this.FilePath) || !File.Exists(this.FilePath))
            {
                this.Message = "please checked file path is null or empty or not found the file";
            }
            else
            {
                try
                {
                    doc.Load(this.FilePath);
                    this.Message = string.Empty;
                }
                catch (System.Exception ex)
                {
                    this.Message = ex.Message.ToString().Trim();
                }
            }
        }

        /// <summary>
        /// Gets the node list.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xmPathNode)
        {
            XmlNodeList nodeList = null;
            try
            {
                nodeList = doc.SelectNodes(xmPathNode);
                this.Message = String.Empty;
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
            }
            return nodeList;
        }

        /// <summary>
        /// Exists the node.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <returns></returns>
        public bool ExistNode(string xmPathNode)
        {
            XmlNode node = null;
            try
            {
                node = doc.SelectSingleNode(xmPathNode);
                this.Message = String.Empty;
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
            }
            if (node == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <returns></returns>
        public DataSet GetDataSet(string xmPathNode)
        {
            DataSet ds = new DataSet();
            try
            {
                StringReader reader = new StringReader(doc.SelectSingleNode(xmPathNode).OuterXml);
                ds.ReadXml(reader);
                reader.Close();
                this.Message = String.Empty;
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
            }
            return ds;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <returns></returns>
        public string GetText(string xmPathNode)
        {
            XmlNode node = null;
            try
            {
                node = doc.SelectSingleNode(xmPathNode);
                if (node != null)
                {
                    this.Message = String.Empty;
                    return node.InnerText;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return string.Empty;
            }
        }

        /// <summary>
        /// Mods the node text.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public bool ModNodeText(string xmPathNode, string content)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode(xmPathNode);
                if (node != null)
                {
                    this.Message = String.Empty;
                    node.InnerText = content;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }

        /// <summary>
        /// Deletes the specified xm path node.
        /// </summary>
        /// <param name="xmPathNode">The xm path node.</param>
        /// <returns></returns>
        public bool Delete(string xmPathNode)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode(xmPathNode);
                if (node != null)
                {
                    node.ParentNode.RemoveChild(node);
                    this.Message = String.Empty;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }


        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="mainNode">The main node.</param>
        /// <returns></returns>
        public bool RemoveAll(string mainNode)
        {
            try
            {
                XmlNode objRootNode = doc.SelectSingleNode(mainNode);
                if (objRootNode != null)
                {
                    objRootNode.RemoveAll();
                    this.Message = String.Empty;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }
        /// <summary>
        /// 插入一节点和此节点的一子节点。
        /// </summary>
        /// <param name="mainNode">根节点</param>
        /// <param name="chlidNode">子节点</param>
        /// <param name="element">元素</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public bool InsertNode(string mainNode, string chlidNode, string element, string content)
        {
            try
            {
                XmlNode objRootNode = doc.SelectSingleNode(mainNode);
                XmlElement objChildNode = doc.CreateElement(chlidNode);
                if (objRootNode != null)
                {
                    objRootNode.AppendChild(objChildNode);
                    XmlElement objElement = doc.CreateElement(element);
                    objElement.InnerText = content;
                    objChildNode.AppendChild(objElement);
                    this.Message = String.Empty;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }

        /// <summary>
        /// 插入一个节点，带一属性。
        /// </summary>
        /// <param name="mainNode">节点名</param>
        /// <param name="element">元素</param>
        /// <param name="attrib">属性</param>
        /// <param name="attribContent">属性内容</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public bool InsertElement(string mainNode, string element, string attrib, string attribContent, string content)
        {
            try
            {
                XmlNode objNode = doc.SelectSingleNode(mainNode);
                XmlElement objElement = doc.CreateElement(element);
                objElement.SetAttribute(attrib, attribContent);
                objElement.InnerText = content;
                if (objNode != null)
                {
                    objNode.AppendChild(objElement);
                    this.Message = String.Empty;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }

        /// <summary>
        /// 插入一个节点，不带属性。
        /// </summary>
        /// <param name="mainNode">节点名</param>
        /// <param name="element">元素</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public bool InsertElement(string mainNode, string element, string content)
        {
            try
            {
                XmlNode objNode = doc.SelectSingleNode(mainNode);
                XmlElement objElement = doc.CreateElement(element);
                objElement.InnerText = content;
                if (objNode != null)
                {
                    objNode.AppendChild(objElement);
                    this.Message = String.Empty;
                    return true;
                }
                else
                {
                    this.Message = "没有找到指定节点";
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }

        /// <summary>
        /// 保存文档。
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                doc.Save(FilePath);
                this.Message = string.Empty;
                return true;
            }
            catch (System.Exception ex)
            {
                this.Message = ex.Message.ToString().Trim();
                return false;
            }
        }
    }
}



