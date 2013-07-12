using iPow.Domain.Dto;

namespace iPow.Application.jq.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class PicCommListDto
    {
        /// <summary>
        /// Gets or sets the comm list.
        /// </summary>
        /// <value>The comm list.</value>
        public Webdiyer.WebControls.Mvc.PagedList<Sys_PicCommDto> CommList { get; set; }

        /// <summary>
        /// Gets or sets the pic info.
        /// </summary>
        /// <value>The pic info.</value>
        public int PicId { get; set; }
    }
}