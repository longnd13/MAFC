using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
    public class ApplicationModel : LogsDateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Application Name !")]
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public bool bActived { get; set; }
        public bool bDeleted { get; set; }
    }

    public class ApplicationListModel : InfoPageModel
    {
        public ApplicationListModel()
        {
            List = new List<ApplicationModel>();
        }
        public List<ApplicationModel> List { get; set; }
    }
}
