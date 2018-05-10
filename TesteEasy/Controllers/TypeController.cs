using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TesteEasy.Models;
using TesteEasy.Models.Dto;
using TesteEasy.Models.Enums;

namespace TesteEasy.Controllers
{
    public class TypeController : ApiController
    {
        // GET: api/Type
        public async Task<GetTypesOutput> Get()
        {
            var context = new CandidateDbSet();

            var timeNames = Enum.GetNames(typeof(TimeToWorkOptions));

            var timeDisplayNames = EnumHelper<TimeToWorkOptions>.GetDisplayValues(TimeToWorkOptions.Afternoon);

            var willingnessNames = Enum.GetNames(typeof(WillingnessOptions));

            var willingnessDisplayNames = EnumHelper<WillingnessOptions>.GetDisplayValues(WillingnessOptions.FourToSix);

            var accountsName = Enum.GetNames(typeof(AccountType));

            var timesType = new List<GetTypesItem>();

            var accountType = new List<GetTypesItem>();

            var willingnessType = new List<GetTypesItem>();

            var tec = context.Technologies.AsNoTracking();

            var technologiesOne = await (from a in tec
                select new
                {
                    a.Id,
                    a.Name
                }).ToListAsync();

            var technologies = Mapper.Map<List<TechnologyDto>>(technologiesOne);

            for (var cont = 0; cont < timeNames.Length; cont++)
                timesType.Add(new GetTypesItem
                {
                    Name = timeNames[cont],
                    Text = timeDisplayNames[cont],
                    Id = cont + 1
                });

            for (var cont = 0; cont < accountsName.Length; cont++)
                accountType.Add(new GetTypesItem
                {
                    Name = accountsName[cont],
                    Id = cont + 1
                });

            for (var cont = 0; cont < willingnessNames.Length; cont++)
                willingnessType.Add(new GetTypesItem
                {
                    Name = willingnessNames[cont],
                    Text = willingnessDisplayNames[cont],
                    Id = cont + 1
                });

            var types = new GetTypesOutput
            {
                TimesToWork = timesType,
                Willingness = willingnessType,
                AccountTypes = accountType,
                Technologies = technologies
            };

            return types;
        }
    }
}