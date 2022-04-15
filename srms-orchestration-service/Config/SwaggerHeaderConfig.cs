using Microsoft.OpenApi.Models;
using srms_orchestration_service.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace srms_orchestration_service.Config
{
    public class SwaggerHeaderConfig : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HeaderNames.USER_ID,
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
