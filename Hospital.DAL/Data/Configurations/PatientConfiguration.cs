using Hospital.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            //Will Happen by Default
            // Relationships
            //builder.HasKey(p => p.ID);

            //builder.HasMany(p => p.Bills)
            //       .WithOne(b => b.Doctor)
            //       .HasForeignKey(b => b.DoctorID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p => p.Doctor)
            //       .WithMany(d => d.Doctors)
            //       .HasForeignKey(p => p.DoctorId)
            //       .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(p => p.TestReports)
            //       .WithOne(tr => tr.Doctor)
            //       .HasForeignKey(tr => tr.DoctorID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(p => p.Room)
            //       .WithMany(r => r.Doctor)
            //       .HasForeignKey<Doctor>(r => r.RoomId)
            //       .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
