using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PharmaCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PharmaCoreApi.Helper
{
    public static class ExtensionHelper
    {
        public static string GetQueryString(this Dictionary<string, string> querystringParams)
        {
            string valueString = string.Empty;
            Int16 valueInt = 0;
            string paramvalue = string.Empty;
            List<string> paramList = new List<string>();
            foreach (var parameter in querystringParams)
            {
                if (Int16.TryParse(parameter.Value, out valueInt))
                    paramvalue = parameter.Value;
                else
                    paramvalue = '"' + HttpUtility.UrlDecode(parameter.Value) + '"';
                               
                   paramList.Add(parameter.Key + '=' + paramvalue);
            }
            return "?" + string.Join("&", paramList);
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, NLog.ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
