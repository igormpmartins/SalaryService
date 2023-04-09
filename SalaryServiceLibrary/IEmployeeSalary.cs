using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SalaryServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IEmployeeSalary
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void CreateEmployee(Employee employee);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void CreateSalaryHistory(SalaryHistory salaryHistory);
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Salary { get; set; }
    }

    [DataContract]
    public class SalaryHistory
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public double Salary { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}
