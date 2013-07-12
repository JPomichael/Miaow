using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Service.Union.Config;

namespace iPow.Service.Union
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UnionDataUrlBase
    {
        #region structure

        /// <summary>
        /// Initializes a new instance of the <see cref="UnionDataUrlBase"/> class.
        /// </summary>
        public UnionDataUrlBase()
        {
            UrlBuilder = new System.Text.StringBuilder();
            UrlParas = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnionDataUrlBase"/> class.
        /// </summary>
        /// <param name="fig">The fig.</param>
        public UnionDataUrlBase(IUnionConfig fig)
        {
            Config = fig;
            UrlBuilder = new System.Text.StringBuilder();
            UrlParas = new Dictionary<string, string>();
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        /// <value>The config.</value>
        public IUnionConfig Config { get; set; }

        /// <summary>
        /// Gets or sets the para.
        /// </summary>
        /// <value>The para.</value>
        public Dictionary<string, string> UrlParas { get; set; }

        /// <summary>
        /// Gets or sets the source URL.
        /// </summary>
        /// <value>The source URL.</value>
        public string UrlSource { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the URL builder.
        /// </summary>
        /// <value>The URL builder.</value>
        protected System.Text.StringBuilder UrlBuilder { get; set; }

        #endregion

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <returns></returns>
        public virtual Uri GetUrl()
        {
            Uri url = null;
            var fig = Config.Initial();
            UrlBuilder = UrlBuilder.Clear();
            if (fig != null && this.UrlParas != null && !string.IsNullOrEmpty(UrlSource))
            {
                UrlBuilder.Append(fig.BaseUrl + UrlSource);
                foreach (var item in this.UrlParas)
                {
                    UrlBuilder.Append(item.Key.ToString() + "=" + item.Value + "&");
                }
                UrlBuilder.Append("agent_id=" + fig.AgentId + "&");
                UrlBuilder.Append("agent_md=" + fig.AgentMd + ".html");
                try
                {
                    url = new Uri(UrlBuilder.ToString());
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                }
            }
            else
            {
                Message = "config not found or para is null";
            }
            return url;
        }
    }
}
