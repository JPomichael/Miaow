using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// FFMpeg支持轉flv的格式：
    /// asx，asf，mpg，wmv，3gp，mp4，mov，avi
    /// </summary>
    public class FfmpegHelper
    {
        #region 定义变量

        // 存储信息变量
        /// <summary>
        /// 
        /// </summary>
        private Hashtable _variables = new Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// ffmpeg.exe文件所在路径
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get { return (string)_variables["Path"]; }
            set { _variables.Add("Path", value); }
        }

        /// <summary>
        /// 要转换成flv的宽度(默认400)
        /// </summary>
        /// <value>The width of the FLV.</value>
        public int FlvWidth
        {
            get
            {
                if (_variables.ContainsKey("FlvWidth")) return (int)_variables["FlvWidth"];
                else return 160;
            }
            set { _variables.Add("FlvWidth", value); }
        }

        /// <summary>
        /// 要转换成Flv的高度(默认350)
        /// </summary>
        /// <value>The height of the FLV.</value>
        public int FlvHeight
        {
            get
            {
                if (_variables.ContainsKey("FlvHeight")) return (int)_variables["FlvHeight"];
                else return 128;
            }
            set { _variables.Add("FlvHeight", value); }
        }

        /// <summary>
        /// 截图(默认240)
        /// </summary>
        /// <value>The width of the image.</value>
        public int ImageWidth
        {
            get
            {
                if (_variables.ContainsKey("ImageWidth")) return (int)_variables["ImageWidth"];
                else return 160;
            }
            set { _variables.Add("ImageWidth", value); }
        }

        /// <summary>
        /// 截图高度(默认180)
        /// </summary>
        /// <value>The height of the image.</value>
        public int ImageHeight
        {
            get
            {
                if (_variables.ContainsKey("ImageHeight")) return (int)_variables["ImageHeight"];
                else return 128;
            }
            set { _variables.Add("ImageHeight", value); }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="FfmpegHelper"/> class.
        /// </summary>
        /// <param name="path">要生成截图的路径</param>
        public FfmpegHelper(string path)
        {
            Path = path;
        }

        #endregion

        #region 內部方法

        /// <summary>
        /// 转换为Flv文件
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="path">The path.</param>
        private void RunFlv(string fullName, string path)
        {
            //ffmpeg -i F:\01.wmv -ab 56 -ar 22050 -b 500 -r 15 -s 寬x高 f:\test.flv
            if (System.IO.File.Exists(fullName))
            {
                string flvName = System.IO.Path.ChangeExtension(fullName, ".flv");
                if (!String.IsNullOrEmpty(path))
                {
                    string lastChar = path.Substring(path.Length - 1);
                    if (lastChar == @"\" || lastChar == @"/") path = path.Substring(0, path.Length - 1);
                    flvName = path + @"\" + GetFileName(flvName);
                }
                string args = String.Format("-i {0} -ab 56 -ar 22050 -b 500 -r 15 -s {1}x{2} {3}", fullName, this.FlvWidth, this.FlvHeight, flvName);
                RunCmd(args);
            }
        }

        /// <summary>
        /// 生成Jpg文件
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="path">The path.</param>
        private void RunJpg(string fullName, string path)
        {
            //ffmpeg -i F:\01.wmv -y -f image2 -t 0.001 -s  寬x高 f:\test.jpg;
            if (System.IO.File.Exists(fullName))
            {
                string jpgName = System.IO.Path.ChangeExtension(fullName, ".jpg");
                if (!String.IsNullOrEmpty(path))
                {
                    string lastChar = path.Substring(path.Length - 1);
                    if (lastChar == @"\" || lastChar == @"/") path = path.Substring(0, path.Length - 1);
                    jpgName = path + @"\" + GetFileName(jpgName);
                }
                string args = String.Format("-i {0} -y -f image2 -t 0.001 -s {1}x{2} {3}", fullName, this.ImageWidth, this.ImageHeight, jpgName);
                RunCmd(args);
            }
        }

        /// <summary>
        /// 获得文件名
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        private string GetFileName(string fullName)
        {
            fullName = fullName.Replace(@"/", @"\");
            string tempPath = System.IO.Path.GetFileName(fullName);
            return tempPath;
        }

        /// <summary>
        /// 运行Dos命令
        /// </summary>
        private void RunCmd(string args)
        {
            string cmdFile = this.Path;// +@"\ffmpeg.exe";
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo(cmdFile);
            processInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            processInfo.Arguments = args;
            processInfo.UseShellExecute = false;
            System.Diagnostics.Process.Start(processInfo);
        }

        #endregion

        #region 对外方法

        /// <summary>
        /// 转换成Flv文件
        /// </summary>
        /// <param name="fullName">The full name.</param>
        public void ToFlv(string fullName)
        {
            RunFlv(fullName, String.Empty);
        }

        /// <summary>
        /// 转换为Flv文件到指定的目录
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="path">The path.</param>
        public void ToFlv(string fullName, string path)
        {
            RunFlv(fullName, path);
        }

        /// <summary>
        /// 生成截图Jpg文件
        /// </summary>
        /// <param name="fullName">The full name.</param>
        public void ToJpg(string fullName)
        {
            RunJpg(fullName, String.Empty);
        }

        /// <summary>
        /// 生成Jpg文件到指定的目录
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="path">The path.</param>
        public void ToJpg(string fullName, string path)
        {
            RunJpg(fullName, path);
        }

        #endregion

    }

}