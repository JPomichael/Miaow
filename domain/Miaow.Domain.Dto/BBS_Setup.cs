using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_SetupDto
    {
        [DataMember]
        public string BBS_Name { get; set; }

        [DataMember]
        public int BBS_State { get; set; }

        [DataMember]
        public string BBS_Url { get; set; }

        [DataMember]
        public string BBS_Logo { get; set; }

        [DataMember]
        public string BBS_Copyright { get; set; }

        [DataMember]
        public int BBS_Isreg { get; set; }

        [DataMember]
        public int BBS_Isemailcheck { get; set; }

        [DataMember]
        public string BBS_Emailserver { get; set; }

        [DataMember]
        public string BBS_Emailuser { get; set; }

        [DataMember]
        public string BBS_Emailpass { get; set; }

        [DataMember]
        public int BBS_regInvite { get; set; }

        [DataMember]
        public string XmlFolder { get; set; }

        [DataMember]
        public string BoardXmlName { get; set; }

        [DataMember]
        public string DispXmlName { get; set; }

        [DataMember]
        public int BoardXmlCreateTime { get; set; }

        [DataMember]
        public int BBS_ListPageSize { get; set; }

        [DataMember]
        public int BBS_DispPageSize { get; set; }

        [DataMember]
        public string UsernameRestrict { get; set; }

        [DataMember]
        public string BBS_coin_name { get; set; }

        [DataMember]
        public int BBS_coin_init { get; set; }

        [DataMember]
        public int BBS_usercommend { get; set; }

        [DataMember]
        public string BBS_upfile_ext { get; set; }

        [DataMember]
        public int BBS_upfile_size { get; set; }

        [DataMember]
        public int BBS_upfile_userdayfilesize { get; set; }

        [DataMember]
        public string email_server { get; set; }

        [DataMember]
        public string email_user { get; set; }

        [DataMember]
        public string email_password { get; set; }

        [DataMember]
        public int BBS_userface_width { get; set; }

        [DataMember]
        public int BBS_userface_height { get; set; }

        [DataMember]
        public int BBS_userface_upmoney { get; set; }

        [DataMember]
        public int BBS_useronline_time { get; set; }

        [DataMember]
        public int BBS_task_open { get; set; }

        [DataMember]
        public int BBS_pet { get; set; }

        [DataMember]
        public int BBS_down_maxmoney { get; set; }

        [DataMember]
        public int BBS_down_credit { get; set; }

        [DataMember]
        public int BBS_img_maxmoney { get; set; }

        [DataMember]
        public int BBS_img_credit { get; set; }

        [DataMember]
        public int BBS_mp3_maxmoney { get; set; }

        [DataMember]
        public int BBS_mp3_credit { get; set; }

        [DataMember]
        public int BBS_badass_credit { get; set; }

        [DataMember]
        public string BBS_Head_description { get; set; }

        [DataMember]
        public string BBS_Head_keywords { get; set; }

        [DataMember]
        public int BBS_minRanCoin { get; set; }

        [DataMember]
        public int BBS_maxRanCoin { get; set; }

        [DataMember]
        public int BBS_get_rancoin_gl { get; set; }

        [DataMember]
        public string BBS_forbid_word { get; set; }

        [DataMember]
        public string credit_lev { get; set; }

    }
}