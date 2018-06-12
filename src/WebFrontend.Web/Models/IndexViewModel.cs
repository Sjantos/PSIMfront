using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFrontend.Entities;

namespace WebFrontend.Web.Models
{
    public class IndexViewModel
    {
        public IReadOnlyList<Post> Posts { get; }

        public IndexViewModel(IEnumerable<Post> posts)
        {
            Posts = posts.ToList();
        }
    }
}
