using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        MyDB3Context context = new MyDB3Context();

        public IActionResult Index()
        {
            List<Product> list = new List<Product>();
            List<string> listCode = new List<string>();

            list = context.Products.ToList();
            foreach (Product item in list)
            {
                listCode.Add(item.ProductCode);
            }
            ViewBag.List = list;
            ViewBag.ListCode = listCode;
            return View();
        }
        [HttpPost]
        public IActionResult Filter(string status, string productCode, string pName, string pUnit, string pOldPrice,string pNewPrice, string pImage)
        {
            if (string.IsNullOrEmpty(pName))
                pName = "";
            if (string.IsNullOrEmpty(pUnit))
                pUnit = "";
            if (string.IsNullOrEmpty(pImage))
                pImage = "";
            if (string.IsNullOrEmpty(pOldPrice))
                pOldPrice = "-1";
            if (string.IsNullOrEmpty(pNewPrice))
                pNewPrice = "-1";
            if (status.Equals("display"))
            {
                List<Product> oldlist = new List<Product>();
                List<Product> list = new List<Product>();
                List<string> listCode = new List<string>();

                oldlist = context.Products.ToList();
                foreach (Product item in oldlist)
                {
                    listCode.Add(item.ProductCode);
                    if (item.ProductCode.Equals(productCode))
                    {
                        list.Add(item);
                        ViewBag.pName = item.ProductName;
                        ViewBag.pUnit = item.Unit;
                        ViewBag.pOldPrice = item.Price;
                        ViewBag.pImage = item.Image;
                    }
                        
                }

                

                ViewBag.List = list;
                ViewBag.ListCode = listCode;
                ViewBag.selectedid = productCode;
            }
            if (status.Equals("Name"))
            {
                List<Product> oldlist = new List<Product>();
                List<Product> list = new List<Product>();
                List<string> listCode = new List<string>();

                oldlist = context.Products.ToList();
                foreach (Product item in oldlist)
                {
                    if (item.ProductName.Contains(pName))
                    {
                        list.Add(item);
                        
                    }

                }
                foreach (Product item in oldlist)
                {
                    listCode.Add(item.ProductCode);
                }


                ViewBag.List = list;
                ViewBag.ListCode = listCode;
                ViewBag.selectedid = productCode;
            }
            if (status.Equals("Image"))
            {
                List<Product> oldlist = new List<Product>();
                List<Product> list = new List<Product>();
                List<string> listCode = new List<string>();

                oldlist = context.Products.ToList();
                foreach (Product item in oldlist)
                {
                    if (item.Image.Contains(pImage))
                    {
                        list.Add(item);

                    }

                }
                foreach (Product item in oldlist)
                {
                    listCode.Add(item.ProductCode);
                }


                ViewBag.List = list;
                ViewBag.ListCode = listCode;
                ViewBag.selectedid = productCode;
            }
            if (status.Equals("Price"))
            {
                List<Product> oldlist = new List<Product>();
                List<Product> list = new List<Product>();
                List<string> listCode = new List<string>();

                oldlist = context.Products.ToList();
                foreach (Product item in oldlist)
                {
                    if (item.Price>=float.Parse(pOldPrice)&& item.Price <= float.Parse(pNewPrice))
                    {
                        list.Add(item);

                    }

                }
                foreach (Product item in oldlist)
                {
                    listCode.Add(item.ProductCode);
                }


                ViewBag.List = list;
                ViewBag.ListCode = listCode;
                ViewBag.selectedid = productCode;
            }

            if (status.Equals("Update"))
            {
                List<Product> oldlist = new List<Product>();
                List<Product> list = new List<Product>();
                List<string> listCode = new List<string>();

                oldlist = context.Products.ToList();
                foreach (Product item in oldlist)
                {
                    if (item.ProductCode == productCode)
                    {
                        if(!pName.Equals(""))
                        item.ProductName = pName;
                        if (!pNewPrice.Equals("-1"))
                            item.Price = float.Parse(pNewPrice);
                        if (!pUnit.Equals(""))

                            item.Unit = pUnit;
                        if (!pImage.Equals(""))

                            item.Image = pImage;
                        context.SaveChanges();
                    }

                }
                

                ViewBag.List = list;
                ViewBag.ListCode = listCode;
                ViewBag.selectedid = productCode;
                return RedirectToAction("Index");
            }
            return PartialView("/Views/Home/Index.cshtml");
        }


    }
}
