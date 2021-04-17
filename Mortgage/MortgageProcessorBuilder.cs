using System;
using System.Collections.Generic;
using Mortgage.MortgageProcessors;

namespace Mortgage
{
    public class MortgageProcessorBuilder
    {
        private readonly List<IMortgageProcessor> _processors = new();

        public MortgageProcessorBuilder(IMortgageProcessor processor)
        {
            if (processor == null) throw new ArgumentNullException(nameof(processor));
            _processors.Add(processor);
        }

        public MortgageProcessorBuilder Add(IMortgageProcessor processor)
        {
            _processors.Add(processor);
            return this;
        }

        public IMortgageProcessor Build()
        {
            return new AggregateMortgageProcessor(_processors);
        }
    }
}
