using AutoMapper;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TesteEasy.Models.Dto;
using TesteEasy.Models.Entities;

namespace TesteEasy
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<List<object>, List<GetCandidatesDto>>();
                cfg.CreateMap<List<object>, List<CandidateKnowledgeDto>>();
                cfg.CreateMap<Technology, TechnologyDto>();
                cfg.CreateMap<Candidate, CandidateDto>().ForMember(y => y.CandidateKnowledge, opt => opt.Ignore());
                cfg.CreateMap<object, CandidateDto>();
                cfg.CreateMap<List<object>, List<TechnologyDto>>();
            });
        }


    }
}
