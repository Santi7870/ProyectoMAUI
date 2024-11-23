using ProyectoMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoMAUI.Services
{
    public static class UserService
    {
        public static Usuario CurrentUser { get; set; }
        public static string CurrentUserName { get; set; }

    }
}
