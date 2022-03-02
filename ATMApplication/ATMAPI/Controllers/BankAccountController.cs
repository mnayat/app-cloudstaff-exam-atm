using ATMAPI.Models;
using ATMAPI.Models.DTOs;
using ATMAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepository _bankAccountRepo;
        private readonly IMapper _mapper;
        public BankAccountController(IBankAccountRepository bankAccountRepo, IMapper mapper)
        {
            _bankAccountRepo = bankAccountRepo;
            _mapper = mapper;
        }

        [HttpGet("{accountNumber:long}", Name = "GetBankAccountDetails")]
        public  IActionResult GetBankAccountDetails(long accountNumber)
        {
            var bankAccount = _bankAccountRepo.GetBankAccountDetails(accountNumber);
            if(bankAccount == null)
            {
                return NotFound();
            }
            var bankAccountDTO = _mapper.Map<BankAccountDTO>(bankAccount);
            return Ok(bankAccountDTO);
        }

        [HttpPatch("{bankAccountId:int}", Name = "UpdateBankAccountDetails")]
        public IActionResult UpdateAccountBalance(int bankAccountId, [FromBody] BankAccountDTO bankAccountDTO)
        {
            var bankAccountDTObj = _mapper.Map<BankAccount>(bankAccountDTO);
            if (bankAccountDTO == null || bankAccountId != bankAccountDTO.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_bankAccountRepo.UpdateBankAccountCurrentBalance(bankAccountDTObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record for  {bankAccountDTO.FullName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
