using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    ///  用户的相册
    /// </summary>
    public class UserAlbums : QzoneBase
    {
        /// <summary>
        /// 相册列表
        /// </summary>
        public List<Album> Album { get; set; }
        /// <summary>
        /// 相册总数 
        /// </summary>
        public int Albumnum { get; set; }

    }

    /// <summary>
    /// 相册
    /// </summary>
    public class Album : QzoneBase
    {
        /// <summary>
        ///  相册ID
        /// </summary>
        public string Albumid { get; set; }
        /// <summary>
        /// 相册分类ID 
        /// </summary>
        public int Classid { get; set; }

        /// <summary>
        /// 相册创建时间 
        /// </summary>
        public DateTime Createtime { get; set; }

        /// <summary>
        /// 相册描述 
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 相册名称 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  照片数 
        /// </summary>
        public int Picnum { get; set; }

    }
}
