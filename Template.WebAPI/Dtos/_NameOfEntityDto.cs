using AutoMapper;
using Template.Application.Common.Mappings;
using Template.Application.Features._NameOfEntity_.Commands;

namespace Template.WebAPI.Dtos
{
    public class _NameOfEntityDto_: IMapWith<Create_NameOfEntity_Command>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<_NameOfEntityDto_, Create_NameOfEntity_Command>()
                .ForMember(x => x.Name, opt
                    => opt.MapFrom(dto => dto.Name));
        }
    }
}
