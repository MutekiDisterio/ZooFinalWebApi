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
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.ToTable("AnimalTypes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.AnimalTypeName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }

}
