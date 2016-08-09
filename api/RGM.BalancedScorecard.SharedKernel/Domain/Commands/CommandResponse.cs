namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class CommandHandlerResponse
    {
        public CommandHandlerResponse()
        {
            
        }

        public CommandHandlerResponse(List<string> errors)
        {
            this.Errors = errors;
        }

        public List<string> Errors { get; }

        public bool Successful => this.Errors == null || !this.Errors.Any();
    }
}
