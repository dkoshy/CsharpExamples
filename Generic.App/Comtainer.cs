using System.Drawing;

namespace Generic.App
{
    public class ContainerBase
    {
        public static int NumberOfInstanceBase;
        public ContainerBase() => NumberOfInstanceBase++;
        
    }

    public class Container<T> :ContainerBase
    {
        public static int NumberOfContaineInstance;

        public Container() => NumberOfContaineInstance++;

    }

    

}
