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
    public class RotinaDisparoConfiguration : IEntityTypeConfiguration<RotinaDisparo>
    {
        public void Configure(EntityTypeBuilder<RotinaDisparo> builder)
        {
            builder.ToTable("RotinaDisparo");
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.Intervalo).HasColumnName("Intervalo");
            builder.Property(x => x.TipoIntervalo).HasColumnName("TipoIntervalo");
            builder.Property(x => x.DataCadastro).HasColumnName("DataCadastro");
        }
    }
}
