namespace iPow.Infrastructure.Crosscutting.NetFramework
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the select city info.
        /// </summary>
        /// <value>The select city info.</value>
        iPow.Domain.Dto.Sys_CityInfoDto SelectedCityInfo { get; set; }

        /// <summary>
        /// Gets or sets the current city info.
        /// </summary>
        /// <value>The current city info.</value>
        iPow.Domain.Dto.Sys_CityInfoDto CurrentCityInfo { get; set; }

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        iPow.Infrastructure.Data.DataSys.Sys_AdminUser CurrentUser { get; set; }

        /// <summary>
        /// Gets or sets the current user extension.
        /// </summary>
        /// <value>The current user extension.</value>
        iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension CurrentUserExtension { get; set; }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; }
    }
}
