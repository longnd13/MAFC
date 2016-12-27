using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Permission")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class PermissionEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int GroupId { get; set; }
    }
}
