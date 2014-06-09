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
            Mapper.CreateMap<Comprehensive, ComprehensiveModel>();
            Mapper.CreateMap<ComprehensiveModel, Comprehensive>();
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
        /// 通过统一编号查询灾害点完整综合信息，（不建议调用）
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
        /// 通过关键字检索灾害点简要信息，关键字将检索灾害点名称、灾害点地理位置、统一编号
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <returns>符合条件的实体信息</returns>
        public IList<ComprehensiveModel> GetByKeyWord(string keyWord)
        {
            if (String.IsNullOrEmpty(keyWord))
                throw new Exception("查询的关键字不允许是类型“null”或者空字符串");
            IQueryable<Comprehensive> comprehensives = this._cpsService.GetByKeyWord(keyWord);
            IList<ComprehensiveModel> cpsModels =Mapper.Map<IQueryable<Comprehensive>,
                IList<ComprehensiveModel>>(comprehensives);
            return cpsModels;
        }

        /// <summary>
        /// 空间“圆”查询
        /// </summary>
        /// <param name="x">圆心X</param>
        /// <param name="y">圆心Y</param>
        /// <param name="radius">半径</param>
        /// <returns>符合条件的实体信息</returns>
        public IList<ComprehensiveModel> GetByCircle(double x, double y, double radius)
        {
            IQueryable<Comprehensive> comprehensives = this._cpsService.GetByCircle(
                x, y, radius);
            IList<ComprehensiveModel> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
                IList<ComprehensiveModel>>(comprehensives);
            return cpsModels;
        }

        /// <summary>
        /// 空间“矩形”查询
        /// </summary>
        /// <param name="x1">矩形左下角点X</param>
        /// <param name="x2">矩形右上角X</param>
        /// <param name="y1">矩形左下角Y</param>
        /// <param name="y2">矩形右上角Y</param>
        /// <returns>符合条件的实体信息</returns>
        public IList<ComprehensiveModel> GetByRect(double x1, double x2, double y1, double y2)
        {
            IQueryable<Comprehensive> comprehensives = this._cpsService.GetByRect(
                x1, x2, y1, y2);
            IList<ComprehensiveModel> cpsModels = Mapper.Map<IQueryable<Comprehensive>,
                IList<ComprehensiveModel>>(comprehensives);
            return cpsModels;
        }

        /// <summary>
        /// 通过主键编号精准查询唯一的灾害点完整信息（一个完整的灾害点实体，可能包含众多信息，不建议调用）
        /// 请根据业务调用具体实体
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
        /// 通过行政区编码、灾害类型、险情大小、灾情大小查询灾害点简要信息
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
            foreach (var item in comprehensives)
            {
                ComprehensiveModel model = Mapper.Map<Comprehensive, ComprehensiveModel>(item);
                models.Add(model);
            }
            return models;
        }

        /// <summary>
        /// 新增地质灾害实体
        /// </summary>
        /// <param name="ghc">地质灾害实体</param>
        public void New(Comprehensive comprehensive)
        {
            this._cpsService.New(comprehensive);
        }

        /// <summary>
        /// 新增一个只包含简要信息的地质灾害实体
        /// </summary>
        /// <param name="ghcm"></param>
        public void NewSimplify(ComprehensiveModel comprehensiveModel)
        {

        }
    }
}
