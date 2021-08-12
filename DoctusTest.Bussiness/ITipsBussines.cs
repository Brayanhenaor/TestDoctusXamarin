using System.Collections.Generic;
using System.Threading.Tasks;
using DoctusTest.Entities.Entities;

namespace DoctusTest.Bussiness
{
    public interface ITipsBussines
    {
        Task<IEnumerable<Tip>> GetAllTipsAsync();
        Task SaveTipAsync(Tip tip);
        Task DeleteTipAsync(Tip tip);
        Task UpdateTipAsync(Tip tip);
    }
}
