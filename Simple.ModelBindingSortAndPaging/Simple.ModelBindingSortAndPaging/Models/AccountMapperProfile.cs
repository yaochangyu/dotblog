using AutoMapper;

namespace Simple.ModelBindingSortAndPaging.Models
{
    public class AccountMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Account, AccountViewModel>()
                    .ForMember(target => target.帳號, option => option.MapFrom(source => source.UserId))
                    .ForMember(target => target.密碼, option => option.MapFrom(source => source.Password))
                    .ForMember(target => target.電話, option => option.MapFrom(source => source.Phone))
                    .ForMember(target => target.外號, option => option.MapFrom(source => source.NickName))
                    .ForMember(target => target.年齡, option => option.MapFrom(source => source.Age));

            Mapper.CreateMap<AccountViewModel, Account>()
                         .ForMember(target => target.UserId, option => option.MapFrom(source => source.帳號))
                         .ForMember(target => target.Password, option => option.MapFrom(source => source.密碼))
                         .ForMember(target => target.Phone, option => option.MapFrom(source => source.電話))
                         .ForMember(target => target.NickName, option => option.MapFrom(source => source.外號))
                         .ForMember(target => target.Age, option => option.MapFrom(source => source.年齡));
        }
    }
}