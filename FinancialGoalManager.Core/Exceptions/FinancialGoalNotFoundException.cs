namespace FiancialGoalManeger.Core.Exceptions;

public class FinancialGoalNotFoundException : Exception
{
    const string message = "Financial Goal Not Found";

    public FinancialGoalNotFoundException() : base(message)
    {
        
    }
}