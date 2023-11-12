namespace DoughAssistantBackend.Models
{
    public class Expense
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public User User { get; set; }

    }
}
