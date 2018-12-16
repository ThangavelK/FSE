using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmpApp.Models;

namespace MVCEmpApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.MyEmpServiceClient ur = new ServiceReference1.MyEmpServiceClient();
        public ActionResult Index()
        {
            List<EmpModel> lstRecord = new List<EmpModel>();
            var lst = ur.GetAllUser();
            foreach (var item in lst)
            {
                EmpModel usr = new EmpModel();
                usr.empId = item.empId;
                usr.FName = item.FName;
                usr.LName = item.LName;
                usr.Email = item.Email;
                usr.Designation = item.Designation;
                lstRecord.Add(usr);
            }
            return View(lstRecord);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(EmpModel mdl)
        {
            EmpModel usr = new EmpModel();
            usr.empId = mdl.empId;
            usr.FName = mdl.FName;
            usr.LName = mdl.LName;
            usr.Email = mdl.Email;
            usr.Designation = mdl.Designation;
            ur.AddUser(usr.empId,usr.FName,usr.LName, usr.Email,usr.Designation);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Delete(int id)
        {
            int retval = ur.DeleteUserById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var lst = ur.GetAllUserById(id);
            EmpModel usr = new EmpModel();
            usr.empId = lst.empId;
            usr.FName = lst.FName;
            usr.LName = lst.LName;
            usr.Email = lst.Email;
            usr.Designation = lst.Designation;
            return View(usr);

        }
        [HttpPost]
        public ActionResult Edit(EmpModel mdl)
        {
            EmpModel usr = new EmpModel();
            usr.empId = mdl.empId;
            usr.FName = mdl.FName;
            usr.LName = mdl.LName;
            usr.Email = mdl.Email;
            usr.Designation = mdl.Designation;


            int Retval = ur.UpdateUser(usr.empId, usr.FName, usr.LName, usr.Email, usr.Designation);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}