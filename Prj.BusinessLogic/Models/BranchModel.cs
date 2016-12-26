
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Prj.BusinessLogic.Models
{
  public class BranchModel : LogsDateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Branch Name !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Address !")]
        public string Address { get; set; }
        public string Description { get; set; }
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
