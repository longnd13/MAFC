using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
  public class GroupPageModel
    {
        public int Id { get; set; }
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
