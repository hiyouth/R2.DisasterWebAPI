using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Relocation;
using R2.Disaster.Repository;

namespace R2.Disaster.Service.GeoDisaster.Relocation
{
    public class RelocationPlaceEvaluationService : PhyRelationEntityService<RelocationPlaceEvaluation>,
        IRelocationPlaceEvaluationService
    {
        private IRepository<RelocationPlaceEvaluation> _repositoryEvaluation;


        public RelocationPlaceEvaluationService(IRepository<RelocationPlaceEvaluation> repositoryEvaluation)
            : base(repositoryEvaluation)
        {
            this._repositoryEvaluation = repositoryEvaluation;
        }
    }
}
