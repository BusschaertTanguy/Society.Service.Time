using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Mappings
{
    public class UniverseMapping : BaseMapping<Universe>
    {
        protected override void ConfigureMapping(EntityTypeBuilder<Universe> builder)
        {
            builder
                .Property<DateTime>("_currentTime")
                .HasColumnName("CurrentTime")
                .IsRequired();
        }
    }
}