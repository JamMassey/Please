using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PostListViewModel
    {
        public int NumberOfPosts { get; set; }
        public List<Post> Posts { get; set; }
    }
}