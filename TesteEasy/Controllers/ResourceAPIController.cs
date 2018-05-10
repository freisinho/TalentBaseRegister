using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TesteEasy.App_LocalResources;
using TesteEasy.Models.Dto;

namespace TesteEasy.Controllers
{
    public class ResourceApiController : ApiController
    {
        [HttpGet]
        [Route("api/accessresources/{culture}")]
        public IHttpActionResult GetResourceStringsFromResources(string culture)
        {
            ResourceSet resources;
            if (culture == "pt-BR" || culture == "en-US")
                resources = Localization.ResourceManager.GetResourceSet(new CultureInfo(culture), true, true);
            else
                resources = Localization.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            var resDictionary = new Dictionary<string, string>();

            foreach (DictionaryEntry resource in resources)
                resDictionary.Add(resource.Key.ToString(), resource.Value.ToString());

            return Ok(resDictionary);
        }

        public IHttpActionResult GetResources(string culture)
        {
            ResourceSet resources;
            if (culture == "pt-BR" || culture == "en-US")
                resources = Localization.ResourceManager.GetResourceSet(new CultureInfo(culture), true, true);
            else
                resources = Localization.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            var resDictionary = new Dictionary<string, string>();

            foreach (DictionaryEntry resource in resources)
                resDictionary.Add(resource.Key.ToString(), resource.Value.ToString());

            return Ok(resDictionary);
        }
    }
}