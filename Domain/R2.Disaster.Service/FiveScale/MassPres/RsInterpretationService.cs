using R2.Disaster.CoreEntities.Domain.FiveScale.MassPres;
using R2.Disaster.Repository;


namespace R2.Disaster.Service.GeoDisaster.MassPres
{
    public class RsInterpretationService : PhyRelationEntityService<RsInterpretation>, IRsInterpretationService
    {
        public RsInterpretationService(IRepository<RsInterpretation> repository)
            : base(repository)
        {
        }

        //public IQueryable<RsInterpretation> GetByUId(string uid)
        //{
        //    var query = from c in this._repository.Table
        //                where c.统一编号 == uid
        //                select c;
        //    return query;
        //}
    }
}
