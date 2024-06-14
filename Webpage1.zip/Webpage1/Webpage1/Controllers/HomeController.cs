using System.Linq;
using System.Web.Mvc;
using Webpage1.Models;

namespace Webpage1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home/Index
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        // GET: Home/OtherPage
        public ActionResult OtherPage()
        {
            return View();
        }

        // GET: Home/ProductDetails/{id}
        public ActionResult ProductDetails(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Home/GiftProduct
        [HttpPost]
        public ActionResult GiftProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                // Perform any necessary actions (e.g., add to cart, update database, etc.)
                TempData["SuccessMessage"] = "Product added successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add product!";
            }

            return RedirectToAction("GiftConfirmation");
        }

        // GET: Home/GiftConfirmation
        public ActionResult GiftConfirmation()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
