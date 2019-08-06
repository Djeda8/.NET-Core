using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActionResults.Models;

namespace ActionResults.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // /home/helloworld
        public IActionResult HelloWorld()
        {
            return Content("Hello world!");

            // Equivalente a:
            return new ContentResult() { Content = "Hello world!" };
        }

        // /home/EmptyResultTest
        public ActionResult EmptyResultTest()
        {
            return new EmptyResult();
        }

        // /home/DownloadInvoice1
        public IActionResult DownloadInvoice1(int id)
        {
            return File("images/test.jpg", "image/jpg");
        }

        // /home/DownloadInvoice2
        public IActionResult DownloadInvoice2(int id)
        {
            return StatusCode(409); // Conflict 
            // O su alternativa:
            //return new StatusCode(409);
        }

        // /home/ProcessSomething
        public IActionResult ProcessSomething()
        {
            return Ok();
        }

        // /home/Create/2314r2/Paco
        public IActionResult Create(Customer customer)
        {
            CreatedAtActionResult a = CreatedAtAction("Details", "Customer", new { }, customer);

            return a;
            // Alternativa: return new CreatedAtActionResult(...)
        }

        public IActionResult TellmeSomethingAbout(string topic)
        {
            if (topic == "soccer")
            {
                return NoContent();
                // Alternativa: return new NoContentResult();
            }
            else
            {
                return NoContent();
            }
        }
        public IActionResult SayHello(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
                // Alternativa: return new BadRequestResult();
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult SecureAction()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
                // Alternativa: return new UnauthorizedResult();
            }
            else
            {
                return Unauthorized();
            }
        }
        public IActionResult ViewCustomer(int postId)
        {
            Customer customer = new Customer();
            if (customer == null)
            {
                return NotFound("Post not found");
                // Alternativa: return new NotFoundResult("Post not found");
            }
            return View(customer);
        }
        public IActionResult Amazon()
        {
            // Redirección temporal (HTTP 302):
            return Redirect("http://www.amazon.com");
            // Alternativa: return new RedirectResult("http://www.amazon.com");

            // Redirección permanente (HTTP 301):
            return RedirectPermanent("http://www.amazon.com");
            // Alternativa: return new RedirectResult("http://www.amazon.com", true);
        }

        public IActionResult LoginAndGotoPage(string page)
        {
            // Hacemos login
    
            return LocalRedirect(page);
            // Alternativa: return new LocalRedirectResult(page);

            //return LocalRedirectPermantent("/home/index");
        }

        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
                return View("Edit", customer);

            //_customerServices.Update(customer);
            return RedirectToAction("List"); // Redirección temporal a  
                                             // la acción "List" en el controlador actual

            // O podríamos usar RedirectToActionPermanent("List") para una 
            // redirección permanente

            //return RedirectToAction("dashboard", "customers");

            //return RedirectToAction(
            //  "View",           // Acción 
            //  "Products",       // Controlador
            //  new { id = 123 }  // Parámetros
);
        }
    }
}
