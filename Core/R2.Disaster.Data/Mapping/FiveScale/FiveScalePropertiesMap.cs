using R2.Disaster.CoreEntities.Domain.FiveScale;
using R2.Disaster.CoreEntities.Domain.GeoDisaster;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Data.Mapping.GeoDisaster
{
    public class FiveScalePropertyMap : EntityTypeConfiguration<FiveScaleProperty>
    {
        public FiveScalePropertyMap()
        {
            this.ToTable("FiveScaleProperies");
            this.HasKey(p => p.Id);

            this.HasMany(f=>f.ComprehensiveFSes)
           .WithRequired(c => c.FiveScaleProerties)
           .HasForeignKey(c => c.FiveScalePropertyId);

            this.HasMany(f => f.AvoidRiskCardFSes)
.WithRequired(a => a.FiveScaleProerties)
.HasForeignKey(c => c.FiveScalePropertyId);

            this.HasMany(f => f.PrePlanFSes)
.WithRequired(c => c.FiveScaleProerties)
.HasForeignKey(c => c.FiveScalePropertyId);

            this.HasMany(f => f.WorkingGuideCardFSes)
.WithRequired(c => c.FiveScaleProerties)
.HasForeignKey(c => c.FiveScalePropertyId);
        }
    }
}
