using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
   public class PermissionModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
    }
}
