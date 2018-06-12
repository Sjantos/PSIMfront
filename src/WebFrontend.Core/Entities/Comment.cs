using System;
using System.Collections.Generic;
using System.Text;

namespace WebFrontend.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorUsername { get; set; }
        //public int AuthorId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CommentToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.AuthorUsername + " commented at " + this.CreatedAt + "<br />");
            builder.AppendLine(this.CommentContent);

            return builder.ToString();
        }
    }
}
