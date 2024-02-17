namespace FiancialGoalManeger.Core.Exceptions;

public class TransactionNotFoundException : Exception
{
    const string message = "Transaction Not Found";

    public TransactionNotFoundException() : base(message)
    {
    }
}