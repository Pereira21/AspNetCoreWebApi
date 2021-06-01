using AutoMapper;
using Mundo.Api.Models;
using Mundo.Api.Models.Pets;
using Mundo.Business.Entities;
using Mundo.Business.Entity;

namespace Mundo.Api.Configurations
{
    public class AutoMapperConfig : Profile 
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePessoaViewModel, Pessoa>();
            CreateMap<EditPessoaViewModel, Pessoa>()
                .ForMember(dest => dest._Insert, opt => opt.Ignore());

            CreateMap<CreatePetViewModel, Pet>();
            CreateMap<EditPetViewModel, Pet>()
                .ForMember(dest => dest._Insert, opt => opt.Ignore());
        }
    }
}
