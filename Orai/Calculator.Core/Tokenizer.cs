using Calculator.Core.Tokens;
using Calculator.Core.Tokens.Numbers;
using Calculator.Core.Tokens.Operations;

using static System.StringSplitOptions;

namespace Calculator.Core;

internal class Tokenizer : ITokenizer
{
    private readonly Dictionary<string, IToken> _tokens = new()
    {
        ["+"] = new Addition(),
        ["-"] = new Subtraction(),
        ["*"] = new Multiplication(),
        ["/"] = new Division(),
        ["sin"] = new FunctionOperation(Math.Sin),
        ["cos"] = new FunctionOperation(Math.Cos),
        ["tan"] = new FunctionOperation(Math.Tan),
        ["arctan"] = new FunctionOperation(Math.Atan),
        ["arccos"] = new FunctionOperation(Math.Acos),
        ["arcsin"] = new FunctionOperation(Math.Asin),
        ["pi"] = new PiToken(),
        ["e"] = new EToken(),
        ["avg"] = new Average(),
        ["max"] = new Maximum(),
        ["median"] = new Median(),
        ["min"] = new Minimum(),
        ["mode"] = new Mode(),
        ["rms"] = new RootMeanSquare(),
        ["sum"] = new Sum()
    };

    public IEnumerable<IToken> Tokenize(string expression)
    {
        foreach (string part in GetExpressionParts(expression))
        {
            if (_tokens.TryGetValue(part, out IToken? token))
            {
                yield return token;
            }
            else if (double.TryParse(part, out double number))
            {
                yield return new NumberToken(number);
            }
            else
            {
                throw new InvalidOperationException($"Unrecognized expression part: '{part}'");
            }
        }
    }

    private static string[] GetExpressionParts(string expression)
    {
        return expression.Split(' ', TrimEntries | RemoveEmptyEntries);
    }
}