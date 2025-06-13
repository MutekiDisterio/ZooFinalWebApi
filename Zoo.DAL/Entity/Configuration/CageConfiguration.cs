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
    public class CageConfiguration : IEntityTypeConfiguration<Cage>
    {
        public void Configure(EntityTypeBuilder<Cage> builder)
        {
            builder.ToTable("Cages");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.AnimalType)
                .WithMany()
                .HasForeignKey(c => c.AnimalTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
