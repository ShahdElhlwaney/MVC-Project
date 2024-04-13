using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class ProductController : Controller
    {
		#region First 
		// Action
		//  cant be private
		//   cant be static
		//    cant be overload
		//     URL =======> Product/ShowMsg
		/*public string ShowMsg()
        {
            return "Hello World";
        }
        public ContentResult ShowMsg2() { 
            // DECLARE OBJECT   
            var result= new ContentResult();
            // SET VALUES
            result.Content = "CONTENT RESULT";
            // RETURN
            return result;
        }
        public ViewResult ShowView()
        {
            // DECLARE OBJECT   
            var result = new ViewResult();
            // SET VALUES
            result.ViewName = "View1";
            // RETURN
            return result;
        }
        public JsonResult ShowJson()
        {
            var result = new JsonResult(new {Id=1,Name="Shahd"});
            return result;
        }
        //Product/Show/3
        // Product/Show?id=3
        public IActionResult Show(int id)
        {
            if(id%2==0)
            {
                return View("View1");
            }
            else
            {
                return Content("Show Msg");
            }
        }*/
		///  Type The Action Can Return
		///  1- content "string" ===> ContentResult
		///  2- view "HTML" =======> ViewResult
		///  3- JavaScript =====> JavaScriptResult
		///  4- Json ======> JsonResult
		///  5- NotFound ====> NotFoundResult
		///  6- File =======> FileResult
		#endregion
        public IActionResult Details(int id)
        {
            // Model
            ProductSampleData productSampleData=new ProductSampleData();
          var productModel= productSampleData.GetById(id);
            // Send
            return View("ProductDetails", productModel);
        }
	}
}
