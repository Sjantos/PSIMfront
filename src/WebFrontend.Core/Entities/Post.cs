using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebFrontend.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorUsername { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public string File { get; set; }

        public string GetTags()
        {
            StringBuilder builder = new StringBuilder("Tags: ");
            foreach (var tag in this.Tags)
            {
                builder.Append(tag + ", ");
            }
            return builder.ToString();
        }
    }
}
