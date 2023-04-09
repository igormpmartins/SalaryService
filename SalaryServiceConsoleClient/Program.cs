using SalaryServiceConsoleClient.SalaryServiceReference;
using System.Transactions;

namespace SalaryServiceConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var transaction = new TransactionScope())
            {
                using (var client = new EmployeeSalaryClient())
                {
                    var employee = new Employee { Name = "Someone" };
                    client.CreateEmployee(employee);

                    var salaryHistory = new SalaryHistory { Salary = 7777 };
                    client.CreateSalaryHistory(salaryHistory);
                    transaction.Complete();
                }
            }
        }
    }
}
