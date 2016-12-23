using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Utilities
{
  public class ConfigHandler
    {
        private const string _PathImageHotelImages = "path:ImageHotelImages";
        private const string _PathImageCity = "path:ImagesCity";
        private const string _PathImageNews = "path:ImagesNews";
        private const string _PathImageCommon = "path:ImagesCommon";
        private const string _PathImageHotel = "path:ImagesHotel";
        private const string _PathImageCarRental = "path:ImagesCarRental";
        private const string _PathImageTour = "path:ImagesTour";
        private const string _PathImageTourThumbnail = "path:ImagesTourThumbnail";
        private const string _PathImageTourNormal = "path:ImagesTourNormal";
        public static string PathImageTour
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageTour];
            }
        }
        public static string PathImageTourThumbnail
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageTourThumbnail];
            }
        }
        public static string PathImageTourNormal
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageTourNormal];
            }
        }
        public static string PathImageCarRental
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageCarRental];
            }
        }
        public static string PathImageHotel
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageHotel];
            }
        }
        public static string PathImageCommon
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageCommon];
            }
        }
        public static string PathImageNews
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageNews];
            }
        }
        public static string PathImageCity
        {
            get
            {
                return ConfigurationManager.AppSettings[_PathImageCity];
            }
        }

        public static string PathImageHotelImages
        { 
            get
            {
                return ConfigurationManager.AppSettings[_PathImageHotelImages];
            }
        }
    }
}
