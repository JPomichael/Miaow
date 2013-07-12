namespace iPow.Infrastructure.Crosscutting.Comm.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationInfoDto
    {
        /// <summary>
        /// Gets or sets the start IP.
        /// </summary>
        /// <value>The start IP.</value>
        public string startIP { get; set; }

        /// <summary>
        /// Gets or sets the end IP.
        /// </summary>
        /// <value>The end IP.</value>
        public string endIP { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the ISP.
        /// </summary>
        /// <value>The ISP.</value>
        public string ISP { get; set; }

    }

}
