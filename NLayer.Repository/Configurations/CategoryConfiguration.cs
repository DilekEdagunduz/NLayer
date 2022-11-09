using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();// 1er 1er artacak
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); // bu alan (nullable olmasın) zorunlu olacak ve boyutu max 50 length olsun
            builder.ToTable("Categories"); //Tablo ismini açık açık yazmak için
        }
    }
}
