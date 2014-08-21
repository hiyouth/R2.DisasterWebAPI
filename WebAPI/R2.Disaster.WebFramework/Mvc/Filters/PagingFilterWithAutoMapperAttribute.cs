using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace R2.Disaster.WebFramework.Mvc.Filters
{
    /// <summary>
    /// 分页过滤器，可以按照分页条件将实体集合分页，并且可以使用AutoMapper将实体向DTO转化
    /// </summary>
        public class PagingFilterWithMapperAttribute : ActionFilterAttribute
        {
            private Type _sourceType;
            private Type _desType;
            
            public PagingFilterWithMapperAttribute(Type sourceType, Type DesType)
            {
                this._sourceType = sourceType;
                this._desType = DesType;
            }



            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                base.OnActionExecuted(actionExecutedContext);
                int ps;
                int pn;
                String psString;
                String pnString;
                psString = actionExecutedContext.ActionContext.ActionArguments["ps"].ToString();
                pnString = actionExecutedContext.ActionContext.ActionArguments["pn"].ToString();
                ps = Int32.Parse(psString);
                pn = Int32.Parse(pnString);
                IQueryable<Object> query;

                actionExecutedContext.Response.TryGetContentValue(out query);

                int totalCount = query.Count();

                IQueryable<Object> pagingQuery = query.Skip(ps * (pn - 1)).Take(ps).Select(x => x);

                //Mapper.CreateMap(typeof(PhyGeoDisaster), typeof(PhyGeoDisasterSimplify));

                IList<Object> objects = new List<Object>();
                foreach (var item in pagingQuery)
                {
                    object listModel = Mapper.DynamicMap(item, this._sourceType, this._desType);
                    objects.Add(listModel);
                }

                EntityPagingModel model = new EntityPagingModel()
                {
                    EntityList = objects,
                    PageNumber = pn,
                    PageSize = ps,
                    TotalCount = totalCount
                };
                HttpResponseMessage message = actionExecutedContext.
                    Request.CreateResponse(HttpStatusCode.OK, model);
                actionExecutedContext.Response = message;
            }

            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                base.OnActionExecuting(actionContext);
                //actionContext.Response = actionContext.Response
                //HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            }
        }
    }
