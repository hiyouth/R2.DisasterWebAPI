using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;

namespace R2.Disaster.WebFramework.Mvc.Filter
{
    public class TestFilterAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            //actionContext.Response = actionContext.Response
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            //OK
        }
    }

    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute     
    {        
        public override void OnException(HttpActionExecutedContext context)      
        {         
            if (context.Exception is NotImplementedException)         
            {               
                context.Response = new HttpResponseMessage(HttpStatusCode.OK);              
            }       
        } 
    } 
}
