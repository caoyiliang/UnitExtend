using Flee.PublicTypes;

namespace UnitExtend;

internal class Calculator
{
    private readonly ExpressionContext _expressionContext;
    public Calculator()
    {
        _expressionContext = new ExpressionContext();
        _expressionContext.Imports.AddType(typeof(Math));
    }

    public decimal Compute(string formula)
    {
        try
        {
            IDynamicExpression eDynamic = _expressionContext.CompileDynamic(formula);
            return Convert.ToDecimal(eDynamic.Evaluate());

        }
        catch (Exception)
        {
            throw;
        }
    }
}
