using AutoMapper;
using Newtonsoft.Json;
using R2.Disaster.CoreEntities;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace R2.Disaster.WebAPI.Controllers.GeoDisaster
{
    /// <summary>
    /// 地质灾害综合信息服务
    /// </summary>
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
        /// <param name="uid">统一编号</param>
        /// <returns>地质灾害完整信息</returns>
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
        /// 通过关键字检索灾害点，关键字将检索灾害点名称、灾害点地理位置、统一编号
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IList<ComprehensiveModel> GetByKeyWord(string keyWord)
        {
            if (String.IsNullOrEmpty(keyWord))
                throw new Exception("查询的关键字不允许是类型“null”或者空字符串");
            
        }

        /// <summary>
        /// 通过主键编号精准查询唯一的灾害点综合信息（完整）
        /// </summary>
        /// <param name="id">灾害点唯一编号</param>
        /// <returns>灾害点完整信息</returns>
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
        /// <param name="type">灾害类型: 01泥石流；02地面塌陷；04地裂缝；08滑坡；16崩塌；32地面沉降；64滑坡</param>
        /// <param name="gbcode">行政区编码</param>
        /// <param name="dangerLev">险情级别</param>
        /// <param name="situationLev">灾情级别</param>
        /// <returns></returns>
        //通过行政区编码、灾害类型、险情大小、灾情大小进行查询
        // api/geodisaster/getbymulityplyconditions?type=&gbcode=&dangerlev=&situationlev=
        public IList<ComprehensiveModel> GetByMulityplyConditions(EnumGeoDisasterType? type=null,string gbcode=null,
            string dangerLev=null,string situationLev=null)
        {
            IQueryable<Comprehensive> comprehensives =
                this._cpsService.GetByMultiplyContions(gbcode, situationLev, dangerLev, type);
            IList<ComprehensiveModel> models = new List<ComprehensiveModel>();
            Mapper.CreateMap<Comprehensive, ComprehensiveModel>();
            foreach (var item in comprehensives)
            {
                ComprehensiveModel model = Mapper.Map<Comprehensive, ComprehensiveModel>(item);
                models.Add(model);
            }
            return models;
        }

        public IList<Comprehensive> GetByKeyWord(string key)
        {
            return null;
        }

        public void New(Comprehensive ghc)
        {
        }
    }
}
