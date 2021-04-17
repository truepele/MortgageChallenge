namespace Mortgage
{
    public interface IMortgageProcessor
    {
        MortgageApplicationResult ProcessApplication(MortgageApplication application);
    }
}
