using AutoMapper;
using R2.Disaster.WebAPI.ServiceModel;
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
        public class PagingFilterWithMapperAttribute :PagingFilterAttribute
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

                EntityPagingModel pagingModel;

                actionExecutedContext.Response.TryGetContentValue(out pagingModel);

                IList<Object> objects = new List<Object>();
                foreach (var item in pagingModel.EntityList)
                {
                    object listModel = Mapper.DynamicMap(item, this._sourceType, this._desType);
                    objects.Add(listModel);
                }

                pagingModel.EntityList = objects;
                HttpResponseMessage message = actionExecutedContext.
                    Request.CreateResponse(HttpStatusCode.OK, pagingModel);
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
