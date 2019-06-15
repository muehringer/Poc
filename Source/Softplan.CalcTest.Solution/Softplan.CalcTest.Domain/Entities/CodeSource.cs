using Softplan.CalcTest.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Domain.Entities
{
    public class CodeSource
    {
        public string URLGitHub { get; set; }

        public CodeSource()
            => this.URLGitHub = ShowMeTheCodeConst.URLGITHUB;
    }
}
