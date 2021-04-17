using System;
using System.Collections.Generic;
using System.Linq;

namespace Mortgage.MortgageProcessors
{
    public class AggregateMortgageProcessor : IMortgageProcessor
    {
        private readonly IReadOnlyCollection<IMortgageProcessor> _inners;

        public AggregateMortgageProcessor(IReadOnlyCollection<IMortgageProcessor> inners)
        {
            _inners = inners ?? throw new ArgumentNullException(nameof(inners));
        }

        public MortgageApplicationResult ProcessApplication(MortgageApplication application)
        {
            return _inners.Any(p => p.ProcessApplication(application) == MortgageApplicationResult.Declined)
                ? MortgageApplicationResult.Declined
                : MortgageApplicationResult.Approved;
        }
    }
}
