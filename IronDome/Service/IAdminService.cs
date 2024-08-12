using IronDome.Models;

namespace IronDome.Service
{
    public interface IAdminService
    {
        Task<AdminModel?> GetAdmin();
        Task UpDateMissleAmount(int newAmount);
        
    }
}
