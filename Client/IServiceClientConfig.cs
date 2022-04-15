using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Client
{
    public interface IServiceClientConfig
    {
        string Url { get; set; }
        string Token { get; set; }

    }
}
