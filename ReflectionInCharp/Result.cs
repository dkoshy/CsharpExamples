namespace ReflectionInCharp
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Category { get; set; }

        public T AlterAndReturnValue<Tvalue>(Tvalue value)
        {
            Console.WriteLine("AlterAndReturnValue method is called");
            return default(T);
        }

    }
}
