using Microsoft.AspNetCore.Mvc;
using PersonalBlogMVC.Base;
using PersonalBlogMVC.Models;
using System.Diagnostics;

namespace PersonalBlogMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Posts = SQLOps.GetPostList();
            return View(Posts);
        }

        public IActionResult PostSingle(int PostId)
        {
            var postModel = SQLOps.GetPost(PostId);
            ViewBag.authorModel = SQLOps.GetAuthorById(postModel.AuthorId);
            ViewBag.postList = SQLOps.GetPostList();

            return View(postModel);
        }


        public IActionResult ProfileAuthor(int AuthorId)
        {
            var authorModel = SQLOps.GetAuthorById(AuthorId);

            return View(authorModel);
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}