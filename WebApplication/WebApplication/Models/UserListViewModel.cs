using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserListViewModel
    {
        public int NumberOfUsers { get; set; }
        public List<User> Users { get; set; }
    }
}
