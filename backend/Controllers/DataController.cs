using BudgetBffBackend.Contexts;
using BudgetBffBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

[Route("api/expenses")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItemsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult PostItem([FromBody] Expense expense)
    {
        try
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        try
        {
            var expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
