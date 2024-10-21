namespace Delegate
{
    internal class Program
    {


        public class Employee
        {
            public Guid Id { get; set; }=Guid.NewGuid();
            public string Name { get; set; }
            public string Title { get; set; }


            public Employee(string name, string title  )
            {
                Name = name;
                Title = title;
            
            }



            public event Action<Employee> EmployeeEvent;

            public void AddEmployee()
            {
                Console.WriteLine("Added Employee");

                EmployeeEvent?.Invoke(this);
            }




        }

        public class Club
        {

            public List<Employee> Employee { get; set; }=new List<Employee>();

            public string Name { get; set; }

            public Club(string name)
            {
                
                Name = name;
            }

            public void OnEmployeeAdded(Employee employee)
            {
                Employee.Add(employee);
                Console.WriteLine($"Employee {employee.Name} added to the Club.");
            }


        }
        public class Insurance
        {
            public List<Employee> insuredEmployees = new List<Employee>();

            public void OnEmployeeAdded(Employee employee)
            {
                insuredEmployees.Add(employee);
                Console.WriteLine($"Employee {employee.Name} enrolled in Insurance.");
            }
        }



        static void Main(string[] args)
        {
            

            var emp=new Employee("John", "Developer");

            var club = new Club("CodeClan");

            var insurance = new Insurance();


            emp.EmployeeEvent += club.OnEmployeeAdded;
            emp.EmployeeEvent += insurance.OnEmployeeAdded;


            emp.AddEmployee();


          
        }

       
    }
}
