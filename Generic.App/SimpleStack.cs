// C#  Stack Example

internal class SimpleStack
{
    private int _size;
    private double[] _numbers;
    private int _count = -1;

    public SimpleStack(int size)
    {
        _size = size;
        _numbers = new double[size];

    }

    public int Count  => _count;


    public void Push(double v) 
    {
        if(_count<= _size)
            _numbers[++_count] = v;
        else
            _numbers[_count] = v;
    }
 
    public  double Pop()
    {
        if( _count>=0)
         return _numbers[_count--];
        else
            return  0;
    }
 
}