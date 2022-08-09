using AutoMapper;
using QueueSystem.Models;
using QueueSystem.Resources;

namespace QueueSystem.Helper.Mapping
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<PatientAppointment, PatientAppointmentRespDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(p => p.UserName, opt => opt.MapFrom(x => x.Patient.UserName))
                .ForMember(p => p.FullName, opt => opt.MapFrom(x => x.Patient.FullName))
                .ForMember(p => p.Gender, opt => opt.MapFrom(x => x.Patient.Gender));
        }
    }
}
