using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Chat.Dimo.Hubs;
using SignalR.Chat.Dimo.Models;
using System.Diagnostics;

namespace SignalR.Chat.Dimo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHubContext<ChatHub, IChatHub> _chatHubContext;

        public HomeController(ILogger<HomeController> logger , IHubContext<ChatHub, IChatHub> chatHubContext)
        {
            _logger = logger;
            _chatHubContext = chatHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //  ChatHub.SendMessage("dd", "dd");
            _chatHubContext.Clients.All.ReceiveMessage("test", "test");
            return View();
        }

        public async void Test()
        {
         //   await ChatHub.SendMessage("dd", "dd");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}