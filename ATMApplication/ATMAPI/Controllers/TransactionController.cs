using ATMAPI.Models;
using ATMAPI.Models.DTOs;
using ATMAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionRepository transactionRepo, IMapper mapper)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransactionHistory()
        {
            var obj = _transactionRepo.GetTransactionHistory();
            var lstTransactionHistory = new List<TransactionDTO>();
            foreach (var item in obj)
            {
                lstTransactionHistory.Add(_mapper.Map<TransactionDTO>(item));
            }
            return Ok(lstTransactionHistory);

        }
        [HttpPost]
        public IActionResult SaveTransactionDetails([FromBody] TransactionDTO transDTO)
        {
            var transactioDetailsObj = _mapper.Map<Transaction>(transDTO);
            if (transDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (!_transactionRepo.SaveTransactionDetails(transactioDetailsObj))
            {
                ModelState.AddModelError("", "Something went wrong when updating the record ");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
