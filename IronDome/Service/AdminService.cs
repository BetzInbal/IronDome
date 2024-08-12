using IronDome.Data;
using IronDome.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDome.Service
{
    public class AdminService : IAdminService

    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminModel?> GetAdmin()
        {
            var admin = await _context.Admin.FirstOrDefaultAsync();
            return admin;

        }

        public async Task UpDateMissleAmount(int newAmount)
        {
            var admin = await _context.Admin.FirstOrDefaultAsync();
            if (admin == null)
                throw new Exception("The admin das'nt found");
            admin.MissileAmount = newAmount;
            _context.SaveChanges();
        }
    }
}

