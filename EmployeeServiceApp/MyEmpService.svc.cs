using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyEmpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyEmpService.svc or MyEmpService.svc.cs at the Solution Explorer and start debugging.
    public class MyEmpService : IMyEmpService
    {
        public void DoWork()
        {
        }
        public List<Employee> GetAllUser()
        {
            List<Employee> userlst = new List<Employee>();
            masterEntities1 tstDb = new masterEntities1();
            var lstUsr = from k in tstDb.Employees select k;
            foreach (var item in lstUsr)
            {
                Employee usr = new Employee();
                usr.empId = item.empId;
                usr.FName = item.FName;
                usr.LName = item.LName;
                usr.Email = item.Email;
                usr.Designation = item.Designation;
                userlst.Add(usr);
            }
            return userlst;
        }
        public Employee GetAllUserById(int id)
        {

            masterEntities1 tstDb = new masterEntities1();
            var lstUsr = from k in tstDb.Employees where k.empId == id select k;
            Employee usr = new Employee();
            foreach (var item in lstUsr)
            {
                usr.empId = item.empId;
                usr.FName = item.FName;
                usr.LName = item.LName;
                usr.Email = item.Email;
                usr.Designation = item.Designation;
            }

            return usr;
        }

        public int DeleteUserById(int Id)
        {

            masterEntities1 tstDb = new masterEntities1();
            Employee usrdtl = new Employee();
            usrdtl.empId = Id;
            tstDb.Entry(usrdtl).State = System.Data.Entity.EntityState.Deleted;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddUser(int ID, string FName, string LName, string Email, string Designation)
        {
            masterEntities1 tstDb = new masterEntities1();
            Employee usrdtl = new Employee();
            usrdtl.empId = ID;
            usrdtl.FName = FName;
            usrdtl.LName = LName;
            usrdtl.Email = Email;
            usrdtl.Designation = Designation;
            tstDb.Employees.Add(usrdtl);
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int UpdateUser(int Id, string FName, string LName, string Email, string Designation)
        {
            masterEntities1 tstDb = new masterEntities1();
            Employee usrdtl = new Employee();
            usrdtl.empId = Id;
            usrdtl.FName = FName;
            usrdtl.LName = LName;
            usrdtl.Email = Email;
            usrdtl.Designation = Designation;
            tstDb.Entry(usrdtl).State = System.Data.Entity.EntityState.Modified;

            int Retval = tstDb.SaveChanges();
            return Retval;
        }

    }
}
