using CmsConfeitaria.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.Configuration
{
    public class TemplateEmailConfiguration : IEntityTypeConfiguration<TemplateEmail>
    {
        public void Configure(EntityTypeBuilder<TemplateEmail> builder)
        {
            builder.ToTable("TemplateEmail");
            builder.HasKey("Id");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.Titulo).HasColumnName("Titulo");
            builder.Property(x => x.Conteudo).HasColumnName("Conteudo");
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro");
        }
    }
}
