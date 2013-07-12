using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.OAuth.Sina
{
    [Serializable]
    public class SinaModel
    {
        public int id { get; set; }

        public string screen_name { get; set; }

        public string name { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string location { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        public string profile_image_url { get; set; }

        public string domain { get; set; }


        public status status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        [NonSerialized]
        private status _status;

        public string gender { get; set; }

        public string followers_count { get; set; }

        public string friends_count { get; set; }

        public string statuses_count { get; set; }

        public string favourites_count { get; set; }

        public string created_at { get; set; }

        public string following { get; set; }

        public string allow_all_act_msg { get; set; }

        public string geo_enabled { get; set; }

        public string verified { get; set; }

    }

    [Serializable]
    public class status
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string favorited { get; set; }
        public string truncated { get; set; }
        public string geo { get; set; }
        public string mid { get; set; }
        public string source { get; set; }

        public string in_reply_to_status_id { get { return _in_reply_to_status_id; } set { _in_reply_to_status_id = value; } }
        [NonSerialized]
        private string _in_reply_to_status_id = "";
        public string in_reply_to_screen_name { get; set; }
    }
}