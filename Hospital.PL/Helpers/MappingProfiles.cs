using AutoMapper;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;

namespace Hospital.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientViewModel, Patient>()
                .ForMember(Gen => Gen.Gender, opt => opt.MapFrom(G => G.Gender.ToString()))
                .ReverseMap();
            CreateMap<BillViewModel, Bill>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
            CreateMap<DoctorViewModel, Doctor>().ReverseMap();
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<NurseViewModel, Nurse>().ReverseMap();
            CreateMap<ReceptionistViewModel, Receptionist>().ReverseMap();
            CreateMap<RoomViewModel, Room>().ReverseMap();
            CreateMap<TestReportViewModel, TestReport>().ReverseMap();
        }
    }
}
