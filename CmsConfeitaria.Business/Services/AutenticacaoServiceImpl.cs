using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Integration;
using CmsConfeitaria.Integration.ViewModels.Inputs;
using CmsConfeitaria.Integration.ViewModels.Outputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Business.Services
{
    public class AutenticacaoServiceImpl : AutenticacaoService
    {
        private readonly DBContextCm _context;
        public AutenticacaoServiceImpl(DBContextCm context)
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
                throw new CmsException("Usuario ou senha incorreto");
        }
    }
}
