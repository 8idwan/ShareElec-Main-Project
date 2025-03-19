using Microsoft.AspNetCore.Mvc;
using SherElec_Back_end.DTOs.Transaction;
using SherElec_Back_end.Services.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace SherElec_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
         private readonly IUserService _userService;

        public TransactionController(ITransactionService transactionService, IMapper mapper , IUserService userService)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionResponseDTO>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
            var transactionDto = _mapper.Map<TransactionResponseDTO>(transaction);

            return Ok(transactionDto);
        }

        [HttpPost("create")]
        public async Task<ActionResult<TransactionResponseDTO>> CreateTransaction([FromBody] TransactionRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await _transactionService.CreateTransactionAsync(request.IdAcheteur, request.IdVendeur, request.Quantite, request.OffreId);
            var transactionDto = _mapper.Map<TransactionResponseDTO>(transaction); // Mappage vers DTO

            return Ok(transactionDto);
        }

        [HttpGet("vendues/{vendeurId}")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDTO>>> GetTransactionsVendues(int vendeurId)
        {
            var transactions = await _transactionService.GetTransactionsVenduesAsync(vendeurId);
            return Ok(transactions);
        }

        [HttpGet("achetees/{acheteurId}")]
        public async Task<ActionResult<IEnumerable<TransactionResponseDTO>>> GetTransactionsAchetees(int acheteurId)
        {
            var transactions = await _transactionService.GetTransactionsAcheteesAsync(acheteurId);
            return Ok(transactions);
        }
    }
}