using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;

namespace R2.Disaster.Data.Mapping.GeoDisaster.MassPres
{
    public class PreventionPlanningMap : EntityTypeConfiguration<PreventionPlanning>
    {

        public PreventionPlanningMap()
        {
            this.ToTable("PreventionPlannings");
            this.HasKey(c => c.Id);
        }
    }
}
