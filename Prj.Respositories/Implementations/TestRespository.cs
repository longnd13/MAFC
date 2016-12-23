using Prj.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Implementations
{
   public class TestRespository : ITestRespository
    {

        public string AlertMessage()
        {
            return "ok";
        }
    }
}
