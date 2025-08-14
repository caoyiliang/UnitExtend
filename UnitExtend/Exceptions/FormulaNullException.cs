namespace UnitExtend.Exceptions;

public class FormulaNullException : Exception
{
    public FormulaNullException() : base() { }

    public FormulaNullException(string message) : base(message) { }

    public FormulaNullException(string message, Exception innerException) : base(message, innerException) { }
}
