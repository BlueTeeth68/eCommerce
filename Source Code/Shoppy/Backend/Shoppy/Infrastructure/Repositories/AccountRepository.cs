using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class AccountRepository:BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context, ILogger<BaseRepository<Account>> logger) : base(context, logger)
    {
    }
}