using Microsoft.EntityFrameworkCore;
using Data.Pd;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
    }
