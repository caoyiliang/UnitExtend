using UnitExtend.Exceptions;

namespace UnitExtend;

public static class UnitExtend
{
    public static bool CheckFormula(this string? formula)
    {
        if (string.IsNullOrWhiteSpace(formula))
            return false;
        var form = formula;
        form = form.Replace("$self", "1");
        form = form.Replace("$mol", "1");
        try
        {
            var calculator = new Calculator();
            calculator.Compute(form);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public static decimal ConvertUnit(this decimal value, string? formula, decimal? mol = null)
    {
        if (string.IsNullOrEmpty(formula)) throw new FormulaNullException();
        if (formula.Equals("$self")) return value;
        if (formula.Contains("$mol"))
        {
            if (mol != null)
            {
                formula = formula.Replace("$mol", mol.ToString());
            }
            else
            {
                formula = formula.Replace("$mol", "1");
            }
        }
        formula = formula.Replace("$self", value.ToString());
        var calculator = new Calculator();
        return calculator.Compute(formula);
    }
}