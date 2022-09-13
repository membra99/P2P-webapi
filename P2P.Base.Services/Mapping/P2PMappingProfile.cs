using AutoMapper;
using Entities.P2P.MainData;
using P2P.DTO.Input;
using P2P.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.Base.Services.Mapping
{
    public class P2PMappingProfile : Profile
    {

        public P2PMappingProfile()
        {
            #region MainData

            CreateMap<Testimonial, TestimonialODTO>()
                 .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
            CreateMap<TestimonialIDTO, Testimonial>();

            CreateMap<Language, LanguageODTO>();
            CreateMap<LanguageIDTO, Language>();

            CreateMap<ReviewAttribute, ReviewAttributeODTO>();
            CreateMap<ReviewAttributeIDTO, ReviewAttribute>();
            #endregion
        }
    }
}
