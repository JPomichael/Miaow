using System.Collections.Generic;

namespace iPow.Infrastructure.Crosscutting.EntityToDto
{
    public static partial class iPowEntityToDto
    {
        public static iPow.Domain.Dto.CityAreaCodeDto ToDto(this iPow.Infrastructure.Data.DataSys.CityAreaCode entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CityAreaCode, iPow.Domain.Dto.CityAreaCodeDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.CityAreaCodeDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.CityAreaCode> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CityAreaCode, iPow.Domain.Dto.CityAreaCodeDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.CrawlPicInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.CrawlPicInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CrawlPicInfo, iPow.Domain.Dto.CrawlPicInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.CrawlPicInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.CrawlPicInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CrawlPicInfo, iPow.Domain.Dto.CrawlPicInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.CrawlSightInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.CrawlSightInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CrawlSightInfo, iPow.Domain.Dto.CrawlSightInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.CrawlSightInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.CrawlSightInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.CrawlSightInfo, iPow.Domain.Dto.CrawlSightInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AcDataDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AcData entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AcData, iPow.Domain.Dto.Sys_AcDataDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AcDataDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AcData> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AcData, iPow.Domain.Dto.Sys_AcDataDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdminUserDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdminUser entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUser, iPow.Domain.Dto.Sys_AdminUserDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdminUserDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUser> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUser, iPow.Domain.Dto.Sys_AdminUserDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdminUserClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass, iPow.Domain.Dto.Sys_AdminUserClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdminUserClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass, iPow.Domain.Dto.Sys_AdminUserClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdminUserExtensionDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension, iPow.Domain.Dto.Sys_AdminUserExtensionDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdminUserExtensionDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension, iPow.Domain.Dto.Sys_AdminUserExtensionDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdminUserIndividuationDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation, iPow.Domain.Dto.Sys_AdminUserIndividuationDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdminUserIndividuationDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation, iPow.Domain.Dto.Sys_AdminUserIndividuationDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdminUserLogDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog, iPow.Domain.Dto.Sys_AdminUserLogDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdminUserLogDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog, iPow.Domain.Dto.Sys_AdminUserLogDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_AdWebsiteInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo, iPow.Domain.Dto.Sys_AdWebsiteInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_AdWebsiteInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo, iPow.Domain.Dto.Sys_AdWebsiteInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ArticleClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ArticleClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleClass, iPow.Domain.Dto.Sys_ArticleClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ArticleClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ArticleClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleClass, iPow.Domain.Dto.Sys_ArticleClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ArticleCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ArticleComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleComm, iPow.Domain.Dto.Sys_ArticleCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ArticleCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ArticleComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleComm, iPow.Domain.Dto.Sys_ArticleCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ArticleInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo, iPow.Domain.Dto.Sys_ArticleInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ArticleInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo, iPow.Domain.Dto.Sys_ArticleInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_CityInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_CityInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_CityInfo, iPow.Domain.Dto.Sys_CityInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_CityInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_CityInfo, iPow.Domain.Dto.Sys_CityInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_CityInfoMoreDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_CityInfoMore entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_CityInfoMore, iPow.Domain.Dto.Sys_CityInfoMoreDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_CityInfoMoreDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_CityInfoMore, iPow.Domain.Dto.Sys_CityInfoMoreDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ClientActivityDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ClientActivity entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ClientActivity, iPow.Domain.Dto.Sys_ClientActivityDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ClientActivityDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ClientActivity> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ClientActivity, iPow.Domain.Dto.Sys_ClientActivityDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_DemoClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_DemoClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DemoClass, iPow.Domain.Dto.Sys_DemoClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_DemoClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_DemoClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DemoClass, iPow.Domain.Dto.Sys_DemoClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_DemoInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_DemoInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DemoInfo, iPow.Domain.Dto.Sys_DemoInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_DemoInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_DemoInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DemoInfo, iPow.Domain.Dto.Sys_DemoInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_DiscountClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_DiscountClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass, iPow.Domain.Dto.Sys_DiscountClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_DiscountClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass, iPow.Domain.Dto.Sys_DiscountClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_DiscountCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_DiscountComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DiscountComm, iPow.Domain.Dto.Sys_DiscountCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_DiscountCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DiscountComm, iPow.Domain.Dto.Sys_DiscountCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_DisCountInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_DisCountInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DisCountInfo, iPow.Domain.Dto.Sys_DisCountInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_DisCountInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_DisCountInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_DisCountInfo, iPow.Domain.Dto.Sys_DisCountInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_GuestBookDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_GuestBook entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_GuestBook, iPow.Domain.Dto.Sys_GuestBookDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_GuestBookDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_GuestBook> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_GuestBook, iPow.Domain.Dto.Sys_GuestBookDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelComm, iPow.Domain.Dto.Sys_HotelCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelComm, iPow.Domain.Dto.Sys_HotelCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelDailyRates2Dto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2, iPow.Domain.Dto.Sys_HotelDailyRates2Dto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelDailyRates2Dto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2, iPow.Domain.Dto.Sys_HotelDailyRates2Dto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelPicDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelPic entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPic, iPow.Domain.Dto.Sys_HotelPicDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelPicDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelPic> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPic, iPow.Domain.Dto.Sys_HotelPicDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelPropertyInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo, iPow.Domain.Dto.Sys_HotelPropertyInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelPropertyInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo, iPow.Domain.Dto.Sys_HotelPropertyInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelPropertyInfo2Dto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2, iPow.Domain.Dto.Sys_HotelPropertyInfo2Dto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelPropertyInfo2Dto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2, iPow.Domain.Dto.Sys_HotelPropertyInfo2Dto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelReservationInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo, iPow.Domain.Dto.Sys_HotelReservationInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelReservationInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo, iPow.Domain.Dto.Sys_HotelReservationInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_HotelRoomInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo, iPow.Domain.Dto.Sys_HotelRoomInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_HotelRoomInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo, iPow.Domain.Dto.Sys_HotelRoomInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_IpAddressDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_IpAddress entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_IpAddress, iPow.Domain.Dto.Sys_IpAddressDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_IpAddressDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_IpAddress> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_IpAddress, iPow.Domain.Dto.Sys_IpAddressDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_LinksClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_LinksClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_LinksClass, iPow.Domain.Dto.Sys_LinksClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_LinksClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_LinksClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_LinksClass, iPow.Domain.Dto.Sys_LinksClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_LinksInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_LinksInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_LinksInfo, iPow.Domain.Dto.Sys_LinksInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_LinksInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_LinksInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_LinksInfo, iPow.Domain.Dto.Sys_LinksInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_LogDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_Log entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Log, iPow.Domain.Dto.Sys_LogDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_LogDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_Log> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Log, iPow.Domain.Dto.Sys_LogDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_MenuTreeDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MenuTree entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MenuTree, iPow.Domain.Dto.Sys_MenuTreeDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MenuTreeDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MenuTree> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MenuTree, iPow.Domain.Dto.Sys_MenuTreeDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_MvcControllerDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MvcController entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcController, iPow.Domain.Dto.Sys_MvcControllerDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MvcControllerDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcController, iPow.Domain.Dto.Sys_MvcControllerDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_MvcControllerActionClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass,
                    iPow.Domain.Dto.Sys_MvcControllerActionClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MvcControllerActionClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass,
                    iPow.Domain.Dto.Sys_MvcControllerActionClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_MvcControllerClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass,
                    iPow.Domain.Dto.Sys_MvcControllerClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MvcControllerClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass,
                    iPow.Domain.Dto.Sys_MvcControllerClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_MvcControllerRolePermissionDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission, iPow.Domain.Dto.Sys_MvcControllerRolePermissionDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MvcControllerRolePermissionDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission,
                    iPow.Domain.Dto.Sys_MvcControllerRolePermissionDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_NewsClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_NewsClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_NewsClass, iPow.Domain.Dto.Sys_NewsClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_NewsClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_NewsClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_NewsClass, iPow.Domain.Dto.Sys_NewsClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_NewsInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_NewsInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_NewsInfo, iPow.Domain.Dto.Sys_NewsInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_NewsInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_NewsInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_NewsInfo, iPow.Domain.Dto.Sys_NewsInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_PermissionCategoriesDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_PermissionCategories entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PermissionCategories, iPow.Domain.Dto.Sys_PermissionCategoriesDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_PermissionCategoriesDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_PermissionCategories> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PermissionCategories, iPow.Domain.Dto.Sys_PermissionCategoriesDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_PermissionsDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_Permissions entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Permissions, iPow.Domain.Dto.Sys_PermissionsDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_PermissionsDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_Permissions> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Permissions, iPow.Domain.Dto.Sys_PermissionsDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.sys_phone_lyDto ToDto(this iPow.Infrastructure.Data.DataSys.sys_phone_ly entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.sys_phone_ly, iPow.Domain.Dto.sys_phone_lyDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.sys_phone_lyDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.sys_phone_ly> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.sys_phone_ly, iPow.Domain.Dto.sys_phone_lyDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_phoneCountDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_phoneCount entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_phoneCount, iPow.Domain.Dto.Sys_phoneCountDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_phoneCountDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_phoneCount> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_phoneCount, iPow.Domain.Dto.Sys_phoneCountDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_PicClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_PicClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicClass, iPow.Domain.Dto.Sys_PicClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_PicClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_PicClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicClass, iPow.Domain.Dto.Sys_PicClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_PicCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_PicComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicComm, iPow.Domain.Dto.Sys_PicCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_PicCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_PicComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicComm, iPow.Domain.Dto.Sys_PicCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_PicInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_PicInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicInfo, iPow.Domain.Dto.Sys_PicInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_PicInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_PicInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_PicInfo, iPow.Domain.Dto.Sys_PicInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_RolePermissionsDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_RolePermissions entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_RolePermissions, iPow.Domain.Dto.Sys_RolePermissionsDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_RolePermissionsDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_RolePermissions> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_RolePermissions, iPow.Domain.Dto.Sys_RolePermissionsDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_RolesDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_Roles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Roles, iPow.Domain.Dto.Sys_RolesDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_RolesDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_Roles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_Roles, iPow.Domain.Dto.Sys_RolesDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SearchInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SearchInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SearchInfo, iPow.Domain.Dto.Sys_SearchInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SearchInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SearchInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SearchInfo, iPow.Domain.Dto.Sys_SearchInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightClass, iPow.Domain.Dto.Sys_SightClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightClass, iPow.Domain.Dto.Sys_SightClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightComm, iPow.Domain.Dto.Sys_SightCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightComm, iPow.Domain.Dto.Sys_SightCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfo, iPow.Domain.Dto.Sys_SightInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfo, iPow.Domain.Dto.Sys_SightInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightInfoCirHotelDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel, iPow.Domain.Dto.Sys_SightInfoCirHotelDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightInfoCirHotelDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel, iPow.Domain.Dto.Sys_SightInfoCirHotelDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightInfoCirSightDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight, iPow.Domain.Dto.Sys_SightInfoCirSightDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightInfoCirSightDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight, iPow.Domain.Dto.Sys_SightInfoCirSightDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightInfoSortDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightInfoSort entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoSort, iPow.Domain.Dto.Sys_SightInfoSortDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightInfoSortDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfoSort> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightInfoSort, iPow.Domain.Dto.Sys_SightInfoSortDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightTicketDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightTicket entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightTicket, iPow.Domain.Dto.Sys_SightTicketDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightTicketDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightTicket> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightTicket, iPow.Domain.Dto.Sys_SightTicketDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightVouchDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightVouch entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightVouch, iPow.Domain.Dto.Sys_SightVouchDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightVouchDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightVouch> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightVouch, iPow.Domain.Dto.Sys_SightVouchDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_SightVouchItemDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem, iPow.Domain.Dto.Sys_SightVouchItemDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_SightVouchItemDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem, iPow.Domain.Dto.Sys_SightVouchItemDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ThemeActivityDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ThemeActivity entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivity, iPow.Domain.Dto.Sys_ThemeActivityDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ThemeActivityDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivity> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivity, iPow.Domain.Dto.Sys_ThemeActivityDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_ThemeActivityClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass, iPow.Domain.Dto.Sys_ThemeActivityClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_ThemeActivityClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass, iPow.Domain.Dto.Sys_ThemeActivityClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_TourClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourClass, iPow.Domain.Dto.Sys_TourClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_TourClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourClass, iPow.Domain.Dto.Sys_TourClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_TourInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourInfo, iPow.Domain.Dto.Sys_TourInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_TourInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourInfo, iPow.Domain.Dto.Sys_TourInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_TourPlanDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourPlan entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlan, iPow.Domain.Dto.Sys_TourPlanDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_TourPlanDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlan> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlan, iPow.Domain.Dto.Sys_TourPlanDto>().MapEnum(entity);
        }



        public static iPow.Domain.Dto.Sys_TourPlanDetailDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Domain.Dto.Sys_TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_TourPlanDetailDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Domain.Dto.Sys_TourPlanDetailDto>().MapEnum(entity);
        }




        public static iPow.Domain.Dto.Sys_UserActionDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_UserAction entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserAction, iPow.Domain.Dto.Sys_UserActionDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_UserActionDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_UserAction> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserAction, iPow.Domain.Dto.Sys_UserActionDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_UserRolesDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserRoles, iPow.Domain.Dto.Sys_UserRolesDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_UserRolesDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserRoles, iPow.Domain.Dto.Sys_UserRolesDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_VideoClassDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_VideoClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoClass, iPow.Domain.Dto.Sys_VideoClassDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_VideoClassDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoClass, iPow.Domain.Dto.Sys_VideoClassDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_VideoCommDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_VideoComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoComm, iPow.Domain.Dto.Sys_VideoCommDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_VideoCommDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_VideoComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoComm, iPow.Domain.Dto.Sys_VideoCommDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_VideoInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_VideoInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoInfo, iPow.Domain.Dto.Sys_VideoInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_VideoInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_VideoInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VideoInfo, iPow.Domain.Dto.Sys_VideoInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_VouchHotelInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo, iPow.Domain.Dto.Sys_VouchHotelInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_VouchHotelInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo, iPow.Domain.Dto.Sys_VouchHotelInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.Sys_VouchInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_VouchInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VouchInfo, iPow.Domain.Dto.Sys_VouchInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_VouchInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_VouchInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_VouchInfo, iPow.Domain.Dto.Sys_VouchInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.T_DailyRatesDto ToDto(this iPow.Infrastructure.Data.DataSys.T_DailyRates entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.T_DailyRates, iPow.Domain.Dto.T_DailyRatesDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.T_DailyRatesDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.T_DailyRates> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.T_DailyRates, iPow.Domain.Dto.T_DailyRatesDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.TripIndexInfoDto ToDto(this iPow.Infrastructure.Data.DataSys.TripIndexInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.TripIndexInfo, iPow.Domain.Dto.TripIndexInfoDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.TripIndexInfoDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.TripIndexInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.TripIndexInfo, iPow.Domain.Dto.TripIndexInfoDto>().MapEnum(entity);
        }

        public static iPow.Domain.Dto.TripListDto ToDto(this iPow.Infrastructure.Data.DataSys.TripList entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.TripList, iPow.Domain.Dto.TripListDto>().Map(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.TripListDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.TripList> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.TripList, iPow.Domain.Dto.TripListDto>().MapEnum(entity);
        }
    }
}
