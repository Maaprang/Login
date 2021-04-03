
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login.database;
namespace Login.Controllers
{
    public class HomeController : Controller
    {

        private Database ConDB = new Database();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // login show webpage interface
        public IActionResult Login(){

           return View();
           
        
        }
        // Login page controller || This function to check the username andd password form database;
        [HttpPost]
        public IActionResult Login(string username, string password){
          DataTable user = ConDB.GetData($"select * from user where usename = '{username}';");
          if (user.Rows.Count > 0){
              if(user.Rows[0]["password"].ToString() == password){
                  HttpContext.Session.SetString("login", "1");
                  return RedirectToAction("Index","Home");
              }
              else{
                  return View();
              }
          }
          return View();
        }
        // this function to check cookkie function that login = 1 or not 
         private bool CheckLogin()
        {
            bool result = false;
            if (HttpContext.Session.GetString("login") != null)
            {
                if (HttpContext.Session.GetString("login") == "1")
                {
                    return true;
                }

            }
            return result;
        }
     
        public IActionResult Logout(){
        
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }



        public IActionResult Index()
        {
            if (CheckLogin() == true){
                return View();
                }
                else{
                    return RedirectToAction("Login","Home");
                }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        
    }
    

}
