﻿using R2.Disaster.CoreEntities.Domain.Investigation;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2.Disaster.Data.Mapping.DisasterInvestigation
{
    public class GHLandSlipMap : EntityTypeConfiguration<GHLandSlip>
    {
        public GHLandSlipMap()
        {
            this.ToTable("GHLandSlips");
            this.HasKey(c => c.Id);

            this.Property(c => c.统一编号).IsRequired();
            this.Property(c => c.名称).IsRequired();

            this.HasRequired(c => c.GHComprehensive)
                .WithRequiredDependent(c => c.GHLandSlip);
        }
    }
}
