using R2.Disaster.CoreEntities.Domain.Investigation;
using System.Data.Entity.ModelConfiguration;

namespace R2.Disaster.Data.Mapping.DisasterInvestigation
{
    public class GHLandFractureMap : EntityTypeConfiguration<GHLandFracture>
    {
        public GHLandFractureMap()
        {
            this.ToTable("GHLandFractures");
            this.HasKey(c => c.Id);

            this.Property(c => c.统一编号).IsRequired();
            this.Property(c => c.名称).IsRequired();

            this.HasRequired(c => c.GHComprehensive)
                .WithRequiredDependent(c => c.GHLandFracture);
        }
    }
}
