using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class BindController : Controller
    {
        // Model Binding: Map action parameters with request data (Form Data - Query String - Root Data)
        // Bind Primitive Type
        /// Bind/TestPrimitiveType?name=Shahd&age=20
        public IActionResult TestPrimitiveType(string name, int age)
        {
            return Content($"name={name},age={age}");
        }
        // Bind Collection Type
        // Dictionary => key,value

        // Bind/TestCollection?name=shahd&phones[shahd]=123
        public IActionResult TestCollection(string name, Dictionary<string,int> phones)
        {
            return Content($"name={name}");
        }
        // Binding Custom/complex type
        // Bind/TestComplex?Id=1&Name=shahd&ManagerName=omar
        public IActionResult TestComplex(
            [Bind(include:"Id,Name")]//get only the id and name value
            Department d)
        {
            return Content($"name={d.Name}");
        }
    }
  
}

