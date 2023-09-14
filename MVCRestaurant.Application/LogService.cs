using Microsoft.EntityFrameworkCore;
using MVCRestaurant.Application.Utility;
using MVCRestaurant.Infrastructure;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application
{
    public class LogService
    {
        private readonly AppDbContext _ctx;

        public LogService(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddLog(string UserId, string Description, bool EncounteredError)
        {
            await _ctx.Logs.AddAsync(new Log()
            {
                UserId = UserId,
                Description = Description,
                ErrorEncountered = EncounteredError,
                SubmitDate = DateTime.Now
            });
            await _ctx.SaveChangesAsync();
        }

        public async Task AddLog(ClaimsPrincipal user, string Description, bool EncounteredError)
        {
            await _ctx.Logs.AddAsync(new Log()
            {
                UserId = user.FindFirstValue("AltKey") ?? "N/A",
                Description = Description,
                ErrorEncountered = EncounteredError,
                SubmitDate = DateTime.Now
            });
            await _ctx.SaveChangesAsync();
        }

        public async Task<(List<Log>, int)> GetLogs(int pageNum)
        {
            return (await _ctx.Logs.OrderByDescending(x => x.SubmitDate).Page(20, pageNum).ToListAsync(),
                (int)Math.Ceiling(await _ctx.Logs.CountAsync()/20f));
        }
    }
}
