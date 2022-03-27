namespace Assignment.A.Mapper
{
    using Assignment.A.Entities;
    using AutoMapper;
    using System;
    using System.Linq;
    using System.ServiceModel.Syndication;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SyndicationFeed, Feed>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title != null ? src.Title.Text : string.Empty))
                .ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.Description != null ? src.Description.Text : string.Empty))
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Entries, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.AuthorsToday, opt => opt.MapFrom(src => src.Contributors.Count));
            CreateMap<SyndicationFeed, FeedImage>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title != null ? src.Title.Text : string.Empty))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<SyndicationItem, FeedEntry>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title != null ? src.Title.Text : string.Empty))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Links.Any() ? src.Links.First().Uri.ToString() : string.Empty))
                .ForMember(dest => dest.PubDate, opt => opt.MapFrom(src => ConvertDateTime(src.PublishDate.DateTime).ToString("dd-MM-yyyy HH:mm:ss")))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => x.Name)));
        }

        private static DateTime ConvertDateTime(DateTime dateTime)
        {
            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Asia/Gaza");
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tzi);
        }
    }
}