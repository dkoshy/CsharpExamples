using System.Reflection;

namespace ReflectionInCharp
{
    public  class DemoExamples
    {
        public static void GetBasicTypeDetails()
        {
            var name = "deepak";
            Console.WriteLine(name.GetType().FullName);
            Console.WriteLine(typeof(string).FullName);
        }

        public static void AnalysingCurrentAssebly()
        {
            var curentAsssebly = Assembly.GetExecutingAssembly();

            Console.WriteLine($"Number of Types in Current Assebly {curentAsssebly.GetTypes().Length}");

            foreach(var typeinfo in curentAsssebly.GetTypes())
            {
                Console.WriteLine(typeinfo.FullName);
            }

            //loding a specific type 

            var perontype = curentAsssebly.GetType("ReflectionInCharp.Person");
            Console.WriteLine(perontype.FullName);
        }

        public static void LoadingEternalAssebly()
        {
            var externalaseebly = Assembly.Load("System.Text.Json");
            var externalTypes = externalaseebly.GetTypes();
            var OneExternalspecificType = externalaseebly.GetType("System.Text.Json.JsonDocument");

            var externalModules = externalaseebly.GetModules();
            var onespecificModule = externalaseebly.GetModule("System.Text.Json.dll");
            var alltypes = onespecificModule.GetTypes();

            Console.WriteLine(externalaseebly.FullName);
            Console.WriteLine(externalTypes.Length);
            Console.WriteLine(OneExternalspecificType.FullName);

            Console.WriteLine(externalModules.Length);
            Console.WriteLine(onespecificModule.FullyQualifiedName);
            Console.WriteLine(alltypes.Length);
        }

        public static void AnalysingAspecificType()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var personType = currentAssembly.GetType("ReflectionInCharp.Person");
            var anotherPerson = typeof(Person);

            Console.WriteLine($"Both are same types :- {personType == anotherPerson}");

            Console.WriteLine("Constructors All Public");
            foreach(var con in personType.GetConstructors())
            {
                Console.WriteLine(con);
            }
            Console.WriteLine("All Methods");
            foreach (var m in personType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{m} : {m.IsPublic}");
            }

            Console.WriteLine("All Properties");
            foreach (var f in personType.GetProperties())
            {
                Console.WriteLine($"{f}");
            }

            Console.WriteLine("All Fields");
            foreach (var f in personType.GetFields())
            {
                Console.WriteLine($"{f}");
            }
        }


    }
}
