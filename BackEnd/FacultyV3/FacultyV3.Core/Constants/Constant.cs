using System.Collections.Generic;

namespace FacultyV3.Core.Constants
{
    public class Constant
    {
        // View Bag / Temp Data Constants
        public const string MessageViewBagName = "Message";

        public const string DEPARTMENT = "Tổ bộ môn";

        public const string INTRODUCE = "Giới thiệu";
        public const string ADMISSION = "Tuyển sinh";
        public const string EDUCATE = "Đào tạo";
        public const string RESEARCH = "Nghiên cứu";
        public const string RESOURCE = "Học liệu";
        public const string PARTY_CELL = "Chi bộ";
        public const string ALUMNI = "Cựu sinh viên";
        public const string NEWS = "THÔNG BÁO";

        // EDUCATE
        public const string EDUCATION_PROGRAM = "CHƯƠNG TRÌNH ĐÀO TẠO";
        public const string TRAINING_SECTOR = "NGÀNH ĐÀO TẠO";
        public const string TRAINING_PROCESS = "QUY TRÌNH ĐÀO TẠO";
        public const string STATUTES_REGULATIONS = "CHƯƠNG TRÌNH ĐÀO TẠO";

        // NEWS
        public const string NEWSS = "THÔNG TIN - THÔNG BÁO";
        public const string WORK = "TUYỂN DỤNG - VIỆC LÀM";
        public const string NEWS_FROM_THE_MINISTRY = "TIN TỪ BỘ MÔN";
        public const string NEWS_FROM_FACULTY = "TIN TỪ KHOA";
        public const string NEWS_FROM_UNIVERSITY = "TIN TỪ TRƯỜNG";
        public const string YOUTH_GROUP = "Tin từ Đoàn thanh niên";
        public const string NEWS_FROM_PARTY_CELL = "TIN TỪ CHI BỘ";
        public const string NEWS_FROM_UNION = "TIN TỪ CÔNG ĐOÀN";


        public const string MESSENGER_NAME = "Messenger";
        public const string META_KEYWORDS = "Meta_Keywords";
        public const string META_DESCRIPTION = "Meta_Description";

        public const string USER_SESSION = "USER_SESSION";

        public const string ADMIN = "Admin";
        public const string POSTER = "Poster";
        public const string ADMIN_OR_POSTER = ADMIN + "," + POSTER;
        public const string SESSION_CREDENTIAL = "SESSION_CREDENTIAL";


        public const int SERIALACCEPT = 84;
        public const int PAGESIZE = 4;

        public static IDictionary<string, string> ListActionPage = new Dictionary<string, string>() {

            { "Tin từ Bộ môn", "tin-tu-bo-mon" },
            { "Thông Tin - Thông Báo", "thong-tin-thong-bao" },
            { "Tin từ Khoa", "tin-tu-khoa" },
            { "Tuyển dụng - Việc làm", "tuyen-dung-viec-lam" },
            { "Tin từ Đoàn thanh niên", "doan-thanh-nien" },
            { "Tin từ Trường", "tin-tu-truong" },
            { "Tin từ Công đoàn", "tin-tu-cong-doan" },
            { "Tin từ Chi bộ", "tin-tu-chi-bo" },
            { "Tuyển sinh", "tuyen-sinh" },
            { "Học liệu", "hoc-lieu" },
            { "Tổ bộ môn", "gioi-thieu/to-bo-mon" },

        };
    }
}
