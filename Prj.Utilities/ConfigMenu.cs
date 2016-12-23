using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Utilities
{
  public  class ConfigMenu
    {
        public static string ActviedMenu(string Group, string url)
        {
           
            string active = "";

            // tài khoản
            if (Group == "Account" && (url.ToLower().Contains("/admin/account/index") ||
                                       url.ToLower().Contains("/admin/account/register")))
            {
                active = "active";
            }
            else if (Group == "AccountIndex" && url.ToLower().Contains("/admin/account/index"))
            {
                active = "active";
            }
            else if (Group == "AccountRegister" && url.ToLower().Contains("/admin/account/register"))
            {
                active = "active";
            }
            // phân quyền

            if (Group == "AccountIndex" && url.ToLower().Contains("/admin/account/index"))
            {
                active = "active";
            }
            else if (Group == "AccountRegister" && url.ToLower().Contains("/admin/account/register"))
            {
                active = "active";
            }
            else if (Group == "Account" && url.ToLower().Contains("/admin/account"))
            {
                active = "active";
            }
            else if (Group == "Permission" && (url.ToLower().Contains("/admin/permission") ||
                                           url.ToLower().Contains("/admin/featuregroup/index") ||
                                           url.ToLower().Contains("/admin/group") ||
                                           url.ToLower().Contains("/admin/feature/index")))
            {
                active = "active";
            }
            else if (Group == "PermissionGroup" && url.ToLower().Contains("/admin/group"))
            {
                active = "active";
            }
            else if (Group == "PermissionPer" && url.ToLower().Contains("/admin/permission"))
            {
                active = "active";
            }
            else if (Group == "PermissionFeature" && url.ToLower().Contains("/admin/feature/index"))
            {
                active = "active";
            }
            else if (Group == "PermissionFeatureGroup" && url.ToLower().Contains("/admin/featuregroup/index"))
            {
                active = "active";
            }
            // CategoryTour

            if (Group == "CategoryTour" && (url.ToLower().Contains("/admin/tourcategory/index") ||
                                              url.ToLower().Contains("/admin/tourcategory/create") ||
                                              url.ToLower().Contains("/admin/tourcategory/update")))
            {
                active = "active";
            }
            else if (Group == "CategoryTourIndex" && url.ToLower().Contains("/admin/tourcategory/index"))
            {
                active = "active";
            }
            else if (Group == "CategoryTourCreate" && url.ToLower().Contains("/admin/tourcategory/create"))
            {
                active = "active";
            }
            // tour
            if (Group == "Tour" && (url.ToLower().Contains("/admin/tour/index") ||
                                             url.ToLower().Contains("/admin/tour/create") ||
                                             url.ToLower().Contains("/admin/tour/update")))
            {
                active = "active";
            }
            else if (Group == "TourIndex" && url.ToLower().Contains("/admin/tour/index"))
            {
                active = "active";
            }
            else if (Group == "TourCreate" && url.ToLower().Contains("/admin/tour/create"))
            {
                active = "active";
            }
            else if (Group == "TourOrder" && url.ToLower().Contains("/admin/tour/order"))
            {
                active = "active";
            }

            // HOTEL
            if (Group == "Hotel" && (url.ToLower().Contains("/admin/hotelorder/index") ||
                                     url.ToLower().Contains("/admin/city/index") ||
                                     url.ToLower().Contains("/admin/hotel/index") ||
                                     url.ToLower().Contains("/admin/hotel/create") ||
                                     url.ToLower().Contains("/admin/hotel/update") ||
                                     url.ToLower().Contains("/admin/hotelroom/index") ||
                                     url.ToLower().Contains("/admin/hotelroom/create") ||
                                     url.ToLower().Contains("/admin/hotelroom/update") ||
                                     url.ToLower().Contains("/admin/hotelservices/index") ||
                                     url.ToLower().Contains("/admin/hotelservices/create") ||
                                     url.ToLower().Contains("/admin/hotelservices/update")))
            {
                active = "active";
            }
            else if (Group == "HotelOrderIndex" && url.ToLower().Contains("/admin/hotelorder/index"))
            {
                active = "active";
            }
            else if (Group == "CityIndex" && url.ToLower().Contains("/admin/city/index"))
            {
                active = "active";
            }
            else if (Group == "HotelIndex" && url.ToLower().Contains("/admin/hotel/index"))
            {
                active = "active";
            }
            else if (Group == "HotelCreate" && url.ToLower().Contains("/admin/hotel/create"))
            {
                active = "active";
            }

            else if (Group == "HotelRoomIndex" && url.ToLower().Contains("/admin/hotelroom/index"))
            {
                active = "active";
            }
            else if (Group == "HotelRoomCreate" && url.ToLower().Contains("/admin/hotelroom/create"))
            {
                active = "active";
            }
           
            else if (Group == "HotelServicesIndex" && url.ToLower().Contains("/admin/hotelservices/index"))
            {
                active = "active";
            }
            else if (Group == "HotelServicesCreate" && url.ToLower().Contains("/admin/hotelservices/create"))
            {
                active = "active";
            }

            // AIR TICKET
            if (Group == "AirTicket" && (url.ToLower().Contains("/admin/info/airticket/1")))
            {
                active = "active";
            }
            // CArRental
            if (Group == "CarRental" && (url.ToLower().Contains("/admin/carrental/create") ||
                                             url.ToLower().Contains("/admin/carrental/info") ||
                                             url.ToLower().Contains("/admin/carrental/index")))
            {
                active = "active";
            }
            else if (Group == "CarRentalCreate" && url.ToLower().Contains("/admin/carrental/create"))
            {
                active = "active";
            }
            else if (Group == "CarRentalInfo" && url.ToLower().Contains("/admin/carrental/info"))
            {
                active = "active";
            }
            else if (Group == "CarRentalIndex" && url.ToLower().Contains("/admin/carrental/index"))
            {
                active = "active";
            }

            // Contact
            if (Group == "Contact" && (url.ToLower().Contains("/admin/contact/index")) ||
                                        url.ToLower().Contains("/admin/contact/customerregisteremail"))
            {
                active = "active";
            }
            else if (Group == "ContactIndex" && url.ToLower().Contains("/admin/contact/index"))
            {
                active = "active";
            }
            else if (Group == "CustomerRegisterEmail" && url.ToLower().Contains("/admin/contact/customerregisteremail"))
            {
                active = "active";
            }
            // NEWS
            if (Group == "News" && (url.ToLower().Contains("/admin/news/index") ||
                                             url.ToLower().Contains("/admin/news/create") ||
                                             url.ToLower().Contains("/admin/news/update")))
            {
                active = "active";
            }
            else if (Group == "NewsIndex" && url.ToLower().Contains("/admin/news/index"))
            {
                active = "active";
            }
            else if (Group == "NewsCreate" && url.ToLower().Contains("/admin/news/create"))
            {
                active = "active";
            }
            return active;
        }
    }
}
