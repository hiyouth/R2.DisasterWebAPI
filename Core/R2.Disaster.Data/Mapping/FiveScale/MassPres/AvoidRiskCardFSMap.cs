
using R2.Disaster.CoreEntities.Domain.FiveScale.MassPres;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Data.Mapping.GeoDisaster.MassPres
{
    public class AvoidRiskCardFSMap : EntityTypeConfiguration<AvoidRiskCardFS>
    {
        public AvoidRiskCardFSMap()
        {
            this.ToTable("AvoidRiskCardFSes");
            this.HasKey(c => c.Id);

            //this.Property(c => c.统一编号).IsRequired();
            this.Property(c => c.名称).IsRequired();

            //this.HasRequired(a => a.PhyGeoDisaster)
            //   .WithMany(p => p.AvoidRiskCards)
            //   .HasForeignKey(a => a.PhyGeoDisasterId);
        }
    }
}
