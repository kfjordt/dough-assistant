using DoughAssistantBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoughAssistantBackend.Dto
{
    public class ExpenseDto
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Time {  get; set; }
        public string CurrencyCode { get; set; }
    }
}
