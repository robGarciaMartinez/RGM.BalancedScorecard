using BalancedScorecard.Kernel.Domain;

namespace BalancedScorecard.Domain.Model.Objectives
{
    public class ObjectiveType : BaseEntity
    {
        public ObjectiveType(string name, string code)
        {
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}