using System;

namespace Mortgage.Builder
{
    internal class OrMortgageProcessor : IMortgageProcessor
    {
        private readonly IMortgageProcessor _first;
        private readonly IMortgageProcessor _second;

        public OrMortgageProcessor(IMortgageProcessor first, IMortgageProcessor second)
        {
            _first = first ?? throw new ArgumentNullException(nameof(first));
            _second = second ?? throw new ArgumentNullException(nameof(second));
        }

        public MortgageApplicationResult ProcessApplication(MortgageApplication application)
        {
            return _first.ProcessApplication(application) == MortgageApplicationResult.Approved
                   || _second.ProcessApplication(application) == MortgageApplicationResult.Approved
                ? MortgageApplicationResult.Approved
                : MortgageApplicationResult.Declined;
        }
    }
}
