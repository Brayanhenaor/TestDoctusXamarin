using System.Collections.Generic;
using System.Threading.Tasks;
using DoctusTest.Data.Context;
using DoctusTest.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctusTest.Bussiness
{
    public class TipsBussines : ITipsBussines
    {
        public async Task<IEnumerable<Tip>> GetAllTipsAsync()
        {
            using(var context = new DatabaseContext())
            {
                return await context.Tips.ToListAsync();
            }
        }

        public async Task SaveTipAsync(Tip tip)
        {
            using (var context = new DatabaseContext())
            {
                await context.Tips.AddAsync(tip);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTipAsync(Tip tip)
        {
            using (var context = new DatabaseContext())
            {
                context.Tips.Remove(tip);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateTipAsync(Tip tip)
        {
            using (var context = new DatabaseContext())
            {
                context.Tips.Update(tip);
                await context.SaveChangesAsync();
            }
        }
    }
}
