<<<<<<< HEAD:CmsConfeitaria.Integration/ViewModels/ReceitaOutput.cs
﻿using CmsConfeitaria.Core.Entity;
using Microsoft.AspNetCore.Http;
using System;
=======
﻿using System;
>>>>>>> ace6998ca0dae0047ecbf6a867f07d3e0d446c0b:CmsConfeitaria.Integration/ViewModels/Outputs/ReceitaOutput.cs
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsConfeitaria.Integration.ViewModels.Outputs
{
    public class ReceitaOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string ModoPreparo { get; set; }
        public IFormFile? File { get; set; }
    }
}
