using ReflectionMagic;
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

        public static void InstantiatingAndManipulatingObjects()
        {
            var personType = typeof(Person);
            var personConstructor = personType.GetConstructors();
            var privateConstructor = personType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic, null,
                new Type[] { typeof(string), typeof(int) }, null);

            var person1 = personConstructor[0].Invoke(null);
            var person2 = personConstructor[1].Invoke(new object[] { "Deepak" });
            var person3 = privateConstructor.Invoke(new object[] { "Koshy", 38 });

            var person4 = Activator.CreateInstance(personType);
            var person6 = Activator.CreateInstance("ReflectionInCharp", "ReflectionInCharp.Person").Unwrap();

            var person5 = Activator.CreateInstance(personType, new object[] { "Kumar" });
            var person7 = Activator.CreateInstance(personType,
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new object[] {"Raju" ,  39},
                null
                );

            //Instance manupilation

            var nameofPerson7 = person7.GetType().GetProperty("Name");
            nameofPerson7.SetValue(person7,"Bini");

            var ageofPerson7 = person7.GetType().GetField("age");
            ageofPerson7.SetValue(person7, 44);

            var talkmethod = person7.GetType().GetMethod("Talk");
            talkmethod.Invoke(person7, new object[] { "do you have to talk something"});

            person7.GetType().InvokeMember("_aPrivateField",
                BindingFlags.Instance | BindingFlags.NonPublic |BindingFlags.SetField,
                null,
                person7, new object[] { "Changed Private field value" });

            person7.GetType().InvokeMember("Yell", 
                BindingFlags.Instance | BindingFlags.NonPublic |BindingFlags.InvokeMethod,
                null, person7, new object[] { "in the Silence" });


            //getting a value 

            var age = (int) typeof(Person).InvokeMember("age", BindingFlags.GetField, null,
                 person7, null);
            Console.WriteLine($"Reding age of Person7 is {age}");

            Console.WriteLine(person7);

            dynamic p5 = person5;

            p5.Talk("Talking by Person 5 dynamically");
        }

        public static void RflectionOnGenericTypes()
        {
            var personlisttype = typeof(List<Person>);
            Console.WriteLine(personlisttype.Name);
            Console.WriteLine(personlisttype.FullName);
            Console.WriteLine(personlisttype);

            var personlist = Activator.CreateInstance(personlisttype);

            foreach(var args in typeof(Dictionary<int,string>).GenericTypeArguments)
            {
                Console.WriteLine(args);
            } 
            foreach(var args in typeof(Dictionary<int,string>).GetGenericArguments())
            {
                Console.WriteLine(args);
            }
           foreach(var args in typeof(Dictionary<,>).GetGenericArguments())
            {
                Console.WriteLine(args);
            }

            //var openInstance = Activator.CreateInstance(typeof(Result<>)); //This will throw Error

           var closedGenericType = typeof(Result<>).MakeGenericType(typeof(Person));
           var closedPerson = Activator.CreateInstance(closedGenericType);

           var Openmethod = closedGenericType.GetMethod("AlterAndReturnValue");
           var closedMethod = Openmethod.MakeGenericMethod(typeof(string));

           closedMethod.Invoke(closedPerson, new object[] { "Deepak" });
        }

        public static void IocContainerExample()
        {
            var container = new IoCContainer();
            container.Register(typeof(IBeanService<>), typeof(ArabicaBeanService<Catimor>));
            container.Register<IWaterService, TapWaterService>();
            container.Register<ICoffeeService, CoffeeService>();
            var waterService = container.Resolve<IWaterService>();
            Console.WriteLine($"Water service is {waterService.GetType()} Registered");
            var beanService = container.Resolve<IBeanService<Catimor>>();
            Console.WriteLine($"Bean service is {beanService.GetType()} Registered");
            var coffeeService =  container.Resolve<ICoffeeService>();
            Console.WriteLine($"Coffee service is {coffeeService.GetType()} Registered");
        } 
                

        public static void RflectionMagicEaxmple()
        {
            var person = new Person("Deepak");
            Console.WriteLine($"person --- {person}");
            var filedInfo = typeof(Person).GetField("_aPrivateField", BindingFlags.Instance |
                BindingFlags.NonPublic);
            filedInfo.SetValue(person, "Kumar");

            Console.WriteLine($"person --- {person}");

            person.AsDynamic()._aPrivateField = "Deepak";

            Console.WriteLine($"person --- {person}");
        }
    }
}
