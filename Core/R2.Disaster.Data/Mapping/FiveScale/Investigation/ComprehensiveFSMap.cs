
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2.Disaster.CoreEntities.Domain.FiveScale.Investigation;

namespace R2.Disaster.Data.Mapping.FiveScale.Investigation
{
    public class ComprehensiveFSMap : EntityTypeConfiguration<ComprehensiveFS>
    {
        public ComprehensiveFSMap()
        {
            this.ToTable("ComprehensiveFSes");
            this.HasKey(c => c.Id);

            this.HasRequired(c => c.GBCode)
       .WithMany().HasForeignKey(g => g.GBCodeId);

            this.HasRequired(c => c.DebrisFlowFS).WithRequiredPrincipal();

            this.HasRequired(c => c.LandCollapseFS).WithRequiredPrincipal();

            this.HasRequired(c => c.LandFractureFS).WithRequiredPrincipal();

            this.HasRequired(c => c.LandSlideFS).WithRequiredPrincipal();

            this.HasRequired(c => c.LandSlipFS).WithRequiredPrincipal();

            this.HasRequired(c => c.LandSubsidenceFS).WithRequiredPrincipal();

            this.HasRequired(c => c.SlopeFS).WithRequiredPrincipal();
        }
    }
}
