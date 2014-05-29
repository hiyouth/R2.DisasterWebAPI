﻿using R2.Disaster.CoreEntities.Domain.GeoDisaster.Investigation;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Data.Mapping.GeoDisaster.Investigation
{
    public class ComprehensiveMap : EntityTypeConfiguration<Comprehensive>
    {
        public ComprehensiveMap()
        {
            this.ToTable("Comprehensives");
            this.HasKey(c => c.Id);

            this.Property(c => c.名称).IsRequired();
            this.Property(c => c.灾害类型).IsRequired();
            this.Property(c => c.地理位置).IsRequired();

            this.HasRequired(c => c.GBCode)
           .WithMany().HasForeignKey(g => g.GBCodeId);

            //配置一对多关系，既可以在一方配置，也可以在另外一方配置
            this.HasMany(c => c.DamageReports)
                .WithRequired(d => d.Comprehensive)
                .HasForeignKey(d=>d.ComprehensiveId);
        }
    }
}
