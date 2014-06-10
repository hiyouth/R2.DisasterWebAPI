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
    public class PhyGeoDisasterMap : EntityTypeConfiguration<PhyGeoDisaster>
    {
        public PhyGeoDisasterMap()
        {
            this.ToTable("PhyGeoDisasters");
            this.HasKey(p => p.Id);

            //this.Property(c => c.名称).IsRequired();
            this.Property(c => c.灾害类型).IsRequired();
            this.Property(c => c.地理位置).IsRequired();

            //配置同GBCode的关系
            this.HasRequired(c => c.GBCode)
             .WithMany().HasForeignKey(g => g.GBCodeId);

              //配置同Comprehensive综合表的关系
            this.HasRequired(p => p.Comprehensive)
                .WithRequiredPrincipal(c => c.PhyGeoDisaster);



            //配置一对多关系，既可以在一方配置，也可以在另外一方配置
            this.HasMany(p => p.DamageReports)
                .WithRequired(d => d.PhyGeoDisaster)
                .HasForeignKey(d=>d.PhyGeoDisasterId);

            this.HasMany(p => p.EmergencySurveys)
                .WithRequired(e => e.PhyGeoDisaster)
                 .HasForeignKey(e => e.PhyGeoDisasterId);
        }
    }
}
