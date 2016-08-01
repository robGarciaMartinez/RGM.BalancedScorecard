namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class CommandHandlerResponse
    {
        public CommandHandlerResponse()
        {
            this.Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public bool Successful => this.Errors.Any();
    }
}
