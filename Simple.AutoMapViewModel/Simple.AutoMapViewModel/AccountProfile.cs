using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Simple.AutoMapViewModel.DAL.Model;
using Simple.AutoMapViewModel.DAL.ViewModel;

namespace Simple.AutoMapViewModel
{
    public class AccountMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Account, AccountTwViewModel>()
                    .ForMember(target => target.帳號, option => option.MapFrom(source => source.UserId))
                    .ForMember(target => target.密碼, option => option.MapFrom(source => source.Password));

            Mapper.CreateMap<AccountTwViewModel, Account>()
                         .ForMember(target => target.UserId, option => option.MapFrom(source => source.帳號))
                         .ForMember(target => target.Password, option => option.MapFrom(source => source.密碼));
        }
    }
}
