using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Branch")]
    [PrimaryKey("Id", autoIncrement = true)] // thêm khóa chính để câu lệnh insert trả về ID hiện có của User
    public class BranchEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool bActived { get; set; }
        public bool bDeleted { get; set; }
    }
    // get data
    public class BranchListEntity : InfoPageEntity
    {
        public BranchListEntity()
        {
            List = new List<BranchEntity>();
        }
        public List<BranchEntity> List { get; set; }
    }
}
