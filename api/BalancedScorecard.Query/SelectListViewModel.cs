using System;

namespace BalancedScorecard.Query
{
    public class SelectListViewModel
    {
        public SelectListViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
