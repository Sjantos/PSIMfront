using System;
using System.Collections.Generic;
using System.Text;

namespace WebFrontend.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag()
        {

        }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
