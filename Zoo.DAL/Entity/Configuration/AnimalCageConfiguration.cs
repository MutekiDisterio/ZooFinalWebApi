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
    public class AnimalCageConfiguration : IEntityTypeConfiguration<AnimalCage>
    {
        public void Configure(EntityTypeBuilder<AnimalCage> builder)
        {
            builder.ToTable("AnimalsCages");

            builder.HasKey(ac => new { ac.CageId, ac.AnimalId });

            builder.HasOne(ac => ac.Cage)
                .WithMany()
                .HasForeignKey(ac => ac.CageId);

            builder.HasOne(ac => ac.Animal)
                .WithMany()
                .HasForeignKey(ac => ac.AnimalId);
        }
    }

}
