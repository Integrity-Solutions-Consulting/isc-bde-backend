using AutoMapper;
using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEntity = isc.bempleo.be.domain.Entity.Profiles.Profile;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile() 
        {

            CreateMap<ProfileEntity, ProfileResponse>();
            CreateMap<ProfileResponse, ProfileEntity>();

            CreateMap<Knowledge, KnowledgeResponse>();
            CreateMap<KnowledgeResponse, Knowledge>();

            CreateMap<ProfileEntity, PersonalDataRequest>();
            CreateMap<PersonalDataRequest, ProfileEntity>();

            CreateMap<ProfileEntity, FormationRequest>();
            CreateMap<FormationRequest, ProfileEntity>();

            CreateMap<Knowledge, KnowledgeRequest>();
            CreateMap<KnowledgeRequest, Knowledge>();


            CreateMap<KnowledgeRequest, Knowledge>();
            CreateMap<Knowledge, KnowledgeResponse>();



        }
    }
}
