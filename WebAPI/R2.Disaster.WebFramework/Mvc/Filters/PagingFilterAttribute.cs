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
using AutoMapper;
using R2.Disaster.WebAPI.ServiceModel;

namespace R2.Disaster.WebFramework.Mvc.Filters
{
    /// <summary>
    /// 分页过滤器，可以按照分页条件将实体集合分页
    /// </summary>
    public class PagingFilterAttribute : ActionFilterAttribute
    {
        public String PageSizeName 
        {
            get
            {
                return this._pageSizeName;
            }
            set
            {
                this._pageSizeName = value;
            }
        }

        public String PageNumberName
        {
            get
            {
                return this._pageNumberName;
            }
            set
            {
                this._pageNumberName = value;
            }
        }

        private String _pageSizeName = "ps";
        private String _pageNumberName = "pn";

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            int ps;
            int pn;
            String  psString = actionExecutedContext.ActionContext.ActionArguments[PageSizeName].ToString();
            String  pnString = actionExecutedContext.ActionContext.ActionArguments[PageNumberName].ToString();
            ps = Int32.Parse(psString);
            pn = Int32.Parse(pnString);

            Object content;

            actionExecutedContext.Response.TryGetContentValue(out content);

            EntityPagingModel model = null;
            if (content is IEnumerable<Object>)
            {
                IEnumerable<Object> query = content as IEnumerable<Object>;
                IEnumerable<Object> pagingQuery = query.Skip(ps * (pn - 1)).Take(ps).Select(x => x);
                int totalCount = query.Count();
                model = new EntityPagingModel()
                 {
                     EntityList = pagingQuery.ToList(),
                     PageNumber = pn,
                     PageSize = ps,
                     TotalCount = totalCount
                 };
            }
            HttpResponseMessage message = actionExecutedContext.
                Request.CreateResponse(HttpStatusCode.OK, model);
            actionExecutedContext.Response = message;
        }
    }

    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute     
    {        
        public override void OnException(HttpActionExecutedContext context)      
        {         
            if (context.Exception is NotImplementedException)         
            {               
                //context.Response = new HttpResponseMessage(HttpStatusCode.OK);
                HttpResponseMessage message=context.Request.CreateResponse(HttpStatusCode.OK, "ddddd");
                context.Response = message;
            }       
        } 
    } 
}
