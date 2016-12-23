using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace Prj.Utilities
{
    public class Globals
    {
        public static string UploadImagesReturnName(HttpPostedFileBase postfile, string pathImage)
        {
            if (postfile != null && postfile.ContentLength > 0)
            {
                var fileName = Guid.NewGuid().ToString().Split('-')[0] + Path.GetExtension(postfile.FileName);
                var path = Path.Combine(pathImage, fileName);
                postfile.SaveAs(path);
                return fileName.ToString();
            }
            return "no-image.jpg";
        }

        public static string ErrorMessage(string message, bool result)
        {
            if (result.Equals(true))
            {
                return "<span style='color:Green;font-weight:bold'>" + message + "</span>";
            }
            else
            {
                return "<span style='color:REd;font-weight:bold'>" + message + "</span>";
            }
        }

        public static string FormatNumber(object value)
        {
           return String.Format("{0:#,0}", Protector.Int(value)).Replace(",", ".");
        }
        public static string FormatNumberToMoney(object value)
        {
            return String.Format("{0:#.0}", Protector.Int(value));
        }
        public static void WriteLog(string ForderName, string FunctionName, string ErrDesc)
        {

            string vFolderName = System.Web.HttpContext.Current.Server.MapPath("/Logs/") + ForderName + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
            string vFileName = vFolderName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".txt";
            System.IO.StreamWriter objStreamWriter = null;
            string vStringLog = System.DateTime.Now.ToString() + "," + FunctionName;

            try
            {
                if (!System.IO.Directory.Exists(vFolderName))
                {
                    System.IO.Directory.CreateDirectory(vFolderName);
                }

                if (!System.IO.File.Exists(vFileName))
                {
                    System.IO.StreamWriter objFile = System.IO.File.CreateText(vFileName);
                    objFile.Close();
                }

                if (!string.IsNullOrEmpty(ErrDesc))
                {
                    vStringLog += ", " + ErrDesc;
                }

                objStreamWriter = System.IO.File.AppendText(vFileName);
                objStreamWriter.WriteLine(vStringLog);
                objStreamWriter.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objStreamWriter.Close();
            }
        }

        public static string LinkPagingAdminPostback(string url, long totalRecord, int recordPerPage, int currentPage, int type)
        {
            int totalPage = 0;
            if (totalRecord % recordPerPage == 0)
            {
                totalPage = (int)(totalRecord / recordPerPage);
            }
            else
            {
                totalPage = (int)(totalRecord / recordPerPage + 1);
            }
            if (totalPage > 1)
            {
                StringBuilder pagingLink = new StringBuilder();
                int start = 1;
                int end = 0;
                if (totalPage > 5)
                {
                    if (currentPage > 3)
                    {
                        start = currentPage - 2;
                        if (totalPage - start < 5)
                        {
                            start = totalPage - 4;
                        }
                        if (currentPage + 2 < totalPage)
                        {
                            end = currentPage + 2;
                        }
                        else
                        {
                            end = totalPage;
                        }
                    }
                    else
                    {
                        end = 5;
                    }
                }
                else
                {
                    end = totalPage;
                }
                pagingLink.Append("<div id='paging' class='paginator2 fr'>");
                string tempUrl = "";
                if (type == 1)
                {
                    tempUrl = url + "?";
                }
                else
                {
                    tempUrl = url + "&";
                }
                if (currentPage > 1)
                {
                    pagingLink.Append("<a href='" + tempUrl + "Page=1'>" + "«" + "</a>");
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + (currentPage - 1).ToString() + "'>" + "‹" + "</a>");
                }
                for (int i = start; i <= end; i++)
                {
                    if (i == currentPage)
                    {
                        pagingLink.Append("<a class='selected'>" + i.ToString() + "</a> ");
                    }
                    else
                    {
                        pagingLink.Append("<a href='" + tempUrl + "Page=" + i.ToString() + "'>" + i.ToString() + "</a> ");
                    }
                }
                if (currentPage + 1 <= totalPage)
                {
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + (currentPage + 1).ToString() + "'><span>" + "›" + "</span></a>");
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + totalPage.ToString() + "'><span>" + "»" + "</span></a>");
                }
                pagingLink.Append("</div>");
                return pagingLink.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
      
        // Lấy IP
        public static string GetIP()
        {
            string sIP = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
            {
                sIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else
            {
                sIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            return sIP;
        }
        // Check IP
        public static bool ListIP()
        {
            bool iFlag = true;
            try
            {
                string ip = GetIP();
                if (ip.Contains("113.22.53.199") || ip.Contains("::1") || ip.Contains("116.102.153.135") || ip.Contains("180.93.171.176"))
                {
                    iFlag = true;
                }
                else
                {
                    iFlag = false;
                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return iFlag;
        }
        //'Ghi Logs
      
        public static string RandomString1Param(int size)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                // Random from A-Z
                builder.Append((char)random.Next(0x41, 0x5A));
            }
            return builder.ToString();
        }
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            //text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

        }

        public static string ReplaceWords(string inputString)
        {
            if (inputString == null)
            {
                return "";
            }
            if (inputString.Substring(0, 1).Contains(" "))
                inputString = inputString.Remove(0, 1);
            if (inputString.Substring(inputString.Length - 1).Contains(" "))
                inputString = inputString.Remove(inputString.Length - 1);
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = inputString.Normalize(System.Text.NormalizationForm.FormD);
            inputString = regex.Replace(temp, String.Empty).Replace('\u0111', 'd')
                .Replace('\u0110', 'D')
                .Replace("…", "")
                .Replace(".", "")
                .Replace("“", "")
                .Replace("”", "")
                .Replace("?", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("\"", "")
                .Replace("\'", "")
                .Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "")
                .Replace(":", "")
                .Replace("@", "")
                .Replace(",", "")
                .Replace("`", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("&", "")
                .Replace("_", "-")
                .Replace("+", "-")
                .Replace(" ", "-")
                .Replace("--", "-").Replace("---", "-").Trim().ToLower();//.Replace("-","");

            return inputString;
        }

        public static bool IsAlphaNumericString(string str)
        {
            char[] arrs = str.ToCharArray();
            foreach (char c in arrs)
            {
                if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }
     
        public static string GetUniqueFileName(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            if (filename.Contains("."))
            {
                filename = filename.Replace(".", "_");
            }          
            if (filename.Length > 40)
                filename = filename.Substring(0, 40);
            return filename + "_" + DateTime.Now.Ticks.ToString() + Path.GetExtension(path);
        }
        public static string CheckImageExtension(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower() != ".jpg"
             && Path.GetExtension(fileName).ToLower() != ".png"
             && Path.GetExtension(fileName).ToLower() != ".gif"
             && Path.GetExtension(fileName).ToLower() != ".jpeg")
            {

                return "INVALID";
            }
            else
            {
                return "OK";
            }
        }
        public static string CheckImageContentType(string contentType)
        {
            if (contentType.ToLower() != "image/jpg"
             && contentType.ToLower() != "image/jpeg"
             && contentType.ToLower() != "image/pjpeg"
             && contentType.ToLower() != "image/x-png"
             && contentType.ToLower() != "image/png"
             && contentType.ToLower() != "image/gif")
            {

                return "INVALID";
            }
            else
            {
                return "OK";
            }
        }

        public static bool CheckMail(string email)
        {
            //Using Regex to check email
            string strRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return (true);
            else
                return (false);
        }

        public static bool CheckPassWord(string pass)
        {
            //Using Regex to check email
            string strRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(pass))
                return (true);
            else
                return (false);
        }

        public static bool SendCodeByEmail(string strSendTo, string strSubject, string strContent)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = strSubject;
            mail.IsBodyHtml = true;
            mail.Body = strContent;
            mail.From = new MailAddress("longnd@hig.vn", "Thuy Duong Mobile");
            mail.To.Add(strSendTo);
            try
            {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                // khai bao tai khoan va mat khau gui mai
                //  client.Credentials = new System.Net.NetworkCredential("myusername@gmail.com", "mypwd");
                NetworkCredential credentials = new NetworkCredential("longnd@hig.vn", "yeonsaeng");
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        // mã hóa md5
        public static string GetMD5FromString(string inputString)
        {
            return BitConverter.ToString(System.Security.Cryptography.MD5.Create().ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(inputString))).Replace("-", string.Empty);
        }

        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            byte[] valueArray = Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var sb = new StringBuilder();
            for (int i = 0; i < valueArray.Length; i++)
                sb.Append(valueArray[i].ToString("x2").ToLower());
            return sb.ToString();
        }
            
        public static string FormatDayMonth(DateTime dt)
        {
            return dt.ToString("MM/dd/yyyy");
        }
        // format summary 
        public static string ProcessTitle(string subject, int charshow)
        {
            string result = subject;

            if (subject != null)
            {
                if (subject.Length > charshow)
                {
                    result = subject.Substring(0, charshow - 1) + "...";
                }
                else
                {
                    result = subject;
                }
            }
            return result;
        }

        public static string SendGETRequest(string requestURL)
        {
            //Logger.Log.error("SendGETRequest: " + requestURL);
            string resultOutput = string.Empty;
            string nextLocation = "";
            string htmlResult = "";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestURL);
            myRequest.Method = "GET";
            myRequest.KeepAlive = true;

            myRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:2.0) Gecko/20100101 Firefox/4.0";
            myRequest.Headers.Add("Accept-Charset:ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            myRequest.Headers.Add("Keep-Alive:15");
            myRequest.Proxy = null;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse())
                {
                    nextLocation = response.GetResponseHeader("Location");

                    htmlResult = string.Empty;

                    using (BufferedStream buffer = new BufferedStream(response.GetResponseStream()))
                    {
                        using (StreamReader readStream = new StreamReader(buffer, Encoding.UTF8))
                        {
                            resultOutput = readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                htmlResult = resultOutput;
            }
            return htmlResult;
        }

        public static double ConvertToTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return Math.Round(span.TotalSeconds);
        }

        //Kiểm tra chuỗi chỉ bao gồm số
        public static bool isValidNumber(string valueNumber)
        {
            bool functionReturnValue = false;
            //Khai báo biến Regular Expression
            Regex objRegex = null;
            Match matchResult = null;

            try
            {
                //Khởi tạo đối tượng tìm kiếm Regular Expression
                objRegex = new Regex("^\\d+$");
                //Kiểm tra khớp chuỗi
                matchResult = objRegex.Match(valueNumber);
                //Trả về kết quả
                if (matchResult.Success)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                }
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
            return functionReturnValue;
        }

        // size = ma hoa bao nhiu ky tu
        public static string ramdompass(int size)
        {
            Random _rng = new Random();
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToLower();
            char[] buffer = new char[size];
            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
       
        static public void SendMail(string fromAddress, string displayname, string toAddress, string subject, string body)
        {
            string host = ConfigurationManager.AppSettings.Get("MailServer");

            System.Net.Mail.SmtpClient smtpSend = new System.Net.Mail.SmtpClient(host);

            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("SmtpCredentialEmail")) && !String.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("SmtpCredentialPassword")))
            {
                smtpSend.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("SmtpCredentialEmail"), ConfigurationManager.AppSettings.Get("SmtpCredentialPassword"));
            }

            using (System.Net.Mail.MailMessage emailMessage = new System.Net.Mail.MailMessage())
            {
                emailMessage.To.Add(toAddress);
                emailMessage.From = new MailAddress(fromAddress, displayname);
                //emailMessage.Bcc.Add(new MailAddress("nglinh24@yahoo.com"));
                emailMessage.Subject = subject;
                emailMessage.Body = body;
                emailMessage.IsBodyHtml = true;

                //if (!Regex.IsMatch(emailMessage.Body, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase) ||
                //        !Regex.IsMatch(emailMessage.Subject, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase))
                //{
                //    emailMessage.BodyEncoding = Encoding.Unicode;
                //}
                try
                {
                    smtpSend.Send(emailMessage);
                }
                catch { }
            }
        }

        public static string RandomString()
        {
            // xuất code 
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
           
                var result = new string(
              Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                return result;
        }
    }
}