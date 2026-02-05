using System;

namespace MyShop.Domain.Lazy;


public interface IValueHolder<T>
{
    T GetValue(object parameter);
}
public class ValueHolder<T> : IValueHolder<T>
{
    private readonly Func<object, T> _getValue;
    private T Value;
    public ValueHolder(Func<object, T> getValue)
    {
        _getValue = getValue;
    }
    public T GetValue(object parameter)
    {
        if (Value == null)
            Value = _getValue(parameter);
        return Value;
    }
}
