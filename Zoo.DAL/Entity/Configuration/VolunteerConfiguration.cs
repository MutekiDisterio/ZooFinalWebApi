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
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("Volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(v => v.Address)
                .HasMaxLength(50);

            builder.HasOne(v => v.Animal)
                .WithMany()
                .HasForeignKey(v => v.AnimalId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(v => v.Department)
                .WithMany()
                .HasForeignKey(v => v.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
