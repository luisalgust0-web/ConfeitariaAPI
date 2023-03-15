using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels
{
    public class AutenticacaoOutput
    {
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime Hora { get; set; }
    }
}
