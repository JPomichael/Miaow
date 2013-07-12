using System;
using System.IO;
using System.Xml;
using System.Net;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 文件操作工具集
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class FileDirectoryHelper
    {
        /// <summary>
        /// 路径分割符
        /// </summary>
        private const string PATH_SPLIT_CHAR = "\\";
        /// <summary>
        /// 构造函数
        /// </summary>
        private FileDirectoryHelper()
        {
        }

        #region 复制指定目录的所有文件,不包含子目录及子目录中的文件
        /// <summary>
        /// 复制指定目录的所有文件,不包含子目录及子目录中的文件
        /// </summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,表示覆盖同名文件,否则不覆盖</param>
        public static void CopyFiles(string sourceDir, string targetDir, bool overWrite)
        {
            CopyFiles(sourceDir, targetDir, overWrite, false);
        }
        #endregion

        #region 复制指定目录的所有文件
        /// <summary>
        /// 复制指定目录的所有文件
        /// </summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,覆盖同名文件,否则不覆盖</param>
        /// <param name="copySubDir">如果为true,包含目录,否则不包含</param>
        public static void CopyFiles(string sourceDir, string targetDir, bool overWrite, bool copySubDir)
        {
            //复制当前目录文件
            foreach (string sourceFileName in Directory.GetFiles(sourceDir))
            {
                string targetFileName = Path.Combine(targetDir, sourceFileName.Substring(sourceFileName.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                if (File.Exists(targetFileName))
                {
                    if (overWrite == true)
                    {
                        File.SetAttributes(targetFileName, FileAttributes.Normal);
                        File.Copy(sourceFileName, targetFileName, overWrite);
                    }
                }
                else
                {
                    File.Copy(sourceFileName, targetFileName, overWrite);
                }
            }
            //复制子目录
            if (copySubDir)
            {
                foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
                {
                    string targetSubDir = Path.Combine(targetDir, sourceSubDir.Substring(sourceSubDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                    if (!Directory.Exists(targetSubDir))
                        Directory.CreateDirectory(targetSubDir);
                    CopyFiles(sourceSubDir, targetSubDir, overWrite, true);
                }
            }
        }
        #endregion

        #region 剪切指定目录的所有文件,不包含子目录
        /// <summary>
        /// 剪切指定目录的所有文件,不包含子目录
        /// </summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,覆盖同名文件,否则不覆盖</param>
        public static void MoveFiles(string sourceDir, string targetDir, bool overWrite)
        {
            MoveFiles(sourceDir, targetDir, overWrite, false);
        }
        #endregion

        #region 剪切指定目录的所有文件
        /// <summary>
        /// 剪切指定目录的所有文件
        /// </summary>
        /// <param name="sourceDir">原始目录</param>
        /// <param name="targetDir">目标目录</param>
        /// <param name="overWrite">如果为true,覆盖同名文件,否则不覆盖</param>
        /// <param name="moveSubDir">如果为true,包含目录,否则不包含</param>
        public static void MoveFiles(string sourceDir, string targetDir, bool overWrite, bool moveSubDir)
        {
            //移动当前目录文件
            foreach (string sourceFileName in Directory.GetFiles(sourceDir))
            {
                string targetFileName = Path.Combine(targetDir, sourceFileName.Substring(sourceFileName.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                if (File.Exists(targetFileName))
                {
                    if (overWrite == true)
                    {
                        File.SetAttributes(targetFileName, FileAttributes.Normal);
                        File.Delete(targetFileName);
                        File.Move(sourceFileName, targetFileName);
                    }
                }
                else
                {
                    File.Move(sourceFileName, targetFileName);
                }
            }
            if (moveSubDir)
            {
                foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
                {
                    string targetSubDir = Path.Combine(targetDir, sourceSubDir.Substring(sourceSubDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                    if (!Directory.Exists(targetSubDir))
                        Directory.CreateDirectory(targetSubDir);
                    MoveFiles(sourceSubDir, targetSubDir, overWrite, true);
                    Directory.Delete(sourceSubDir);
                }
            }
        }
        #endregion

        #region 删除指定目录的所有文件，不包含子目录
        /// <summary>
        /// 删除指定目录的所有文件，不包含子目录
        /// </summary>
        /// <param name="targetDir">操作目录</param>
        public static void DeleteFiles(string targetDir)
        {
            DeleteFiles(targetDir, false);
        }
        #endregion

        #region 删除指定目录的所有文件和子目录
        /// <summary>
        /// 删除指定目录的所有文件和子目录
        /// </summary>
        /// <param name="targetDir">操作目录</param>
        /// <param name="delSubDir">如果为true,包含对子目录的操作</param>
        public static void DeleteFiles(string targetDir, bool delSubDir)
        {
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
                File.Delete(fileName);
            }
            if (delSubDir)
            {
                DirectoryInfo dir = new DirectoryInfo(targetDir);
                foreach (DirectoryInfo subDi in dir.GetDirectories())
                {
                    DeleteFiles(subDi.FullName, true);
                    subDi.Delete();
                }
            }
        }
        #endregion

        #region 创建指定目录
        /// <summary>
        /// 创建指定目录
        /// </summary>
        /// <param name="targetDir"></param>
        public static void CreateDirectory(string targetDir)
        {
            DirectoryInfo dir = new DirectoryInfo(targetDir);
            if (!dir.Exists)
                dir.Create();
        }
        #endregion

        #region 建立子目录
        /// <summary>
        /// 建立子目录
        /// </summary>
        /// <param name="targetDir">目录路径</param>
        /// <param name="subDirName">子目录名称</param>
        public static void CreateDirectory(string parentDir, string subDirName)
        {
            CreateDirectory(parentDir + PATH_SPLIT_CHAR + subDirName);
        }
        #endregion

        #region 删除指定目录
        /// <summary>
        /// 删除指定目录
        /// </summary>
        /// <param name="targetDir">目录路径</param>
        public static void DeleteDirectory(string targetDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(targetDir);
            if (dirInfo.Exists)
            {
                DeleteFiles(targetDir, true);
                dirInfo.Delete(true);
            }
        }
        #endregion

        #region 删除指定目录的所有子目录,不包括对当前目录文件的删除
        /// <summary>
        /// 删除指定目录的所有子目录,不包括对当前目录文件的删除
        /// </summary>
        /// <param name="targetDir">目录路径</param>
        public static void DeleteSubDirectory(string targetDir)
        {
            foreach (string subDir in Directory.GetDirectories(targetDir))
            {
                DeleteDirectory(subDir);
            }
        }
        #endregion

        #region 将指定目录下的子目录和文件生成xml文档
        /// <summary>
        /// 将指定目录下的子目录和文件生成xml文档
        /// </summary>
        /// <param name="targetDir">根目录</param>
        /// <returns>返回XmlDocument对象</returns>
        public static XmlDocument CreateXml(string targetDir)
        {
            XmlDocument myDocument = new XmlDocument();
            XmlDeclaration declaration = myDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            myDocument.AppendChild(declaration);
            XmlElement rootElement = myDocument.CreateElement(targetDir.Substring(targetDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
            myDocument.AppendChild(rootElement);
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("File");
                childElement.InnerText = fileName.Substring(fileName.LastIndexOf(PATH_SPLIT_CHAR) + 1);
                rootElement.AppendChild(childElement);
            }
            foreach (string directory in Directory.GetDirectories(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("Directory");
                childElement.SetAttribute("Name", directory.Substring(directory.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                rootElement.AppendChild(childElement);
                CreateBranch(directory, childElement, myDocument);
            }
            return myDocument;
        }
        #endregion

        #region 创建指定路径中的所有目录
        /// <summary> 
        /// 创建指定路径中的所有目录 
        /// </summary> 
        /// <param name="FolderPath">要创建的路径</param> 
        public static void CreateFolder(string FolderPathName)
        {
            if (FolderPathName.Trim().Length > 0)
            {
                try
                {
                    string CreatePath = System.Web.HttpContext.Current.Server.MapPath(FolderPathName).ToString();
                    if (!Directory.Exists(CreatePath))
                    {
                        Directory.CreateDirectory(CreatePath);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion

        #region 创建文件
        /// <summary> 
        /// 创建文件 
        /// </summary> 
        /// <param name="FilePathName"></param> 
        public static void CreateFile(string FilePathName)
        {
            try
            {
                //创建文件夹 
                string[] strPath = FilePathName.Split('/');

                //string sHtmlPath = ConfigurationManager.AppSettings["HtmlPath"];
                //FilePathName = sHtmlPath + FilePathName;

                CreateFolder(FilePathName.Replace("/" + strPath[strPath.Length - 1].ToString(), "")); //创建指定路径中的所有目录 

                FileInfo CreateFile = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(FilePathName).ToString());//创建文件 
                if (!CreateFile.Exists)
                {
                    FileStream FS = CreateFile.Create();
                    FS.Close();
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 删除一个文件夹下面的字文件夹和文件
        /// <summary> 
        /// 删除一个文件夹下面的字文件夹和文件 
        /// </summary> 
        /// <param name="FolderPathName"></param> 
        public static void DeleteChildFolder(string FolderPathName)
        {
            if (FolderPathName.Trim().Length > 0)
            {
                try
                {
                    string CreatePath = System.Web.HttpContext.Current.Server.MapPath

                        (FolderPathName).ToString();
                    if (Directory.Exists(CreatePath))
                    {
                        Directory.Delete(CreatePath, true);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion

        #region 删除一个文件
        /// <summary> 
        /// 删除一个文件 
        /// </summary> 
        /// <param name="FilePathName"></param> 
        public static void DeleteFile(string FilePathName)
        {
            try
            {
                FileInfo DeleFile = new FileInfo(System.Web.HttpContext.Current.Server.MapPath

                    (FilePathName).ToString());
                DeleFile.Delete();
            }
            catch
            {
            }
        }
        #endregion

        #region 删除整个文件夹及其字文件夹和文件
        /// <summary> 
        /// 删除整个文件夹及其字文件夹和文件 
        /// </summary> 
        /// <param name="FolderPathName"></param> 
        public static void DeleParentFolder(string FolderPathName)
        {
            try
            {
                DirectoryInfo DelFolder = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(FolderPathName).ToString());
                if (DelFolder.Exists)
                {
                    DelFolder.Delete();
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 在文件里追加内容
        /// <summary> 
        /// 在文件里追加内容 
        /// </summary> 
        /// <param name="FilePathName"></param> 
        public static void ReWriteReadinnerText(string FilePathName, string WriteWord)
        {
            try
            {
                //建立文件夹和文件 
                //CreateFolder(FilePathName); 
                CreateFile(FilePathName);
                //得到原来文件的内容 
                FileStream FileRead = new FileStream(System.Web.HttpContext.Current.Server.MapPath

                    (FilePathName).ToString(), FileMode.Open, FileAccess.ReadWrite);
                StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default);
                string OldString = FileReadWord.ReadToEnd().ToString();
                OldString = OldString + WriteWord;
                //把新的内容重新写入 
                StreamWriter FileWrite = new StreamWriter(FileRead, System.Text.Encoding.Default);
                FileWrite.Write(WriteWord);
                //关闭 
                FileWrite.Close();
                FileReadWord.Close();
                FileRead.Close();
            }
            catch
            {
                //    throw; 
            }
        }
        #endregion

        #region 在文件里追加内容
        /// <summary> 
        /// 在文件里追加内容 
        /// </summary> 
        /// <param name="FilePathName"></param> 
        public static string ReaderFileData(string FilePathName)
        {
            try
            {

                FileStream FileRead = new FileStream(System.Web.HttpContext.Current.Server.MapPath(FilePathName).ToString(), FileMode.Open, FileAccess.Read);
                StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default);
                string TxtString = FileReadWord.ReadToEnd().ToString();
                //关闭 
                FileReadWord.Close();
                FileRead.Close();
                return TxtString;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 读取文件夹的文件
        /// <summary> 
        /// 读取文件夹的文件 
        /// </summary> 
        /// <param name="FilePathName"></param> 
        /// <returns></returns> 
        public static DirectoryInfo checkValidSessionPath(string FilePathName)
        {
            try
            {
                DirectoryInfo MainDir = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(FilePathName));
                return MainDir;

            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 生成Xml分支
        /// <summary>
        /// 生成Xml分支
        /// </summary>
        /// <param name="targetDir">子目录</param>
        /// <param name="xmlNode">父目录XmlDocument</param>
        /// <param name="myDocument">XmlDocument对象</param>
        private static void CreateBranch(string targetDir, XmlElement xmlNode, XmlDocument myDocument)
        {
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("File");
                childElement.InnerText = fileName.Substring(fileName.LastIndexOf(PATH_SPLIT_CHAR) + 1);
                xmlNode.AppendChild(childElement);
            }
            foreach (string directory in Directory.GetDirectories(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("Directory");
                childElement.SetAttribute("Name", directory.Substring(directory.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                xmlNode.AppendChild(childElement);
                CreateBranch(directory, childElement, myDocument);
            }
        }
        #endregion

        /// <summary>
        /// 从图片地址下载图片到本地磁盘
        /// </summary>
        /// <param name="ToLocalPath">图片本地磁盘地址</param>
        /// <param name="Url">图片网址</param>
        /// <returns></returns>
        public static bool SavePhotoFromUrl(string FileName, string Url)
        {
            bool Value = false;
            WebResponse response = null;
            Stream stream = null;
            FileName = System.Web.HttpContext.Current.Server.MapPath(FileName);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    Value = SaveBinaryFile(response, FileName);

                }

            }
            catch (Exception err)
            {
                string aa = err.ToString();
            }
            return Value;
        }

        /// <summary>
        /// Save a binary file to disk.
        /// </summary>
        /// <param name="response">The response used to save the file</param>
        // 将二进制文件保存到磁盘
        private static bool SaveBinaryFile(WebResponse response, string FileName)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                Value = false;
            }
            return Value;
        }


    }
}
