namespace Mortgage.MortgageProcessors
{
    public class MinimumDownpaymentMortgageProcessor : IMortgageProcessor
    {
        private readonly double _minimumDownpaymentPercentage;

        public MinimumDownpaymentMortgageProcessor(double minimumDownpaymentPercentage)
        {
            _minimumDownpaymentPercentage = minimumDownpaymentPercentage;
        }

        public MortgageApplicationResult ProcessApplication(MortgageApplication application)
        {
            return application.DownpaymentPercentage >= _minimumDownpaymentPercentage
                ? MortgageApplicationResult.Approved
                : MortgageApplicationResult.Declined;
        }
    }
}
