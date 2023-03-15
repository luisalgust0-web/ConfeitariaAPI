using CmsConfeitaria.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.Configuration
{
    public class ImagemReceitaConfiguration : IEntityTypeConfiguration<ImagemReceita>
    {
        public void Configure(EntityTypeBuilder<ImagemReceita> builder)
        {
            builder.ToTable("ImagemReceita");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Imagem).HasColumnName("Imagem");
            builder.Property(x => x.Receita).HasColumnName("Receita");

            builder.HasOne(s => s.Receita).WithOne(s => s.ImagemReceita).HasForeignKey("ReceitaId");
        }
    }
}
