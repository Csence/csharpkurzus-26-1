namespace Calculator.Core.Tokens.Operations;

internal sealed class Multiplication : BinaryOperation
{
    public override int Precedence => OperationPrecedence.Multiplication;

    protected override double Apply(double left, double right) => left * right;
}
