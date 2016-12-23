using Prj.BusinessLogic.Interfaces;
using Prj.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Implementations
{
   public class TestService : ITestService
    {
        private ITestRespository _testRespo;

        public TestService(ITestRespository testRespo)
        {
            _testRespo = testRespo;
        }
        public string AlertMessage()
        {
            string result = "nook";
            try
            {
                result = _testRespo.AlertMessage();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }
    }
}
