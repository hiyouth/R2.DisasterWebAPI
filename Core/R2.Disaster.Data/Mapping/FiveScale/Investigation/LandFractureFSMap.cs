
using R2.Disaster.CoreEntities.Domain.FiveScale.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System.Data.Entity.ModelConfiguration;

namespace R2.Disaster.Data.Mapping.GeoDisaster.Investigation
{
    public class LandFractureFSMap : EntityTypeConfiguration<LandFractureFS>
    {
        public LandFractureFSMap()
        {
            this.ToTable("LandFractureFSes");
            this.HasKey(c => c.Id);

            //this.Property(c => c.统一编号).IsRequired();
            //this.Property(c => c.名称).IsRequired();

            //this.HasRequired(c => c.Comprehensive)
            //    .WithRequiredDependent(c => c.LandFracture);
        }
    }
}
