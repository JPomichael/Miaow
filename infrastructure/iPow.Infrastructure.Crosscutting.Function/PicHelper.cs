using System;
using System.IO;
using System.Web;
using System.Drawing;

using System.Configuration;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 图片处理工具集
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class PicHelper
    {

        //#region 图片上传
        ///// <summary>
        ///// 图片上传
        ///// </summary>
        ///// <param name="oFile"></param>
        ///// <param name="IsWater">是否需要水印，0为不需要；1为需要</param>
        ///// <param name="IsSmall">是否需要缩略图，0为不需要；1为需要</param>
        ///// <param name="iType">图片类别,0为精彩图片；1为LOGO；2为编辑器上传的图片；3为导游图；4为设备图片；5为访谈人物图片；6为酒店图片</param>
        ///// <returns>上传后的路径</returns>
        //public static string UploadPic(UploadedFile oFile, int IsWater, int IsSmall, int iType)
        //{
        //    try
        //    {
        //        string sFileName = System.IO.Path.GetFileName(oFile.ClientName);
        //        if (sFileName != "")
        //        {
        //            string FileTxt = System.IO.Path.GetExtension(oFile.ClientName);//扩展名
        //            string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//当前时间
        //            Random sran = new Random();//取随机数;
        //            string Rand = sran.Next(1, 9).ToString();

        //            sFileName = nFileName + Rand + FileTxt;//新的文件名（当前时间+１位随机数）
        //            string reFileName = sFileName;//返回图片上传后名称

        //            string sFilePath = "", tFilePath = "", reFilePath1 = ""; ;
        //            switch (iType)
        //            {
        //                case 0:
        //                    sFilePath = ConfigurationManager.AppSettings["PicPath"];
        //                    break;
        //                case 1:
        //                    sFilePath = ConfigurationManager.AppSettings["LogoPath"];
        //                    break;
        //                case 2:
        //                    sFilePath = ConfigurationManager.AppSettings["EditPath"];
        //                    break;
        //                case 3:
        //                    sFilePath = ConfigurationManager.AppSettings["MapPicPath"];
        //                    break;
        //                case 5:
        //                    sFilePath = ConfigurationManager.AppSettings["ActivityPath"];
        //                    break;
        //                default:
        //                    break;
        //            }
        //            //上传时间月份的文件夹(如:2007-1)
        //            reFilePath1 = "http://img.ipow.cn" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
        //            sFilePath = "/Upload" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
        //            //建立目录
        //            FileDirectoryHelper.CreateFolder(sFilePath);
        //            string reFilePath = sFilePath;//返回图片上传后路径

        //            string CutPath = sFilePath + "CutDown/";
        //            FileDirectoryHelper.CreateFolder(CutPath);

        //            //路径
        //            sFilePath = System.Web.HttpContext.Current.Server.MapPath(sFilePath);
        //            CutPath = System.Web.HttpContext.Current.Server.MapPath(CutPath);

        //            string strFilePath = System.IO.Path.Combine(sFilePath, sFileName);

        //            oFile.SaveAs(strFilePath);

        //            if (IsSmall == 1)
        //            {
        //                if (FileTxt.ToLowerInvariant() == ".jpg" || FileTxt.ToLowerInvariant() == ".gif" || FileTxt.ToLowerInvariant() == ".bmp" || FileTxt.ToLowerInvariant() == ".png")
        //                {
        //                    if (iType == 5)
        //                    {
        //                        //生成缩略图118X118
        //                        tFilePath = CutPath + "261_161_" + sFileName;
        //                        MakeImage(strFilePath, tFilePath, 261, 161, "cut");
        //                    }
        //                    else
        //                    {
        //                        //生成缩略图150X150
        //                        tFilePath = CutPath + "160_150_" + sFileName;
        //                        MakeImage(strFilePath, tFilePath, 160, 150, "cut");
        //                        //ToThumbNail(strFilePath, 160, 150, FileTxt, tFilePath);

        //                        //生成缩略图126X99
        //                        tFilePath = CutPath + "126_99_" + sFileName;
        //                        MakeImage(strFilePath, tFilePath, 126, 99, "cut");
        //                        //ToThumbNail(strFilePath, 126, 99, FileTxt, tFilePath);

        //                        //生成缩略图116X103
        //                        tFilePath = CutPath + "116_103_" + sFileName;
        //                        MakeImage(strFilePath, tFilePath, 116, 103, "cut");
        //                        //ToThumbNail(strFilePath, 116, 103, FileTxt, tFilePath);

        //                        //生成缩略图240X210
        //                        tFilePath = CutPath + "240_210_" + sFileName;
        //                        MakeImage(strFilePath, tFilePath, 240, 210, "cut");
        //                    }

        //                    //生成缩略图550
        //                    tFilePath = sFilePath + "ipow_" + sFileName;
        //                    MakeImage(strFilePath, tFilePath, 640, 0, "w");
        //                }
        //            }

        //            if (IsWater == 1)
        //            {
        //                string strw = System.Web.HttpContext.Current.Server.MapPath("~/UpLoad/") + "water.gif";
        //                if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
        //                {
        //                    string wFilePath = sFilePath + "ipow" + sFileName;//水印图
        //                    ToMarkWater(tFilePath, strw, strw, wFilePath, 2);
        //                    //if (System.IO.File.Exists(strFilePath))
        //                    //{
        //                    //    System.IO.File.Delete(strFilePath);
        //                    //}
        //                }
        //            }
        //            return reFilePath1 + "|" + reFileName;

        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //#endregion

        #region 客户端图片上传

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="oFile"></param>
        /// <param name="IsWater">是否需要水印，0为不需要；1为需要</param>
        /// <param name="IsSmall">是否需要缩略图，0为不需要；1为需要</param>
        /// <param name="iType">图片类别,0为精彩图片；1为LOGO；2为编辑器上传的图片；3为导游图；4为设备图片；5为访谈人物图片；6为酒店图片</param>
        /// <returns>上传后的路径</returns>
        public static string ClientUploadPic(HttpPostedFile oFile, int IsWater, int IsSmall, int iType)
        {
            try
            {
                string sFileName = System.IO.Path.GetFileName(oFile.FileName);
                if (sFileName != "")
                {
                    string FileTxt = System.IO.Path.GetExtension(oFile.FileName);//扩展名
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//当前时间
                    Random sran = new Random();//取随机数;
                    string Rand = sran.Next(1, 9).ToString();

                    sFileName = nFileName + Rand + FileTxt;//新的文件名（当前时间+１位随机数）
                    string reFileName = sFileName;//返回图片上传后名称

                    string sFilePath = "", tFilePath = "", reFilePath1 = ""; ;
                    switch (iType)
                    {
                        case 0:
                            sFilePath = ConfigurationManager.AppSettings["PicPath"];
                            break;
                        case 1:
                            sFilePath = ConfigurationManager.AppSettings["LogoPath"];
                            break;
                        case 2:
                            sFilePath = ConfigurationManager.AppSettings["EditPath"];
                            break;
                        case 3:
                            sFilePath = ConfigurationManager.AppSettings["MapPicPath"];
                            break;
                        case 5:
                            sFilePath = ConfigurationManager.AppSettings["ActivityPath"];
                            break;
                        case 6:
                            //edit by yjihrp 2011.4.18.9.37
                            sFilePath = ConfigurationManager.AppSettings["HotelPicPath"];
                            break;
                        default:
                            break;
                    }
                    //上传时间月份的文件夹(如:2007-1)
                    reFilePath1 = "http://img1.ipow.cn" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    sFilePath = "~/Upload" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";

                    //建立目录
                    FileDirectoryHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;//返回图片上传后路径

                    string CutPath = sFilePath + "CutDown/";
                    FileDirectoryHelper.CreateFolder(CutPath);

                    //路径
                    sFilePath = System.Web.HttpContext.Current.Server.MapPath(sFilePath);
                    CutPath = System.Web.HttpContext.Current.Server.MapPath(CutPath);

                    string strFilePath = System.IO.Path.Combine(sFilePath, sFileName);

                    oFile.SaveAs(strFilePath);

                    if (IsSmall == 1)
                    {
                        if (FileTxt.ToLowerInvariant() == ".jpg" || FileTxt.ToLowerInvariant() == ".gif" || FileTxt.ToLowerInvariant() == ".bmp" || FileTxt.ToLowerInvariant() == ".png")
                        {
                            if (iType == 5)
                            {
                                //生成缩略图118X118
                                tFilePath = CutPath + "261_161_" + sFileName;
                                MakeImage(strFilePath, tFilePath, 261, 161, "cut");
                            }
                            else
                            {
                                //生成缩略图150X150
                                tFilePath = CutPath + "160_150_" + sFileName;
                                MakeImage(strFilePath, tFilePath, 160, 150, "cut");
                                //ToThumbNail(strFilePath, 160, 150, FileTxt, tFilePath);

                                //生成缩略图126X99
                                tFilePath = CutPath + "126_99_" + sFileName;
                                MakeImage(strFilePath, tFilePath, 126, 99, "cut");
                                //ToThumbNail(strFilePath, 126, 99, FileTxt, tFilePath);

                                //生成缩略图116X103
                                tFilePath = CutPath + "116_103_" + sFileName;
                                MakeImage(strFilePath, tFilePath, 116, 103, "cut");
                                //ToThumbNail(strFilePath, 116, 103, FileTxt, tFilePath);

                                //生成缩略图240X210
                                tFilePath = CutPath + "240_210_" + sFileName;
                                MakeImage(strFilePath, tFilePath, 240, 210, "cut");
                            }

                            //生成缩略图550
                            tFilePath = sFilePath + "ipow_" + sFileName;
                            MakeImage(strFilePath, tFilePath, 640, 0, "w");
                        }
                    }

                    if (IsWater == 1)
                    {
                        //在这里，得有一个water.gif水印图片哈
                        string strw = System.Web.HttpContext.Current.Server.MapPath("~/UpLoad/") + "water.gif";
                        if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                        {
                            string wFilePath = sFilePath + "ipow" + sFileName;//水印图
                            ToMarkWater(tFilePath, strw, strw, wFilePath, 2);
                            //if (System.IO.File.Exists(strFilePath))
                            //{
                            //    System.IO.File.Delete(strFilePath);
                            //}
                        }
                    }
                    return reFilePath1 + "|" + reFileName;

                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 图片下载
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strPath"></param>
        /// <param name="strTxt"></param>
        /// <returns></returns>
        public static string[] DownPhoto(string strUrl, string strPath, string strTxt)
        {
            try
            {
                if (strUrl != "")
                {
                    string[] aPicInfo = new string[2];
                    strPath = "~/upload" + ConfigurationManager.AppSettings["RemotePath"] + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    string strReFile = "http://img.ipow.cn" + ConfigurationManager.AppSettings["RemotePath"] + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    string sFileName = "", strDownPath = "";
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//当前时间
                    Random sran = new Random();//取随机数;
                    string Rand = sran.Next(1, 9).ToString();

                    sFileName = nFileName + Rand + strTxt;//新的文件名（当前时间+１位随机数）
                    string reFileName = sFileName;//返回图片上传后名称
                    strDownPath = strPath;

                    FileDirectoryHelper.CreateFolder(strPath);
                    FileDirectoryHelper.SavePhotoFromUrl(strPath + sFileName, strUrl);
                    if (strTxt.ToLowerInvariant() == ".jpg" || strTxt.ToLowerInvariant() == ".gif" || strTxt.ToLowerInvariant() == ".bmp" || strTxt.ToLowerInvariant() == ".png")
                    {
                        string CutPath = strPath + "CutDown\\";
                        FileDirectoryHelper.CreateFolder(CutPath);
                        CutPath = System.Web.HttpContext.Current.Server.MapPath(CutPath);
                        string sFilePath = System.Web.HttpContext.Current.Server.MapPath(strPath);
                        string strFilePath = System.IO.Path.Combine(sFilePath, sFileName);
                        //生成缩略图135X125
                        string tFilePath = CutPath + "135_125_" + sFileName;
                        MakeImage(strFilePath, tFilePath, 135, 125, "cut");

                        //生成缩略图125X111
                        tFilePath = CutPath + "125_111_" + sFileName;
                        MakeImage(strFilePath, tFilePath, 125, 111, "cut");

                        //生成缩略图64X50
                        tFilePath = CutPath + "64_50_" + sFileName;
                        MakeImage(strFilePath, tFilePath, 64, 50, "cut");

                        //生成缩略图640
                        tFilePath = sFilePath + "ipow" + sFileName;
                        MakeImage(strFilePath, tFilePath, 640, 0, "w");
                    }
                    string strw = System.Web.HttpContext.Current.Server.MapPath("/UpLoad/") + "water.gif";
                    if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                    {
                        string sFilePath = System.Web.HttpContext.Current.Server.MapPath(strPath);
                        string strFilePath = System.IO.Path.Combine(sFilePath, "ipow" + sFileName);
                        string wFilePath = System.IO.Path.Combine(sFilePath, "i" + sFileName);//水印图
                        ToMarkWater(strFilePath, strw, strw, wFilePath, 2);
                        //if (System.IO.File.Exists(strFilePath))
                        //{
                        //    System.IO.File.Delete(strFilePath);
                        //}
                    }
                    aPicInfo[0] = strReFile;
                    aPicInfo[1] = "i" + sFileName;
                    return aPicInfo;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }


        #region 给图片打水印，使用ASPJpeg控件
        /// <summary>
        /// 给图片打水印，使用ASPJpeg控件
        /// </summary>
        /// <param name="SourceFileName">原图</param>
        /// <param name="MarkFileNameBig">大水印图</param>
        /// <param name="MarkFileNameSmall">小水印图</param>
        /// <param name="SaveFileName">添加水印后的图片</param>
        /// <param name="WType">水印类型;1:文字水印;2图片水印</param>
        public static void ToMarkWater(string SourceFileName, string MarkFileNameBig, string MarkFileNameSmall, string SaveFileName, int WType)
        {
            string UserMarkFileName = "";
            int space = 0;

            try
            {
                int WidthS, HeightS;
                if (WType == 2)
                {
                    ASPJPEGLib.IASPJpeg objJpegS = new ASPJPEGLib.ASPJpeg();
                    ASPJPEGLib.IASPJpeg objJpegM = new ASPJPEGLib.ASPJpeg();
                    objJpegS.Open(SourceFileName);
                    WidthS = objJpegS.OriginalWidth;
                    HeightS = objJpegS.OriginalHeight;

                    if (WidthS >= 200 && HeightS >= 100)
                    {
                        UserMarkFileName = MarkFileNameBig;
                        space = 10;
                    }
                    else if (WidthS >= 60 && HeightS >= 30)
                    {
                        UserMarkFileName = MarkFileNameSmall;
                        space = 1;
                    }
                    else
                    {
                        objJpegS.Save(SaveFileName);

                        objJpegS.Close();
                    }

                    objJpegM.Open(UserMarkFileName);

                    int WidthM = objJpegM.OriginalWidth;
                    int HeightM = objJpegM.OriginalHeight;

                    if (WidthS > WidthM + space && HeightS > HeightM + space)
                    {
                        objJpegS.Canvas.DrawImage(WidthS - WidthM - space, HeightS - HeightM - space, (ASPJPEGLib.ASPJpeg)objJpegM, 0.7, "&HFFFFFF", 60);
                    }
                    objJpegS.Save(SaveFileName);
                    objJpegS.Close();
                    objJpegM.Close();
                }
                else
                {
                    ASPJPEGLib.IASPJpeg objJpegS = new ASPJPEGLib.ASPJpeg();
                    ASPJPEGLib.IASPJpeg objJpegM = new ASPJPEGLib.ASPJpeg();
                    objJpegS.Open(SourceFileName);
                    WidthS = objJpegS.OriginalWidth;
                    HeightS = objJpegS.OriginalHeight;
                    objJpegS.Canvas.Font.Family = "Arial";
                    objJpegS.Canvas.Font.ShadowXoffset = 1;
                    objJpegS.Canvas.Font.ShadowYoffset = 1;
                    objJpegS.Canvas.Font.Color = 0xffffff;
                    objJpegS.Canvas.Font.ShadowColor = 0xcccccc;
                    objJpegS.Canvas.Font.Quality = 10;
                    objJpegS.Canvas.Brush.Solid = 1;
                    objJpegS.Canvas.Font.Bold = 1;
                    objJpegS.Canvas.Font.Size = 40;
                    objJpegS.Canvas.PrintText(WidthS - (WidthS - 120), HeightS - 50, "www.ipow.cn", null);
                    objJpegS.Save(SaveFileName);
                    objJpegS.Close();
                    ASPJPEGLib.IASPJpeg objJpegA = new ASPJPEGLib.ASPJpeg();
                    objJpegA.Open(SourceFileName);
                    objJpegM.Open(SaveFileName);
                    objJpegA.Canvas.DrawImage(0, 0, (ASPJPEGLib.ASPJpeg)objJpegM, 0.6, "&HFF0000", 10);
                    objJpegA.Save(SaveFileName);

                    objJpegA.Close();
                    objJpegM.Close();
                }
            }
            catch
            {
            }
        }
        #endregion


        ///// <summary>
        ///// 上传视频
        ///// </summary>
        //public static string UploadVideo(UploadedFile oFile)
        //{
        //    try
        //    {

        //        // Get the uploaded file name.
        //        string sFileName = System.IO.Path.GetFileName(oFile.ClientName);//原文件名
        //        if (sFileName != "")
        //        {
        //            string FileTxt = System.IO.Path.GetExtension(oFile.ClientName);//扩展名
        //            string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//当前时间
        //            Random sran = new Random();//取随机数;
        //            string Rand = sran.Next(1, 9).ToString();

        //            sFileName = nFileName + Rand + FileTxt;//新的文件名（当前时间+１位随机数）
        //            string reFileName = sFileName;//返回

        //            //取保存目录
        //            string sFilePath = ConfigurationManager.AppSettings["VideoUpload"];
        //            //上传时间月份的文件夹(如:2007-1)
        //            //edit by yjihrp
        //            //string reFileP = "http://flv.ipow.cn" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";
        //            string reFileP = "http://sys.ipow.cn/upload" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";
        //            sFilePath = "~/Upload" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";

        //            //建立目录
        //            FileDirectoryHelper.CreateFolder(sFilePath);
        //            string reFilePath = sFilePath;//返回

        //            //路径
        //            sFilePath = System.Web.HttpContext.Current.Server.MapPath(sFilePath);

        //            string strFilePath = System.IO.Path.Combine(sFilePath, sFileName);

        //            oFile.SaveAs(strFilePath);


        //            string returntemp = reFileP + "|" + reFileName;
        //            return returntemp;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 上传视频 edit by yjihrp 2011.4.12
        /// </summary>
        public static string ClientUploadVideo(HttpPostedFile f)
        {
            try
            {
                // Get the uploaded file name.
                string sFileName = System.IO.Path.GetFileName(f.FileName);//原文件名
                if (sFileName != "")
                {
                    string FileTxt = System.IO.Path.GetExtension(f.FileName);//扩展名
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//当前时间
                    Random sran = new Random();//取随机数;
                    string Rand = sran.Next(1, 9).ToString();
                    sFileName = nFileName + Rand + FileTxt;//新的文件名（当前时间+１位随机数）
                    string reFileName = sFileName;//返回
                    //取保存目录
                    string sFilePath = ConfigurationManager.AppSettings["VideoUpload"];
                    //上传时间月份的文件夹(如:2007-1)
                    //edit by yjihrp 2011.4.11
                    //string reFileP = "http://flv.ipow.cn" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";
                    string reFileP = "http://flv.ipow.cn" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";
                    sFilePath = "~/Upload" + sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/Source/";
                    //建立目录
                    FileDirectoryHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;//返回
                    //路径
                    //  sFilePath = System.Web.HttpContext.Current.Server.MapPath(sFilePath);
                    string copySFilePath = System.Web.HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = System.IO.Path.Combine(copySFilePath, sFileName);
                    f.SaveAs(strFilePath);

                    // edit by yjihrp 2011.4.14
                    string ffPath = System.Web.HttpContext.Current.Server.MapPath("~/Upload/flv/ffmpeg.exe");
                    FfmpegHelper ffmpeg = new FfmpegHelper(ffPath);
                    ffmpeg.ToJpg(strFilePath);
                    string catchImgFileName = System.IO.Path.ChangeExtension(reFileName, ".jpg");
                    string returntemp = reFileP + "|" + reFileName + "|" + catchImgFileName;
                    //string returntemp = reFileP + "|" + reFileName ;
                    return returntemp;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 生成缩略图 mode:hw w h cut
        /// </summary>
        /// <param name="SourceImage">源图路径(含图片，物理路径)</param>
        /// <param name="ImageMapth">缩略图路径（含图片，物理路径)</param>
        /// <param name="width">缩略图宽</param>
        /// <param name="height">缩略图高  </param>
        public static void MakeImage(string sourceImage, string imageMapth, int width, int height, string mode)
        {
            System.Drawing.Image MyImage = System.Drawing.Image.FromFile(sourceImage);
            int towidth = width;
            int toheight = height;
            int x = 0, y = 0;
            int ow = MyImage.Width;
            int oh = MyImage.Height;
            switch (mode)
            {
                case "hw": break;
                case "w":
                    if (MyImage.Width > towidth)
                    {
                        toheight = MyImage.Height * width / MyImage.Width;
                    }
                    else
                    {
                        towidth = MyImage.Width;
                        toheight = MyImage.Height;
                    }
                    break;
                case "h":
                    if (MyImage.Height > toheight)
                        towidth = MyImage.Width * height / MyImage.Height;
                    else
                    {
                        toheight = MyImage.Width;
                        toheight = MyImage.Height;
                    }
                    break;
                case "cut":
                    if ((double)MyImage.Width / (double)MyImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = MyImage.Height;
                        if (MyImage.Width > towidth)
                        {
                            ow = MyImage.Height * towidth / toheight;
                        }
                        else
                        {
                            ow = MyImage.Width;
                        }
                        y = 0;
                        x = (MyImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = MyImage.Width;
                        if (MyImage.Height > toheight)
                            oh = MyImage.Width * toheight / towidth;
                        else
                            oh = MyImage.Height;
                        x = 0;
                        y = (MyImage.Height - oh) / 2;
                    }; break;
                default: break;
            }

            System.Drawing.Image tempbmp = new System.Drawing.Bitmap(towidth, toheight);
            Bitmap bitmap = new Bitmap(tempbmp);

            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


            g.Clear(Color.Transparent);
            g.DrawImage(MyImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
            try
            {
                tempbmp.Dispose();
                bitmap.Save(imageMapth, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
            }
            MyImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="type">The type.</param>
        public static void getAllFiles(string path, string type)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo fChild in dir.GetFiles()) //设置文件类型
            {
                try
                {
                    string strfilename = fChild.FullName;
                    string strTemp = strfilename.Replace(fChild.Name, "");
                    string[] strtxt = fChild.Name.Split('.');
                    string sFileName = fChild.Name;
                    string CutPath = @"E:\CutDown\";
                    string tFilePath = "";
                    //  生成缩略图150X150
                    tFilePath = CutPath + "160_150_" + sFileName;
                    MakeImage(strfilename, tFilePath, 160, 150, "cut");
                    // ToThumbNail(strFilePath, 160, 150, FileTxt, tFilePath);

                    //生成缩略图126X99
                    tFilePath = CutPath + "126_99_" + sFileName;
                    MakeImage(strfilename, tFilePath, 126, 99, "cut");
                    //ToThumbNail(strFilePath, 126, 99, FileTxt, tFilePath);

                    //生成缩略图116X103
                    tFilePath = CutPath + "116_103_" + sFileName;
                    MakeImage(strfilename, tFilePath, 116, 103, "cut");
                    //ToThumbNail(strFilePath, 116, 103, FileTxt, tFilePath);

                    //生成缩略图240X210
                    tFilePath = CutPath + "240_210_" + sFileName;
                    MakeImage(strfilename, tFilePath, 240, 210, "cut");


                    //生成缩略图550
                    tFilePath = CutPath + "ipow" + sFileName;
                    MakeImage(strfilename, tFilePath, 640, 0, "w");
                }
                catch
                {
                }
            }

            foreach (DirectoryInfo dChild in dir.GetDirectories("*")) //操作子目录
            {
                getAllFiles(dChild.FullName, type);
            }
        }
    }
}
