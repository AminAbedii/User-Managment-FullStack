using backend_dotnet8.Core.Dtos.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Services.Interfaces
{
    public interface ILogService
    {
        Task SaveNewLog(string UserName, string Description);
        Task<IEnumerable<GetLogDto>> GetLogsAsync();
        Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User);   //ClaimsPrincipal baraye estefade az authorize va Idendity baraye kaarbare faal hale hazer ast
    }
}
