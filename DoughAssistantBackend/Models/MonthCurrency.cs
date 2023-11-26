using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models;

public class MonthCurrency
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MonthCurrencyId { get; set; }
    public int MonthIndex { get; set; }
    public int Year { get; set; }
    public string CurrencyCode { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}