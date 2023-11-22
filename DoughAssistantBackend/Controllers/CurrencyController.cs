using AutoMapper;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using DoughAssistantBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {

        private readonly CurrencyScraper _currencyScraper;
        public CurrencyController(CurrencyScraper currencyScraper)
        {
            _currencyScraper = currencyScraper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Currency>))]
        public IActionResult GetCurrencies()
        {
            List<Currency> currencies = _currencyScraper.GetCurrencies();
            return Ok(currencies);
        }
    }
}
