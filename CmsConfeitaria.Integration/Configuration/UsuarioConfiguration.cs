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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Senha).HasColumnName("Senha");
            builder.Property(x => x.NomeUsuario).HasColumnName("NomeUsuario");
            builder.Property(x => x.Apelido).HasColumnName("Apelido");

            builder.HasMany(x => x.Ingredientes).WithOne(x => x.Usuario).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Receitas).WithOne(x => x.user).HasForeignKey(x => x.UserId);
            //builder.HasMany(x => x.compraIngredientes).WithOne(x => x.).HasForeignKey(x => x.UserId);
        }
    }
}
