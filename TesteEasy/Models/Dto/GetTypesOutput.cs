using System.Collections.Generic;

namespace TesteEasy.Models.Dto
{
    public class GetTypesOutput
    {
        public List<GetTypesItem> TimesToWork { get; set; }
        public List<GetTypesItem> Willingness { get; set; }
        public List<GetTypesItem> AccountTypes { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
    }
}