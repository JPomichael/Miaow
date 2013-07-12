using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// 照片数据
    /// </summary>
    public class Picture : QzoneBase
    {
        /// <summary>
        /// 相册ID
        /// </summary>
        public string Albumid
        { get; set; }

        /// <summary>
        /// 大图ID 
        /// </summary>
        public string Lloc { get; set; }

        /// <summary>
        ///  小图ID 
        /// </summary>
        public string Sloc { get; set; }

        /// <summary>
        /// 大图地址 
        /// </summary>
        public string Large_url { get; set; }

        /// <summary>
        /// 小图地址 
        /// </summary>
        public string Small_url { get; set; }

        /// <summary>
        /// 图片高（单位：像素）
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 图片宽（单位：像素） 
        /// </summary>
        public int Width { get; set; }


    }
}
