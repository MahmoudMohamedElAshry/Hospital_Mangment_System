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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
           // by Default
           //builder.HasKey(r => r.ID);
		   //builder.Property(r => r.Type).IsRequired().HasMaxLength(50);
           //builder.Property(r => r.Availability).IsRequired();
            
        }
    }
}
