using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Entity
{
    [TableName("Account")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class AccountEntity : LogsDateEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public bool bLock { get; set; }
        public bool bActived { get; set; }
        public bool bDeleted { get; set; }
        public int IsType { get; set; }
        public int IsStatus { get; set; }
        public string IP { get; set; }
    }

    public class AccountChangePassEntity : LogsDateEntity
    {
        public string UserName { get; set; }
        public string PassOld { get; set; }
        public string PassNew { get; set; }
    }
    public class AccountListEntity : InfoPageEntity
    {
        public AccountListEntity()
        {
            List = new List<AccountEntity>();
        }
        public List<AccountEntity> List { get; set; }
    }
}
