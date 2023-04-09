using System;
using System.ServiceModel;
using System.Transactions;

namespace SalaryServiceLibrary
{

    [ServiceBehavior(TransactionIsolationLevel = IsolationLevel.Serializable, TransactionTimeout = "00:00:30",
        InstanceContextMode = InstanceContextMode.PerSession, TransactionAutoCompleteOnSessionClose = true)]
    public class EmployeeSalary : IEmployeeSalary
    {
        private int CurrentEmployeeId { get; set; } = 0;

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void CreateEmployee(Employee employee)
        {
            employee.Id = new Random().Next();
            CurrentEmployeeId = employee.Id;

            Console.WriteLine($"Creating employee...{CurrentEmployeeId}");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void CreateSalaryHistory(SalaryHistory salaryHistory)
        {
            Console.WriteLine($"Creating salary history for employee {CurrentEmployeeId}");
        }
    }
}
