namespace InvSys.RuleOne.Core.Models
{
    public class Analysis : Rating
    {
        public Meaning Meaning { get; set; }
        public Moat Moat { get; set; }
        public Margin Margin { get; set; }
    }
}
