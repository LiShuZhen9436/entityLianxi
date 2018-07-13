using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entityStudent.Models;

namespace entityStudent.Controllers
{
    public class HomeController : Controller
    {
        conEntity entity = new conEntity();
        //列表展示
        public ActionResult Index()
        {
            List<student> stu=entity.student.ToList();
            entity.Database.Log += c => Console.WriteLine(c);
            return View(stu);
        }

        //跳转到添加视图
        public ActionResult Add()
        {
            ViewBag.Gid = new SelectList(entity.grad.ToList(), "Gid", "gName");

            return View();
        }

        //添加
        public ActionResult addStudent(student stu)
        {
            entity.student.Add(stu);
            entity.SaveChanges();
            entity.Database.Log += c => Console.WriteLine(c);
            return RedirectToAction("Index");
        }

        //跳转到修改视图
        public ActionResult upDate(int id)
        {
            student stu=entity.student.Find(id);
            ViewBag.Gid = new SelectList(entity.grad.ToList(), "Gid", "gName",stu.Gid);
            return View(stu);
        }

        //修改
        public ActionResult upDateStudent(student stu)
        {
            entity.Entry<student>(stu).State = System.Data.Entity.EntityState.Modified;
            entity.SaveChanges();
            return RedirectToAction("Index");
        }

        //查询
        public ActionResult Search(string sName,int? age)
        {
            //List<student> stu = entity.student.Where(s => s.sName.Contains(sName) && s.age==age).ToList();
            List<student> stu = entity.student.Where(s =>string.IsNullOrEmpty(sName)?true:s.sName.Contains(sName) && (age==null?true:s.age == age)).ToList();
            return View("Index",stu);
        }

        //删除
        public ActionResult Del(int id)
        {
            student stu= entity.student.Find(id);
            entity.student.Remove(stu);
            bool res=entity.SaveChanges()>0?true:false;
            if (res == true)
            {
                return RedirectToAction("Index");
            }
            else {
                return Content("<script>alert('删除不成功！');location.href='/Home/Index';</script>");
            }
        }

        public ActionResult ajax()
        {
            return View();
        }

        public string ajaxActionShow()
        {
            return "ok";
        }

        public ActionResult addAjax(string sName)
        {
           ViewBag.name = sName;
            return PartialView();//部分视图
        }
    }
}