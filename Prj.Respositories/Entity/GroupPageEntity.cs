using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("GroupPage")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class GroupPageEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // get data
    public class GroupPageListEntity : InfoPageEntity
    {
        public GroupPageListEntity()
        {
            List = new List<GroupPageEntity>();
        }
        public List<GroupPageEntity> List { get; set; }
    }
}
