using Newtonsoft.Json;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Service.GeoDisaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster
{
    public class GeoDisasterController:ApiController
    {
        private IComprehensiveService _cpsService;
        public GeoDisasterController(IComprehensiveService cpsService)
        {
            this._cpsService = cpsService;
        }

        public GeoDisasterController()
        {

        }

        //public List<Comprehensive> GetAll()
        //{
        //    return null;
        //}

        [HttpGet]
        public Book GetBook(string uid)
        {
            Book book = new Book()
            {
                Id = 3,
                Name = "333",
                Price = 5,
                Category = new Category()
                {
                    Id=8,
                   Name="32323" 
                }
            };
            return book;
        }

        /// <summary>
        /// 通过统一编号查询灾害点综合信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IList<Comprehensive> GetByUIdCompletely (string uid)
        {
            if (String.IsNullOrEmpty(uid))
                throw new Exception("灾害点的统一编号不能为Null或者空字符串");
            IQueryable<Comprehensive> g=_cpsService.GetSimilarByUnifiedId(uid);
           
            //JsonSerializerSettings a = new JsonSerializerSettings();
            //a.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //string s = JsonConvert.SerializeObject(g, a);
            return g.ToList();
        }

        /// <summary>
        /// 通过主键编号精准查询唯一的灾害点综合信息（完整）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Comprehensive GetByIdCompletely(int id)
        {
            if (id <= 0)
                throw new Exception("不存在这样的灾害点信息主键编号");
           Comprehensive g = _cpsService.GetById(id);
           return g;
        }

        /// <summary>
        /// 通过行政区编码、灾害类型、险情大小、灾情大小进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Comprehensive GetByMulityplyConditions(int id)
        {
            throw new NotImplementedException();
        }

        public void New(Comprehensive ghc)
        {
        }
    }
}
