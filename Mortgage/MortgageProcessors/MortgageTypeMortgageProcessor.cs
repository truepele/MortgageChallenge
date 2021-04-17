namespace Mortgage.MortgageProcessors
{
    public class MortgageTypeMortgageProcessor : IMortgageProcessor
    {
        public MortgageApplicationResult ProcessApplication(MortgageApplication application)
        {
            return application.MortgageType == MortgageType.Fixed
                ? MortgageApplicationResult.Approved
                : MortgageApplicationResult.Declined;
        }
    }
}
