using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using viettours.Models;
using System.Web.Mvc;
namespace viettours.Custom_Helpers
{
    public static class Custom_Helper_Class
    {

        public static IHtmlString khoi_BaiViet(this HtmlHelper helper, post a)
        {
            string link = $"../postss/DisplayDetailPost?id={a.id}&title={a.title}";
            string LableStr = $"<aside class=\"\"> <header class=\"entry-header\" > <h2 class=\"entry-title\"><a href=\"{link}\" style=\"color:#2B8D95;text-decoration:none;font-size:15px;\">{a.title}</a></h2> </header> <div class=\"entry-content\" style=\"display:flex;position:relative;\"> <div> <a href=\"#\"> <img width=\"150\" height=\"150\" src=\"../Content/Post/{a.anh}\" class=\"alignleft wp-post-image\" alt=\"\"></a><p></p> </div><div style=\"padding-left:10px;padding-top:10px;\">{a.motangan}</div><div style=\"margin-left: 15px;margin-top: 10px;position: absolute;right: 0;bottom: 55px;\"> <div class=\"at-above-post-cat-page addthis_tool\"></div><p></p> <p> <a class=\"excerpt-read-more\" href=\"{link}\">Xem tiếp</a></p> </div> </div> <footer class=\"post-meta\"><p></p></footer> </aside>";
           /* string LableStr = $"<aside class=\"\"> <header class=\"entry-header\"> <h2 class=\"entry-title\"><a href = \"#\" rel=\"bookmark\">{a.title}</a></h2> </header> <div class=\"entry-content\"> <a href = \"#\"><img width = \"150\" height=\"150\" src=\"../Content/Post/{a.anh}\" class=\"alignleft wp-post-image\" alt=\"\"></a><p></p><div class=\"at-above-post-cat-page addthis_tool\" data-url=\"\"></div>{a.motangan}<div class=\"at-below-post-cat-page addthis_tool\" data-url=\"\"></div><p></p><p><a class=\"excerpt-read-more\" href=\"{link}\">Xem tiếp</a></p> </div> <footer class=\"post-meta\"><p></p></footer></aside>";*/
            return new HtmlString(LableStr);
        }
        public static IHtmlString khoi_Tour(this HtmlHelper helper, tour a)
        {
            string link = $"../toursss/DisplayDetailTour?id={a.id}&nameTour={a.name}";
   
               /*string LableStr = $"<div class=\"tour_taxonomy_view\"><div class=\"title_tour\"><strong><a href=\"controller/action/{a.id}\"><span class=\"tieude-tour\">{a.name}</span></a></strong></div><div class=\"date_tour\"></div><div class=\"feature_tour\"><img width=\"150\" height=\"150\" src=\"../Content/Tour/{a.anh}\" class=\"attachment-thumbnail size-thumbnail wp-post-image\" alt=\"\"></div> <div class=\"destination_tour\"><strong>Điểm đến :</strong><span class=\"tieude-tour\">{a.name}</span></div> <div class=\"duration_tour\"><strong>Thời gian :</strong><span class=\"tieude-tour\">{a.thoigian} Ngày - {(a.thoigian - 1)} Đêm</span></div> <div class=\"operates_tour\"><strong>Khởi hành :</strong><span class=\"tieude-tour\">Vui lòng liên hệ với chúng tôi để biết thêm chi tiết</span></div> <div class=\"phuongtien\"><strong>Phương tiện :</strong><span class=\"tieude-tour\">{a.phuongtien}</span></div> <div class=\"price_tour\"><strong>Giá :</strong><span class=\"tieude-tour\">Vui lòng liên hệ với chúng tôi để biết thêm chi tiết</span></div> <div class=\"readmore_tour\"><a href=\"{link}\">Xem tiếp</a></div> <div class=\"tour_meta\"></div></div>";*/
            string LableStr = $"<div class=\"tour_taxonomy_view\"> <div class=\"title_tour\"><strong><a href=\"{link}\" style=\"color:#2B8D95;text-decoration:none;font-size:15px;\"><span class=\"tieude-tour\">{a.name}</span></a></strong></div> <div style=\"display: flex;\"> <div class=\"feature_tour\"><img width=\"150\" height=\"150\" src=\"../Content/Tour/{a.anh}\" class=\"attachment-thumbnail size-thumbnail wp-post-image\" alt=\"\"></div><div style=\"margin: 10px;width:100%\"> <div class=\"destination_tour\"><strong>Điểm đến :</strong><span class=\"tieude-tour\">{a.name}</span></div> <div class=\"duration_tour\"><strong>Thời gian :</strong><span class=\"tieude-tour\">{a.thoigian} Ngày - {(a.thoigian - 1)} Đêm</span></div> <div class=\"operates_tour\"><strong>Khởi hành :</strong> Vui lòng liên hệ với chúng tôi để biết thêm chi tiết</div> <div class=\"phuongtien\"><strong>Phương tiện :</strong> <span class=\"tieude-tour\">{a.phuongtien}</span></div> <div class=\"price_tour\"><strong>Giá :</strong> Vui lòng liên hệ với chúng tôi để biết thêm chi tiết</div> <div class=\"readmore_tour\"><a href=\"{link}\">Xem tiếp</a></div> <div class=\"tour_meta\"></div> </div> </div> </div>";
            return new HtmlString(LableStr);
        }
    }
}