using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RZD
{
    public static class CurrentUser
    {
        public static int PositionId { get; set; } 

        public static int Id{ get; set; }

        public static void StartSession(User user)
        {
            PositionId = user.PositionNavigation.Id;
            Id = user.Id;
        }
    }
}
