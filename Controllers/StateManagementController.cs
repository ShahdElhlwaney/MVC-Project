using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace FirstProject.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetCookies()
        {
            Response.Cookies.Append("name", "shahd");
            Response.Cookies.Append("age", "20");
            return Content("Data Saved");
        }
        public IActionResult GetCookies()
        {
            string name = Request.Cookies["name"];
            int age = int.Parse(Request.Cookies["age"]);
            return Content($"Data name= {name} age= {age}");
        }
        public IActionResult SetSession()
        {
            
            HttpContext.Session.SetString("name", "shahd");
            HttpContext.Session.SetInt32("age", 20);
            return Content("Session Data Saved");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"Data name= {name} , age= {age} ");
        }
        public IActionResult SetTempData()
        {

            TempData["Msg"] = "Msg Hello Send";
          
            return Content("Data Saved Successfully");
        }
        public IActionResult Get1() 
        {

            string msg = "Data Empty";
            if(TempData.ContainsKey("Msg"))
            {
                // msg = TempData["Msg"].ToString();/// normal read
                msg = TempData.Peek("Msg").ToString();// this doesn't mark the key to delete 
                TempData.Keep(); // return all keys to cookie Don't delete any key
                TempData.Keep("Msg"); // return this key=> Don't delete this key
            }

            return Content(msg);
        }
    }
}
