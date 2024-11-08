using backend_dotnet8.Core.Dtos.Log;
using backend_dotnet8.Core.Services.Interfaces;
using backend_dotnet8.DataLayer.DbContext;
using backend_dotnet8.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Services
{
    public class LogService : ILogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task SaveNewLog(string UserName, string Description)
        {
            var newLog = new Log()
            {
                UserName = UserName,
                Description = Description
            };

            await _context.Logs.AddAsync(newLog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetLogDto>> GetLogsAsync()
        {
            var logs = await _context.Logs
             .Select(q => new GetLogDto
             {
                 CreatedAt = q.CreatedAt,
                 Description = q.Description,
                 UserName = q.UserName,
             })
             .OrderByDescending(q => q.CreatedAt)
             .ToListAsync();
            return logs;
        }

        public async Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User)  //ClaimsPrincipal baraye estefade az authorize va Idendity baraye kaarbare faal hale hazer ast
        {
            var logs = await _context.Logs
            .Where(q => q.UserName == User.Identity.Name)
           .Select(q => new GetLogDto
           {
               CreatedAt = q.CreatedAt,
               Description = q.Description,
               UserName = q.UserName,
           })
           .OrderByDescending(q => q.CreatedAt)
           .ToListAsync();
            return logs;
        }

        
    }
}
