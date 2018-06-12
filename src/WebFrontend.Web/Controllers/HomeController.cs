using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebFrontend.Entities;
using WebFrontend.Web.Models;

namespace WebFrontend.Web.Controllers
{
    public class HomeController : WebFrontendControllerBase
    {
        public static int postId { get; set; }
        public async Task<ActionResult> Index()
        {
            var backendClient = new BackendClient();
            var posts = await backendClient.GetAllPosts();
            var model = new IndexViewModel(posts);
            return View(model);
            //return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SavePost(string title, string description, string tags, IFormFile file)
        {
            string _fileName = null;
            string _fileType = null;
            string _file = null;
            if(file != null)
            {
                var memStream = new MemoryStream();
                file.OpenReadStream().CopyTo(memStream);
                var fileBytes = memStream.ToArray();
                _file = System.Convert.ToBase64String(fileBytes);
                _fileName = file.FileName;
                _fileType = file.ContentType;
            }
            var tagsWithoutWhiteSpaces = Regex.Replace(tags, @"\s+", "");
            var tagsCollection = tagsWithoutWhiteSpaces.Split(',');
            var newPost = new Post()
            {
                AuthorUsername = "DefaultUsername",
                Title = title,
                CreatedAt = DateTime.Now,
                Description = description,
                Comments = new List<Comment>(),
                Tags = tagsCollection.Select(p => new Tag(p)).ToList(),
                FileName = _fileName,
                FileType = _fileType,
                File = _file
            };
            var backendClient = new BackendClient();
            var result = await backendClient.CreateNewPost(newPost);

            return RedirectToAction("Index");
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveComment(int postId, string CommentContent)
        {
            var comment = new Comment()
            {
                AuthorUsername = "DefaultUsername",
                CommentContent = CommentContent,
                PostId = postId
            };
            var backendClient = new BackendClient();
            var result = await backendClient.CreateComment(comment);
            
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DownloadFile(int postId)
        {
            var backendClient = new BackendClient();
            var result = await backendClient.DownloadFile(postId);

            var data = SimpleJson.SimpleJson.DeserializeObject<MyFile>(result.Content);
            var fileName = data.FileName;
            var fileType = data.FileType;
            var file = Encoding.UTF8.GetString(Convert.FromBase64String(data.File));
            var fileBytes = Encoding.ASCII.GetBytes(file);

            var memory = new MemoryStream(fileBytes);
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, fileType, Path.GetFileName(path));
                //return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}