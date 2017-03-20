using RGM.BalancedScorecard.Kernel.Domain.Model;

namespace RGM.BalancedScorecard.Domain.Model.Objectives
{
    public class ObjectiveType : DomainEntity
    {
        public ObjectiveType(string name, string code)
        {
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}