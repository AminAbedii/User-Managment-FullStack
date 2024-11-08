using backend_dotnet8.Core.Dtos.Auth;
using backend_dotnet8.Core.Dtos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<GeneralServiceResponseDto> SeedRolesAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginServiceResponseDto?> LoginAsync(LoginDto loginDto);
        Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);  //ClaimsPrincipal baraye estefade az authorize va Idendity baraye kaarbare faal hale hazer ast
        Task<LoginServiceResponseDto?> MeAsync(MeDto meDto);
        Task<IEnumerable<UserInfoResult>> GetUsersListAsync();
        Task<UserInfoResult?> GetUserDetailsByUserNameAsync(string userName);
        Task<IEnumerable<string>> GetUsernamesListAsync();
    }
}
