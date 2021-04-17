namespace Mortgage.MortgageProcessors
{
    public class MaxPropertyValueMortgageProcessor : IMortgageProcessor
    {
        private readonly double _maxPropertyValue;

        public MaxPropertyValueMortgageProcessor(double maxPropertyValue)
        {
            _maxPropertyValue = maxPropertyValue;
        }

        public MortgageApplicationResult ProcessApplication(MortgageApplication application)
        {
            return application.PropertyValue <= _maxPropertyValue
                ? MortgageApplicationResult.Approved
                : MortgageApplicationResult.Declined;
        }
    }
}
