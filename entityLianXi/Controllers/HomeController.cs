using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entityLianXi.Models;
using System.Data;

namespace entityLianXi.Controllers
{
    public class HomeController : Controller
    {
        //创建数据上下文对象
        ProductEntity PEntity = new ProductEntity();

        public ActionResult Index()
        {
            
            //获取product实体类
            List<Product> pro=PEntity.Products.ToList();
            return View(pro);
        }
        public ActionResult twoIndex()
        {
            return View();
        }
        public string twoIndexDetail(Product pro)
        {
            return "商品名称：" + pro.PName + " 商品价格：" + pro.Pice + " 商品简介：" + pro.Detail;
        }
        public ActionResult AddView()
        {
            return View();
        }

        //添加商品
        public ActionResult AddProduct(Product pro)
        {
            //添加
            PEntity.Products.Add(pro);
            //保存到数据库
            PEntity.SaveChanges();
            return RedirectToAction("Index");
        }

        //删除商品
        public ActionResult Del(int id)//因为路由的关系id必须为id
        {
            //在上下问中寻找是否存在
            Product pro=PEntity.Products.Find(id);
            //存在就删除
            PEntity.Products.Remove(pro);
            //保存
            PEntity.SaveChanges();
            return RedirectToAction("Index");

        }

        //修改商品视图
        public ActionResult update(int id)
        {
            Product pro= PEntity.Products.Find(id);
            return View(pro);
        }

        //修改商品
        public ActionResult UpdateProduct(Product pro)
        {
            PEntity.Entry<Product>(pro).State = System.Data.Entity.EntityState.Modified;
            PEntity.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult search(string PName)
        {
            List<Product> pro=PEntity.Products.Where(p => p.PName.Contains(PName)).ToList();
            return View("Index",pro);

        }
    }
}