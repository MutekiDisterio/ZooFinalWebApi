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
    public class VolunteersDepartmentConfiguration : IEntityTypeConfiguration<VolunteerDepartment>
    {
        public void Configure(EntityTypeBuilder<VolunteerDepartment> builder)
        {
            builder.ToTable("VolunteersDepartment");

            builder.HasKey(vd => vd.Id);

            builder.Property(vd => vd.DepartmentName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }

}
