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
        public const int AMOUNT_PAGING = 50;
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
            public static string RespositoryEmailRegister = "RespositoryEmailRegister";
            public static string RespositoryNews = "RespositoryNews";
            public static string RespositoryCarRental = "RespositoryCarRental";
            public static string RespositoryHotelRoom = "RespositoryHotelRoom";
            public static string RespositoryHotelServices = "RespositoryHotelServices";     
            public static string RespositoryHotel = "RespositoryHotel";
            public static string RespositoryContact = "RespositoryContact";
            public static string RespositoryCity = "RespositoryCity";
            public static string RespositoryDistrict = "RespositoryDistrict";
            public static string RespositoryInfo = "RespositoryInfo";
            public static string RespositoryTour = "RespositoryTour";
            public static string RespositoryTourCategory = "RespositoryTourCategory";

            public static string RespositoryManagerGroup = "RespositoryManagerGroup";
            public static string RespositoryManagerFeature = "RespositoryManagerFeature";
            public static string RespositoryManagerFeatureGroup = "RespositoryManagerFeatureGroup";
            public static string RespositoryManagerPermission = "RespositoryManagerPermission";
            public static string RespositoryManagerAccount = "RespositoryManagerAccount";

            public static string ServicesEmailRegister = "ServicesEmailRegister";
            public static string ServiceNews = "ServiceNews";
            public static string ServiceCarRental = "ServiceCarRental";
            public static string ServiceHotelServices = "ServiceHotelServices";
            public static string ServiceHotelRoom = "ServiceHotelRoom";
            public static string ServiceHotel = "ServiceHotel";
            public static string ServiceCity = "ServiceCity";
            public static string ServiceContact = "ServiceContact";
            public static string ServiceInfo = "ServiceInfo";
            public static string ServiceTour = "ServiceTour";
            public static string ServiceTourCategory = "ServiceTourCategory";
            public static string ServiceManagerGroup = "ServiceManagerGroup";
            public static string ServiceManagerFeature = "ServiceManagerFeature";
            public static string ServiceManagerFeatureGroup = "ServiceManagerFeatureGroup";
            public static string ServiceManagerPermission = "ServiceManagerPermission";
            public static string ServiceManagerAccount = "ServiceManagerAccount";
        }
    }
}
