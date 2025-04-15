﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryServiceHistoryConfiguration : IEntityTypeConfiguration<MilitaryServiceHistory>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceHistory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryServiceHistory");

            builder.Property(e => e.Id).ValueGeneratedNever();
            
            builder.Property(e => e.OfficialRank).HasMaxLength(40);
            builder.Property(e => e.Position).HasMaxLength(40);

            builder.HasOne(d => d.Injunction).WithOne(p => p.MilitaryServiceHistory)
                .HasForeignKey<MilitaryServiceHistory>(d => d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithOne(p => p.MilitaryServiceHistory)
                .HasForeignKey<MilitaryServiceHistory>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
