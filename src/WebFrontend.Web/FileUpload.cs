using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebFrontend.Entities
{
    public class FileUpload
    {
        //[Required]
        //[Display(Name ="FileName")]
        //[StringLength(60, MinimumLength = 5)]
        //public string FileName { get; set; }
        //[Required]
        //[Display(Name = "Files")]
        public IFormFileCollection Files { get; set; }
    }
}
