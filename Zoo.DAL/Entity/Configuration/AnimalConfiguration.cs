using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.DAL.Entity;


namespace Zoo.DAL.Entity.Configuration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.BirthDate)
                .IsRequired();

            builder.HasOne(a => a.Owner)
                .WithMany()
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.AnimalType)
                .WithMany()
                .HasForeignKey(a => a.AnimalTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
