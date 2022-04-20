using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srms_orchestration_service.Dto.EventsService
{
    public class FactDto
    {

        public string FieldName { get; set; }

        public string FieldType { get; set; }

        [JsonProperty("category")]
        public string FactCategory { get; set; }

        public string[] Value { get; set; }
    }
}
