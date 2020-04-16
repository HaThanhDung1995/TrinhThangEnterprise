using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebEnterprise_2.Models;
using WebEnterprise_2.Models.ViewModel;

namespace WebEnterprise_2.AutoMapperConfig
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Report, SubReport>().ForMember(x => x.StudentId, y => y.MapFrom(a => a.Student.Fullname))
                .ForMember(x => x.TutorId, y => y.MapFrom(a => a.Turtor.Fullname));
            CreateMap<SubReport, Report>();
        }
    }
}