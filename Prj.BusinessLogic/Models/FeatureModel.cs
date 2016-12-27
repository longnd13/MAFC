using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Models
{
   public class FeatureModel : LogsDateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input Feature Name !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Feature Url !")]
        public string Url { get; set; }
        public int GroupPageId { get; set; }
    }
    public class FeatureListModel : InfoPageModel
    {
        public FeatureListModel()
        {
            List = new List<FeatureModel>();
        }
        public List<FeatureModel> List { get; set; }
    }
}
