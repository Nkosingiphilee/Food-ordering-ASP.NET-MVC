using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppECart.Models;
using WebAppECart.ViewModel;
using WebAppECart;
using System.Collections.Specialized;
using System.Net;
using System.Data.Entity;

namespace WebAppECart.Controllers
{
    public class ItemController : Controller
    {
        private onlineshopEntities onlineshopEntities;

        public ItemController()
        {
            onlineshopEntities = new onlineshopEntities();
        }
        public ActionResult Items() 
        {  
             
            return View(onlineshopEntities.Items.ToList()); 
        }
        public ActionResult Index()
        {
            ItemView itemView = new ItemView();
            itemView.CategorySelectListItem = (from objcat in onlineshopEntities.Categories
                                               select new SelectListItem
                                               {
                                                   Text = objcat.CategoryName,
                                                   Value=objcat.CategoryId.ToString(),
                                                   Selected = true
                                               }

                ) ;
            return View(itemView);
        }

        [HttpPost]
        public JsonResult Index(ItemView itemView)
        {

            Item objItem = new Item();

            objItem.ImagePath = itemView.ImagePath;
            objItem.CategoryId =itemView.CategoryId;
            objItem.Description =itemView.Description;  
            objItem.ItemName = itemView.ItemName;
            objItem.ItemPtice =itemView.ItemPrice;
            onlineshopEntities.Items.Add(objItem);
            onlineshopEntities.SaveChanges();

            return Json(new { Success = true, Message = "Item is added Successfully." }, JsonRequestBehavior.AllowGet);
        }


       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item items = onlineshopEntities.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item items = onlineshopEntities.Items.Find(id);
            onlineshopEntities.Items.Remove(items);
            onlineshopEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = onlineshopEntities.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(onlineshopEntities.Categories, "CategoryId", "CategoryName", item.CategoryId);
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,Description,CategoryId,ImagePath,ItemPtice")] Item item)
        {
            if (ModelState.IsValid)
            {
                onlineshopEntities.Entry(item).State = EntityState.Modified;
                onlineshopEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(onlineshopEntities.Categories, "CategoryId", "CategoryName", item.CategoryId);
            return View(item);
        }



    }
}
