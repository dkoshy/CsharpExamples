using Generic.App.Entities;

namespace Generic.App.Rpositories
{

    public class EmployeeRepository
    {
        private readonly List<Employee> employees = new();
       
        public void Add(Employee emp)
        {
            employees.Add(emp);
        }

        public void Save()
        {
            employees.ForEach(e =>
            {
                Console.WriteLine(e);
            });
        }

    }
}
