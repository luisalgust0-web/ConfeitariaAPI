using CmsConfeitaria.Business.Interfaces;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business
{
    public class AutenticacaoService : IAutenticacaoServie
    {
        private readonly DBContextCm _context;
        public AutenticacaoService(DBContextCm context)
        {
            _context = context;
        }
        public AutenticacaoOutput EstaAutenticado(AutenticacaoInput input)
        {
            var autUsuario = _context.Usuarios.Where(x => x.LoginNome == input.Usuario && x.Senha == input.Senha).FirstOrDefault();

            if (autUsuario != null)
            {
                AutenticacaoOutput model = new AutenticacaoOutput() { Hora = DateTime.Now.AddMinutes(30), Password = autUsuario.Senha, User = autUsuario.LoginNome };

                return model;
            }
            else
                return null;
        }
    }
}
