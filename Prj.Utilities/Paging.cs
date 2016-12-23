using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Prj.Utilities
{
    public class Paging
    {
        public static string GetUrl(string curUrl)
        {
            if (HttpContext.Current.Request.QueryString["Page"] != null)
            {
                int _page = Protector.Int(HttpContext.Current.Request.QueryString["Page"]);
                if (curUrl.Contains("&Page"))
                {
                    curUrl = curUrl.Replace(("&Page=" + _page.ToString()), "");
                }
                else if (curUrl.Contains("?Page"))
                {
                    curUrl = curUrl.Replace(("?Page=" + _page.ToString()), "");
                }
            }
            return curUrl;
        }
        public static string PagingAdmin(string url, long totalRecord, int recordPerPage, int currentPage, int type)
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
                pagingLink.Append("<ul class='pagination pagination-sm no-margin pull-right'>");
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
                    pagingLink.Append("<li><a href='" + tempUrl + "Page=1'>" + "«" + "</a></li>");
                    pagingLink.Append("<li><a href='" + tempUrl + "Page=" + (currentPage - 1).ToString() + "'>" + "‹" + "</a></li>");
                }
                for (int i = start; i <= end; i++)
                {
                    if (i == currentPage)
                    {
                        pagingLink.Append("<li><a style='color:Red;' >" + i.ToString() + "</a></li>");
                    }
                    else
                    {
                        pagingLink.Append("<li><a href='" + tempUrl + "Page=" + i.ToString() + "'>" + i.ToString() + "</a></li> ");
                    }
                }
                if (currentPage + 1 <= totalPage)
                {
                    pagingLink.Append("<li><a href='" + tempUrl + "Page=" + (currentPage + 1).ToString() + "'><span>" + "›" + "</span></a></li>");
                    pagingLink.Append("<li><a href='" + tempUrl + "Page=" + totalPage.ToString() + "'><span>" + "»" + "</span></a></li>");
                }
                pagingLink.Append("</ul>");
                return pagingLink.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string PagingWeb(string url, long totalRecord, int recordPerPage, int currentPage, int type)
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
                pagingLink.Append("<ul>");
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
                    pagingLink.Append("<a href='" + tempUrl + "Page=1'><li class='pagefirst'>" + "</li></a>");
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + (currentPage - 1).ToString() + "'><li class='pageprev'>"  + "</li></a>");
                }
                for (int i = start; i <= end; i++)
                {
                    if (i == currentPage)
                    {
                        pagingLink.Append("<a style='color:Red;'><li class='pageeach active'>" + i.ToString() + "</li></a>");
                    }
                    else
                    {
                        pagingLink.Append("<a href='" + tempUrl + "Page=" + i.ToString() + "'><li class='pageeach'> " + i.ToString() + "</li></a>");
                    }
                }
                if (currentPage + 1 <= totalPage)
                {
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + (currentPage + 1).ToString() + "'><li  class='pagenext allow'></li></a>");
                    pagingLink.Append("<a href='" + tempUrl + "Page=" + totalPage.ToString() + "'><li class='pagelast allow'></li></a>");
                }
                pagingLink.Append("</ul>");
                return pagingLink.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}