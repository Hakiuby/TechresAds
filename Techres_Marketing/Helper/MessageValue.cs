using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Helper
{
    public static class MessageValue
    {
        public static string INTERNAL_SERVER_ERROR = "Không kết nối được server!";
        public static string FORBIDDEN = "Bạn không quyền truy cập chức năng này!";
        public static string MESSAGE_LOGIN_FAIL = "Tên tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.";
        public static string MESSAGE_NOTIFICATION = "THÔNG BÁO";
        public static string MESSAGE_FROM_CANCEL = "Đóng(ESC)";
        public static string MESSAGE_FROM_CHOOSE = "Chọn nhạc";
        public static string MESSAGE_FROM_SAVE = "Lưu lại";
        public static string MESSAGE_FROM_COMPLETE = "Xác nhận";
        public static string MESSAGE_FROM_CLOSE = "Hủy";
        public static string MESSAGE_FROM_UPDATE = "Cập nhật";

        // MessageNotification
        public static string MESSAGE_FROM_NOTIFICATION_BALLOONTIP_TITLE = "Teachres";
        public static string MESSAGE_FROM_NOTIFICATION_BALLOONTIP_NOTIFY = "Thông báo";
        public static string MESSAGE_FROM_NOTIFICATION_BALLOONTIP_WARNING = "Cảnh báo";
        public static string MESSAGE_FROM_NOTIFICATION_BALLOONTIP_ERROR = "Lỗi";
        public static string MESSAGE_RESTAURANT_NAME_NOT = "Bạn chưa nhập tên nhà hàng. Vui lòng nhập tên nhà hàng!";
        public static string MESSAGE_PASSWORD_NOT = "Bạn chưa nhập mật khẩu. Vui lòng nhập mật khẩu!";
        public static string MESSAGE_USERNAME_NOT = "Bạn chưa nhập tên đăng nhập. Vui lòng nhập tên đăng nhập!";
        public static string MESSAGE_ERROR_RESTAURANT_NAME = "Nhà hàng tối thiểu phải có 3 đến 30 ký tự";
        public static string MESSAGE_ERROR_PASSWORD = "Mật khẩu tối thiểu phải có 4 đến 50 ký tự";
        public static string MESSAGE_ERROR_USERNAME = "Mật khẩu tối thiểu phải có 3 đến 30 ký tự";


        // Title Text Main 

        public static string TITLE_ADS_CUSTOMER = "Quảng cáo khách hàng";
        public static string TITLE_PARTY_BIRTDAY = "Chúc mừng sinh nhật khách hàng";
        public static string TITLE_PARTY_BIRTHDAY = "Danh sách chia sẻ ảnh ALOLINE";
        public static string TITLE_ADS_RESTAURANT = "Quảng cáo nhà hàng";

        // Dialog 
        public static string MESSAGE_FROM_CONFIRM = "XÁC NHẬN";
        public static string MESSAGE_NO_CONTENT = "Đóng";
        public static string MESSAGE_CONTENT_LOGOUT = "Bạn có muốn thoát ứng dụng ? ";
        public static string MESSAGE_TITILE_LOGOUT = "Thoát"; 
    }
}
