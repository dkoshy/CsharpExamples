using Generic.App.Data;
using Generic.App.Entities;
using Generic.App.Rpositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generic.App
{
    public static class Examples
    {
        public static void NonGenricStack()
        {
            var numberStack = new SimpleStack(10);

            numberStack.Push(5.4);
            numberStack.Push(6.7);
            numberStack.Push(8.1);
            numberStack.Push(9.0);

            while (numberStack.Count >= 0)
            {
                Console.WriteLine(numberStack.Pop());
            }
        }
        public static void GenericStack()
        {
            var namestack = new SimpleStack<string>(10);

            namestack.Push("Asish");
            namestack.Push("Nirmal");
            namestack.Push("Rehan");
            namestack.Push("Sohiab");
            namestack.Push("Riju");
            namestack.Push("Ravi");

            while (namestack.Count >=0)
            {
                Console.WriteLine(namestack.Pop());
            }

        }
        public static void EmployeeDetail()
        {
            var employeeData = new EmployeeRepository();
            employeeData.Add(new Employee { Id=101, FirstName="Deepak" });
            employeeData.Add(new Employee { Id=102, FirstName="Kumar" });
            employeeData.Add(new Employee { Id=103, FirstName="Raju" });

            employeeData.Save();
        }
        public static void ListRepoGenericDetails()
        {
            ListRepository<Employee> employeeData = new ListRepository<Employee>();
            ListRepository<Organisation> orgs = new ListRepository<Organisation>();
            AddEmployeeToRepo(employeeData);
            AddOrgToRepo(orgs);
            employeeData.Save();
            orgs.Save();

            WriteToConsole(employeeData);
            WriteToConsole(orgs);
            //get employee with id 102

            var empwithId102 = employeeData.GetById(102);
            employeeData.Remove(empwithId102);
            Console.WriteLine(empwithId102 +  " is removed.");

        }
        public static void SqlRepoGenericDetails()
        {
            var dataContext = new SqlInmemmoryDbContext();
            SqlRepository<Employee> employeeData = new SqlRepository<Employee>(dataContext);

            SqlRepository<Organisation> orgs = new SqlRepository<Organisation>(dataContext);

            AddEmployeeToRepo(employeeData);
            AddManagersToRepo(employeeData);
            employeeData.Save();

            AddOrgToRepo(orgs);
            orgs.Save();

            WriteToConsole(employeeData);
            WriteToConsole(orgs);
            //get employee with id 102

            var empwithId102 = employeeData.GetById(102);
            employeeData.Remove(empwithId102);
            Console.WriteLine(empwithId102 +  " is removed.");

        }
        public static void SqlRepoGenericBatchDetails()
        {
            var dataContext = new SqlInmemmoryDbContext();
            SqlRepository<Employee> employeerepo = new SqlRepository<Employee>(dataContext);

            SqlRepository<Organisation> orgsrepo = new SqlRepository<Organisation>(dataContext);

            //AddBatch(employeerepo,
            //new List<Employee> { new Employee { Id=101, FirstName="Deepak" } ,
            //new Manager { Id=102, FirstName="Riju" }});

            employeerepo.AddBatch(new List<Employee> { new Employee { Id=101, FirstName="Deepak" } ,
            new Manager { Id=102, FirstName="Riju" }});


            employeerepo.Save();

            //AddBatch(orgsrepo, new List<Organisation> { new Organisation { Id=1001, Name="Infosys" } });
            
            orgsrepo.AddBatch(new List<Organisation> { new Organisation { Id=1001, Name="Infosys" } });
            orgsrepo.Save();

            WriteToConsole(employeerepo);
            WriteToConsole(orgsrepo);
            //get employee with id 102

            var empwithId102 = employeerepo.GetById(102);
            employeerepo.Remove(empwithId102);
            Console.WriteLine(empwithId102 +  " is removed.");

        }
        public static void SqlRepoGenericWithDelegateDetails()
        {
            var dataContext = new SqlInmemmoryDbContext();
           
            SqlRepositoryWitDelegate<Employee> employeerepo = new SqlRepositoryWitDelegate<Employee>(dataContext , ItemAddedtoRepo);

            SqlRepositoryWitDelegate<Organisation> orgsrepo = new SqlRepositoryWitDelegate<Organisation>(dataContext , ItemAddedtoRepo);

            //AddBatch(employeerepo,
            //new List<Employee> { new Employee { Id=101, FirstName="Deepak" } ,
            //new Manager { Id=102, FirstName="Riju" }});

            employeerepo.AddBatch(new List<Employee> { new Employee { Id=101, FirstName="Deepak" } ,
            new Manager { Id=102, FirstName="Riju" }});


            employeerepo.Save();

            //AddBatch(orgsrepo, new List<Organisation> { new Organisation { Id=1001, Name="Infosys" } });

            orgsrepo.AddBatch(new List<Organisation> { new Organisation { Id=1001, Name="Infosys" } });
            orgsrepo.Save();

            WriteToConsole(employeerepo);
            WriteToConsole(orgsrepo);
            //get employee with id 102

            var empwithId102 = employeerepo.GetById(102);
            employeerepo.Remove(empwithId102);
            Console.WriteLine(empwithId102 +  " is removed.");

        }
        public static void SqlRepoGenericWithevent()
        {
            var dataContext = new SqlInmemmoryDbContext();

            SqlRepositoryWithevent<Employee> employeerepo = new SqlRepositoryWithevent<Employee>(dataContext);
            employeerepo.ItemAddedCallback+=repoEventHandler_ItemAddedCallback; ;
            SqlRepositoryWithevent<Organisation> orgsrepo = new SqlRepositoryWithevent<Organisation>(dataContext);
            orgsrepo.ItemAddedCallback+=repoEventHandler_ItemAddedCallback;



            employeerepo.AddBatch(new List<Employee> { new Employee { Id=101, FirstName="Deepak" } ,
            new Manager { Id=102, FirstName="Riju" }});


            employeerepo.Save();


            orgsrepo.AddBatch(new List<Organisation> { new Organisation { Id=1001, Name="Infosys" } });
            orgsrepo.Save();

            WriteToConsole(employeerepo);
            WriteToConsole(orgsrepo);
            //get employee with id 102

            var empwithId102 = employeerepo.GetById(102);
            employeerepo.Remove(empwithId102);
            Console.WriteLine(empwithId102 +  " is removed.");

        }

        public static void SpecialCases()
        {
            new Container<int>();
            new Container<string>();
            new Container<string>();

            Console.WriteLine($"Number of Int Istance {Container<int>.NumberOfContaineInstance}");
            Console.WriteLine($"Number of String Istance {Container<string>.NumberOfContaineInstance}");
            Console.WriteLine($"Total Number of cotainer Istance {ContainerBase.NumberOfInstanceBase}");

            Console.WriteLine($"{Add(5,2)}");
            Console.WriteLine($"{Add(5m,2m)}");
            Console.WriteLine($"{Add<float>(5,2)}");
        }
        
        #region Private Methods
        private static void WriteToConsole(IReadRepository<IEntity> repository) //Repository should be Covarient
        {
            var alitems = repository.GetAll();
            foreach (var item in alitems)
                Console.WriteLine(item);
        }
        private static void AddEmployeeToRepo(IWriteRepository<Employee> repository)
        {
            repository.Add(new Employee { Id=101, FirstName="Deepak" });
            repository.Add(new Employee { Id=102, FirstName="Kumar" });
            repository.Add(new Employee { Id=103, FirstName="Raju" });

            repository.Add(new Manager { Id=104, FirstName="Akash" });
            repository.Add(new Manager { Id=105, FirstName="Jayram" });

        }

        private static void AddOrgToRepo(IWriteRepository<Organisation> repository)
        {
            repository.Add(new Organisation { Id=1001, Name="Infosys" });
            repository.Add(new Organisation { Id=1002, Name="Plursigth" });
            repository.Add(new Organisation { Id=1003, Name="TGS" });
            repository.Add(new Organisation { Id=1004, Name="CTS" });
            repository.Add(new Organisation { Id=1005, Name="Harman" });

        }

        private static void AddManagersToRepo(IWriteRepository<Manager> repository)
        {
            repository.Add(new Manager { Id=106, FirstName="Ratheesh" });
        }

        //genric methods
        private static void AddBatch<T>(IRepository<T> repo,List<T> items) 
            where T:IEntity
        {
            items.ForEach(t => repo.Add(t));
        }
        private static void ItemAddedtoRepo(IEntity item)
        {
            item.ItemMessage();
        }

        private static void repo_ItemAddedCallback(IEntity item)
        {
            item.ItemMessage();
        }

        private static void repoEventHandler_ItemAddedCallback(object sender, IEntity e)
        {
            e.ItemMessage();
        }

        private static T Add<T>(T a , T b)
            where T:struct
        {
            dynamic aa = a;
            dynamic bb = b;

            return  (T) (aa / bb);
        }

        #endregion

    }
}
