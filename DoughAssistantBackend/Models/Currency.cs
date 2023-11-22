using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoughAssistantBackend.Models
{
    public class Currency
    {
        public string? CurrencyCode { get; set; }
        public string? Label { get; set; }
        public Trend? Trend { get; set; }
        public float? Rate { get; set; }
    }

    public enum Trend
    {
        None,
        Up,
        Down,
    }
}
