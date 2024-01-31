using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Generic;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class AdminRepository:BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext context, ILogger<BaseRepository<Admin>> logger) : base(context, logger)
    {
    }
}