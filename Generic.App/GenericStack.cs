namespace Generic.App
{
    public class SimpleStack<T>
    {
        private readonly int _size;
        private  T[] values;
        private int _count = -1;

        public SimpleStack(int size)
        {
            _size=size;
            values = new T[_size];
        }

        public int Count => _count;

        public T Pop()
        {
            if(_count>=0)
                return values[_count--];

            return default;
        }

        public void Push(T value)
        {
            if (_count<_size)
                values[++_count] = value;

            values[_count] = value;
        }


    }
}
