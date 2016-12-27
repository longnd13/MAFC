using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
  public class GroupPageModel : LogsDateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input GroupPage Name !")]
        public string Name { get; set; }
    }
    public class GroupPageListModel : InfoPageModel
    {
        public GroupPageListModel()
        {
            List = new List<GroupPageModel>();
        }
        public List<GroupPageModel> List { get; set; }
    }
}
