using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchman.Api.Models.Requests;
using Watchman.Api.Models.Responses;

namespace Watchman.Api.MappingProfiles {

  public class SecurityProfile : Profile {

    public SecurityProfile() {
      CreateMap<RegisterRequest, Domain.Requests.RegisterRequest>()
          .ReverseMap();
      CreateMap<LoginRequest, Domain.Requests.LoginRequest>()
               .ReverseMap();
      CreateMap<UserManagerResponse, Domain.Responses.UserManagerResponse>()
                .ReverseMap();
    }
  }
}