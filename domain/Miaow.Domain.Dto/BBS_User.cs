using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using System.Runtime.Serialization;

namespace iPow.Domain.Dto
{
    [DataContract]
    [Serializable]
    public class BBS_UserDto
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string cwpass { get; set; }

        [DataMember]
        public string pass_safe_question { get; set; }

        [DataMember]
        public string pass_safe_key { get; set; }

        [DataMember]
        public string useremail { get; set; }

        [DataMember]
        public int useremail_open { get; set; }

        [DataMember]
        public int user_coin { get; set; }

        [DataMember]
        public int user_credit { get; set; }

        [DataMember]
        public DateTime regtime { get; set; }

        [DataMember]
        public string regip { get; set; }

        [DataMember]
        public DateTime last_logintime { get; set; }

        [DataMember]
        public string last_loginip { get; set; }

        [DataMember]
        public int login_count { get; set; }

        [DataMember]
        public int usercommend { get; set; }

        [DataMember]
        public int upfile_sizecount { get; set; }

        [DataMember]
        public DateTime update_today { get; set; }

        [DataMember]
        public int bbscount { get; set; }

        [DataMember]
        public int user_group { get; set; }

        [DataMember]
        public string user_sex { get; set; }

        [DataMember]
        public string user_from { get; set; }

        [DataMember]
        public string user_qq { get; set; }

        [DataMember]
        public string user_msn { get; set; }

        [DataMember]
        public string user_homepage { get; set; }

        [DataMember]
        public string user_write { get; set; }

        [DataMember]
        public int user_imgwrite { get; set; }

        [DataMember]
        public string user_imgwrite_name { get; set; }

        [DataMember]
        public string user_imgwrite_url { get; set; }

        [DataMember]
        public string user_sys_face { get; set; }

        [DataMember]
        public string user_up_face { get; set; }

        [DataMember]
        public int user_up_face_width { get; set; }

        [DataMember]
        public int user_up_face_height { get; set; }

        [DataMember]
        public int user_face_select { get; set; }

        [DataMember]
        public int master_lev { get; set; }

        [DataMember]
        public DateTime noPostTime { get; set; }

        [DataMember]
        public string email_check { get; set; }

        [DataMember]
        public int regcheck_ok { get; set; }

        [DataMember]
        public int user_get_rancoin { get; set; }

        [DataMember]
        public int user_noget_rancoin { get; set; }

        [DataMember]
        public int assess_good { get; set; }

        [DataMember]
        public int assess_bad { get; set; }

        [DataMember]
        public int is_lock { get; set; }

        [DataMember]
        public string user_nickname { get; set; }

    }
}