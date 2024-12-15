using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBterm
{
    internal class LoggedInUser
    {
        public static string UserId { get; set; } // 로그인한 사용자의 ID
        public static string UserName { get; set; } // 로그인한 사용자의 이름
        public static string UserLevel { get; set; } // 로그인한 사용자의 등급 (예: VIP, GOLD, SILVER)
        public static bool IsAdmin { get; set; } // 관리자인지 여부
    }
}
