
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
  public class BranchModel : LogsDateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Descrition { get; set; }
        public bool bActived { get; set; }
        public bool bDeleted { get; set; }
    }

    // get data
    public class BranchListModel : InfoPageModel
    {
        public BranchListModel()
        {
            List = new List<BranchModel>();
        }
        public List<BranchModel> List { get; set; }
    }
}
