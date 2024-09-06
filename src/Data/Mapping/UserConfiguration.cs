using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.ToTable("users");
    }
}
