﻿using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T:BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.SoftDelete).HasDefaultValue(false);
            builder.Property(e => e.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
