using System.Collections.Generic;

namespace Miaow.Infrastructure.Crosscutting.EntityToDto
{
    public static partial class MiaowEntityToDto
    {
        public static Miaow.Domain.Dto.CityAreaCodeDto ToDto(this Miaow.Infrastructure.Data.DataSys.CityAreaCode entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CityAreaCode, Miaow.Domain.Dto.CityAreaCodeDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.CityAreaCodeDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.CityAreaCode> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CityAreaCode, Miaow.Domain.Dto.CityAreaCodeDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.CrawlPicInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.CrawlPicInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CrawlPicInfo, Miaow.Domain.Dto.CrawlPicInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.CrawlPicInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.CrawlPicInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CrawlPicInfo, Miaow.Domain.Dto.CrawlPicInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.CrawlSightInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.CrawlSightInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CrawlSightInfo, Miaow.Domain.Dto.CrawlSightInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.CrawlSightInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.CrawlSightInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.CrawlSightInfo, Miaow.Domain.Dto.CrawlSightInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_AcDataDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_AcData entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AcData, Miaow.Domain.Dto.Sys_AcDataDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_AcDataDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_AcData> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AcData, Miaow.Domain.Dto.Sys_AcDataDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.sys_administratorDto ToDto(this 
            Miaow.Infrastructure.Data.DataSys.sys_administrator entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_administrator,
                    Miaow.Domain.Dto.sys_administratorDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.sys_administratorDto> ToDto(this 
            IEnumerable<Miaow.Infrastructure.Data.DataSys.sys_administrator> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_administrator, Miaow.Domain.Dto.sys_administratorDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_AdminUserClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_AdminUserClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserClass, Miaow.Domain.Dto.Sys_AdminUserClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_AdminUserClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserClass, Miaow.Domain.Dto.Sys_AdminUserClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_AdminUserExtensionDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension, Miaow.Domain.Dto.Sys_AdminUserExtensionDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_AdminUserExtensionDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension, Miaow.Domain.Dto.Sys_AdminUserExtensionDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_AdminUserIndividuationDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation, Miaow.Domain.Dto.Sys_AdminUserIndividuationDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_AdminUserIndividuationDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation, Miaow.Domain.Dto.Sys_AdminUserIndividuationDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.sys_logsDto ToDto(this Miaow.Infrastructure.Data.DataSys.sys_logs entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_logs, Miaow.Domain.Dto.sys_logsDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.sys_logsDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.sys_logs> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_logs, Miaow.Domain.Dto.sys_logsDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_AdWebsiteInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo, Miaow.Domain.Dto.Sys_AdWebsiteInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_AdWebsiteInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_AdWebsiteInfo, Miaow.Domain.Dto.Sys_AdWebsiteInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ArticleClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ArticleClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleClass, Miaow.Domain.Dto.Sys_ArticleClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ArticleClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ArticleClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleClass, Miaow.Domain.Dto.Sys_ArticleClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ArticleCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ArticleComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleComm, Miaow.Domain.Dto.Sys_ArticleCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ArticleCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ArticleComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleComm, Miaow.Domain.Dto.Sys_ArticleCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ArticleInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo, Miaow.Domain.Dto.Sys_ArticleInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ArticleInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo, Miaow.Domain.Dto.Sys_ArticleInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_CityInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_CityInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo, Miaow.Domain.Dto.Sys_CityInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_CityInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo, Miaow.Domain.Dto.Sys_CityInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_CityInfoMoreDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore, Miaow.Domain.Dto.Sys_CityInfoMoreDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_CityInfoMoreDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore, Miaow.Domain.Dto.Sys_CityInfoMoreDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ClientActivityDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ClientActivity entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ClientActivity, Miaow.Domain.Dto.Sys_ClientActivityDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ClientActivityDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ClientActivity> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ClientActivity, Miaow.Domain.Dto.Sys_ClientActivityDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_DemoClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_DemoClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DemoClass, Miaow.Domain.Dto.Sys_DemoClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_DemoClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_DemoClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DemoClass, Miaow.Domain.Dto.Sys_DemoClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_DemoInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_DemoInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DemoInfo, Miaow.Domain.Dto.Sys_DemoInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_DemoInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_DemoInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DemoInfo, Miaow.Domain.Dto.Sys_DemoInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_DiscountClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass, Miaow.Domain.Dto.Sys_DiscountClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_DiscountClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass, Miaow.Domain.Dto.Sys_DiscountClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_DiscountCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm, Miaow.Domain.Dto.Sys_DiscountCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_DiscountCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm, Miaow.Domain.Dto.Sys_DiscountCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_DisCountInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_DisCountInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DisCountInfo, Miaow.Domain.Dto.Sys_DisCountInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_DisCountInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_DisCountInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_DisCountInfo, Miaow.Domain.Dto.Sys_DisCountInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_GuestBookDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_GuestBook entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_GuestBook, Miaow.Domain.Dto.Sys_GuestBookDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_GuestBookDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_GuestBook> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_GuestBook, Miaow.Domain.Dto.Sys_GuestBookDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelComm, Miaow.Domain.Dto.Sys_HotelCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelComm, Miaow.Domain.Dto.Sys_HotelCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelDailyRates2Dto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2, Miaow.Domain.Dto.Sys_HotelDailyRates2Dto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelDailyRates2Dto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2, Miaow.Domain.Dto.Sys_HotelDailyRates2Dto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelPicDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelPic entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPic, Miaow.Domain.Dto.Sys_HotelPicDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelPicDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelPic> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPic, Miaow.Domain.Dto.Sys_HotelPicDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelPropertyInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo, Miaow.Domain.Dto.Sys_HotelPropertyInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelPropertyInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo, Miaow.Domain.Dto.Sys_HotelPropertyInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelPropertyInfo2Dto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2, Miaow.Domain.Dto.Sys_HotelPropertyInfo2Dto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelPropertyInfo2Dto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2, Miaow.Domain.Dto.Sys_HotelPropertyInfo2Dto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelReservationInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo, Miaow.Domain.Dto.Sys_HotelReservationInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelReservationInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelReservationInfo, Miaow.Domain.Dto.Sys_HotelReservationInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_HotelRoomInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo, Miaow.Domain.Dto.Sys_HotelRoomInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_HotelRoomInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo, Miaow.Domain.Dto.Sys_HotelRoomInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_IpAddressDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_IpAddress entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_IpAddress, Miaow.Domain.Dto.Sys_IpAddressDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_IpAddressDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_IpAddress> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_IpAddress, Miaow.Domain.Dto.Sys_IpAddressDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_LinksClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_LinksClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_LinksClass, Miaow.Domain.Dto.Sys_LinksClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_LinksClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_LinksClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_LinksClass, Miaow.Domain.Dto.Sys_LinksClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_LinksInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_LinksInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_LinksInfo, Miaow.Domain.Dto.Sys_LinksInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_LinksInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_LinksInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_LinksInfo, Miaow.Domain.Dto.Sys_LinksInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_LogDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_Log entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Log, Miaow.Domain.Dto.Sys_LogDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_LogDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_Log> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Log, Miaow.Domain.Dto.Sys_LogDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_MenuTreeDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MenuTree entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MenuTree, Miaow.Domain.Dto.Sys_MenuTreeDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MenuTreeDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MenuTree> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MenuTree, Miaow.Domain.Dto.Sys_MenuTreeDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_MvcControllerDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MvcController entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcController, Miaow.Domain.Dto.Sys_MvcControllerDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MvcControllerDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcController, Miaow.Domain.Dto.Sys_MvcControllerDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_MvcControllerActionClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass,
                    Miaow.Domain.Dto.Sys_MvcControllerActionClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MvcControllerActionClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass,
                    Miaow.Domain.Dto.Sys_MvcControllerActionClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_MvcControllerClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerClass,
                    Miaow.Domain.Dto.Sys_MvcControllerClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MvcControllerClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerClass,
                    Miaow.Domain.Dto.Sys_MvcControllerClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_MvcControllerRolePermissionDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission, Miaow.Domain.Dto.Sys_MvcControllerRolePermissionDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MvcControllerRolePermissionDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission,
                    Miaow.Domain.Dto.Sys_MvcControllerRolePermissionDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_NewsClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_NewsClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_NewsClass, Miaow.Domain.Dto.Sys_NewsClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_NewsClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_NewsClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_NewsClass, Miaow.Domain.Dto.Sys_NewsClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_NewsInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_NewsInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_NewsInfo, Miaow.Domain.Dto.Sys_NewsInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_NewsInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_NewsInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_NewsInfo, Miaow.Domain.Dto.Sys_NewsInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_PermissionCategoriesDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_PermissionCategories entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PermissionCategories, Miaow.Domain.Dto.Sys_PermissionCategoriesDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_PermissionCategoriesDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_PermissionCategories> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PermissionCategories, Miaow.Domain.Dto.Sys_PermissionCategoriesDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_PermissionsDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_Permissions entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Permissions, Miaow.Domain.Dto.Sys_PermissionsDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_PermissionsDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_Permissions> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Permissions, Miaow.Domain.Dto.Sys_PermissionsDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.sys_phone_lyDto ToDto(this Miaow.Infrastructure.Data.DataSys.sys_phone_ly entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_phone_ly, Miaow.Domain.Dto.sys_phone_lyDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.sys_phone_lyDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.sys_phone_ly> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.sys_phone_ly, Miaow.Domain.Dto.sys_phone_lyDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_phoneCountDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_phoneCount entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_phoneCount, Miaow.Domain.Dto.Sys_phoneCountDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_phoneCountDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_phoneCount> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_phoneCount, Miaow.Domain.Dto.Sys_phoneCountDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_PicClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_PicClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicClass, Miaow.Domain.Dto.Sys_PicClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_PicClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_PicClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicClass, Miaow.Domain.Dto.Sys_PicClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_PicCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_PicComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicComm, Miaow.Domain.Dto.Sys_PicCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_PicCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_PicComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicComm, Miaow.Domain.Dto.Sys_PicCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_PicInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_PicInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicInfo, Miaow.Domain.Dto.Sys_PicInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_PicInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_PicInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_PicInfo, Miaow.Domain.Dto.Sys_PicInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_RolePermissionsDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_RolePermissions entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_RolePermissions, Miaow.Domain.Dto.Sys_RolePermissionsDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_RolePermissionsDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_RolePermissions> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_RolePermissions, Miaow.Domain.Dto.Sys_RolePermissionsDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_RolesDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_Roles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Roles, Miaow.Domain.Dto.Sys_RolesDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_RolesDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_Roles, Miaow.Domain.Dto.Sys_RolesDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SearchInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SearchInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SearchInfo, Miaow.Domain.Dto.Sys_SearchInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SearchInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SearchInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SearchInfo, Miaow.Domain.Dto.Sys_SearchInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightClass, Miaow.Domain.Dto.Sys_SightClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightClass, Miaow.Domain.Dto.Sys_SightClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightComm, Miaow.Domain.Dto.Sys_SightCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightComm, Miaow.Domain.Dto.Sys_SightCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo, Miaow.Domain.Dto.Sys_SightInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo, Miaow.Domain.Dto.Sys_SightInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightInfoCirHotelDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel, Miaow.Domain.Dto.Sys_SightInfoCirHotelDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightInfoCirHotelDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel, Miaow.Domain.Dto.Sys_SightInfoCirHotelDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightInfoCirSightDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight, Miaow.Domain.Dto.Sys_SightInfoCirSightDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightInfoCirSightDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight, Miaow.Domain.Dto.Sys_SightInfoCirSightDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightInfoSortDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort, Miaow.Domain.Dto.Sys_SightInfoSortDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightInfoSortDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort, Miaow.Domain.Dto.Sys_SightInfoSortDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightTicketDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightTicket entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightTicket, Miaow.Domain.Dto.Sys_SightTicketDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightTicketDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightTicket> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightTicket, Miaow.Domain.Dto.Sys_SightTicketDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightVouchDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightVouch entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightVouch, Miaow.Domain.Dto.Sys_SightVouchDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightVouchDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightVouch> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightVouch, Miaow.Domain.Dto.Sys_SightVouchDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_SightVouchItemDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_SightVouchItem entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightVouchItem, Miaow.Domain.Dto.Sys_SightVouchItemDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_SightVouchItemDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_SightVouchItem, Miaow.Domain.Dto.Sys_SightVouchItemDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ThemeActivityDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivity entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivity, Miaow.Domain.Dto.Sys_ThemeActivityDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ThemeActivityDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivity> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivity, Miaow.Domain.Dto.Sys_ThemeActivityDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_ThemeActivityClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass, Miaow.Domain.Dto.Sys_ThemeActivityClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_ThemeActivityClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_ThemeActivityClass, Miaow.Domain.Dto.Sys_ThemeActivityClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_TourClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourClass, Miaow.Domain.Dto.Sys_TourClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_TourClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourClass, Miaow.Domain.Dto.Sys_TourClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_TourInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourInfo, Miaow.Domain.Dto.Sys_TourInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_TourInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourInfo, Miaow.Domain.Dto.Sys_TourInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_TourPlanDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourPlan entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlan, Miaow.Domain.Dto.Sys_TourPlanDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_TourPlanDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourPlan> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlan, Miaow.Domain.Dto.Sys_TourPlanDto>().MapEnum(entity);
        }



        public static Miaow.Domain.Dto.Sys_TourPlanDetailDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Domain.Dto.Sys_TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_TourPlanDetailDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Domain.Dto.Sys_TourPlanDetailDto>().MapEnum(entity);
        }




        public static Miaow.Domain.Dto.Sys_UserActionDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_UserAction entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserAction, Miaow.Domain.Dto.Sys_UserActionDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_UserActionDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_UserAction> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserAction, Miaow.Domain.Dto.Sys_UserActionDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_UserRolesDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles, Miaow.Domain.Dto.Sys_UserRolesDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_UserRolesDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles, Miaow.Domain.Dto.Sys_UserRolesDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_VideoClassDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_VideoClass entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoClass, Miaow.Domain.Dto.Sys_VideoClassDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_VideoClassDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_VideoClass> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoClass, Miaow.Domain.Dto.Sys_VideoClassDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_VideoCommDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_VideoComm entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoComm, Miaow.Domain.Dto.Sys_VideoCommDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_VideoCommDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_VideoComm> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoComm, Miaow.Domain.Dto.Sys_VideoCommDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_VideoInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_VideoInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoInfo, Miaow.Domain.Dto.Sys_VideoInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_VideoInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_VideoInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VideoInfo, Miaow.Domain.Dto.Sys_VideoInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_VouchHotelInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo, Miaow.Domain.Dto.Sys_VouchHotelInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_VouchHotelInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VouchHotelInfo, Miaow.Domain.Dto.Sys_VouchHotelInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.Sys_VouchInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_VouchInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VouchInfo, Miaow.Domain.Dto.Sys_VouchInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_VouchInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_VouchInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_VouchInfo, Miaow.Domain.Dto.Sys_VouchInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.T_DailyRatesDto ToDto(this Miaow.Infrastructure.Data.DataSys.T_DailyRates entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.T_DailyRates, Miaow.Domain.Dto.T_DailyRatesDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.T_DailyRatesDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.T_DailyRates> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.T_DailyRates, Miaow.Domain.Dto.T_DailyRatesDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.TripIndexInfoDto ToDto(this Miaow.Infrastructure.Data.DataSys.TripIndexInfo entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.TripIndexInfo, Miaow.Domain.Dto.TripIndexInfoDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.TripIndexInfoDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.TripIndexInfo> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.TripIndexInfo, Miaow.Domain.Dto.TripIndexInfoDto>().MapEnum(entity);
        }

        public static Miaow.Domain.Dto.TripListDto ToDto(this Miaow.Infrastructure.Data.DataSys.TripList entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.TripList, Miaow.Domain.Dto.TripListDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.TripListDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.TripList> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.TripList, Miaow.Domain.Dto.TripListDto>().MapEnum(entity);
        }
    }
}
