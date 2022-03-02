using ATMAPI.Models;
using ATMAPI.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.ATMMapper
{
    public class ATMMappings : Profile
    {
        public ATMMappings()
        {
            CreateMap<BankAccount, BankAccountDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}
