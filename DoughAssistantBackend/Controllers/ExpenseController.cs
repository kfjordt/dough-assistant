using AutoMapper;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;
        public ExpenseController(IExpenseRepository expenseRepository, IMapper mapper, IAuthenticationRepository authenticationRepository)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _authenticationRepository = authenticationRepository;
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            var sessionKey = HttpContext.Request.Cookies["SessionKey"];

            if (!_authenticationRepository.SessionExists(sessionKey)) 
            {
                return BadRequest("No session found with session key");
            }

            var userId = _authenticationRepository.GetUserBySessionId(sessionKey).UserId;

            var expenses = _expenseRepository.GetExpensesByUserId(userId);
            var expenseDtos = _mapper.Map<List<ExpenseDto>>(expenses);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(expenseDtos);
        }

        [HttpPost]
        public IActionResult PostExpense([FromBody] ExpenseDto expenseDto)
        {
            var sessionKey = HttpContext.Request.Cookies["SessionKey"];

            if (sessionKey == null)
            {
                return BadRequest("Session key was not found in database.");
            }
            
            var user = _authenticationRepository.GetUserBySessionId(sessionKey);

            var expense = _mapper.Map<Expense>(expenseDto);
            expense.UserId = user.UserId;
            expense.ExpenseId = Guid.NewGuid().ToString();

            _expenseRepository.CreateExpense(expense);

            return Ok();
        }
    }
}
