using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models;

public class UserConfiguration
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserConfigurationId { get; set; }
    public string DefaultCurrency { get; set; }
    public float DefaultMonthlyLimit { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}