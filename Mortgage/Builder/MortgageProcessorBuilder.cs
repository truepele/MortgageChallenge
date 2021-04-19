using System;

namespace Mortgage.Builder
{
    public class MortgageProcessorBuilder
    {
        private IMortgageProcessor _processor;

        public MortgageProcessorBuilder(IMortgageProcessor processor)
        {
            _processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public MortgageProcessorBuilder And(IMortgageProcessor processor)
        {
            _processor = new AndMortgageProcessor(_processor, processor);
            return this;
        }

        public MortgageProcessorBuilder Or(IMortgageProcessor processor)
        {
            _processor = new OrMortgageProcessor(_processor, processor);
            return this;
        }

        public IMortgageProcessor Build()
        {
            return _processor;
        }
    }
}
