using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyEmpService" in both code and config file together.
    [ServiceContract]
    public interface IMyEmpService
    {
        [OperationContract]
        List<Employee> GetAllUser();
        [OperationContract]
        int AddUser(int ID, string FName, string LName, string Email, string Designation);
        [OperationContract]
        Employee GetAllUserById(int id);

        [OperationContract]
        int UpdateUser(int Id, string FName, string LName, string Email, string Designation);

        [OperationContract]
        int DeleteUserById(int Id);

    }
    [DataContract]
    public class Employees
    {
        [DataMember]
        public int empId { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Designation { get; set; }


    }
}
