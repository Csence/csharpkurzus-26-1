namespace Calculator.Core;

internal class NumberStack(int capacity) : INumberStack
{
    private readonly double[] _stack = new double[capacity];
    private int _count = 0;

    public int Count => _count;

    public double Pop()
    {
        if (Count - 1 < 0)
            throw new InvalidOperationException("Not enugh elelements for operation");

        return _stack[--_count];
    }

    public void Push(double number)
    {
        if (Count > capacity - 1)
            throw new InvalidOperationException("Too many elements for operation");

        _stack[_count++] = number;
    }
}