using AutoMapper;
using Domain.ObjectState;
using ServiceModel.ObjectState;

namespace WebApi;

public class MappingProfiles : Profile
{
    public MappingProfiles() {
            CreateMap<ObjectState, ObjectStateContract>();
        }
}