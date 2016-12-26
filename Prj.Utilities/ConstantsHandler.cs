using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Utilities
{
   public class ConstantsHandler
    {
        public const int AMOUNT_PAGINGWEB = 9;
        public const int PAGE_50 = 50;
        public const int PAGE_100 = 50;
        public const int CAPACITY_IMG = 4096000;

        public class ErrorMessage
        {
            public static string Message_WARNING = "[Warning] - Tài khoản đang tạm khóa! ";
            public static string Message_OK = "[OK] - Thao tác thành công! ";
            public static string Message_ERR = "[Error] - Lỗi hệ thống. Vui lòng thử lại sau 2 phút nữa.";
            public static string Message_EXIST = "[EXIST] - Dữ liệu đã tồn tại trong hệ thống. Bạn vui lòng kiểm tra lại.";
            public static string Message_EX = "[Exception] - Có lỗi xảy ra trong quá trình xử lý.";
            public static string Message_INVALID = "[Invalid] - Dữ liệu không hợp lệ hoặc không tồn tại trong hệ thống";
            public static string Message_NULL = "[Null] - Dữ liệu không tồn tại.";
        }


        public static string Upload_Banner = "~/Uploads/Banner/";
        public static string Upload_Media = "~/Uploads/Media/";
        public static string Upload_News = "~/Uploads/News/";
        public static string Upload_Common = "~/Uploads/Common/";

        public class ForderLogName
        {
            public static string RepoBranch = "RepoBranch";
            public static string ServiceBranch = "ServiceBranch";
            public static string WebBranch = "WebBranch";

        }
    }
}
