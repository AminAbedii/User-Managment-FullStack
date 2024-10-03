using backend_dotnet8.Core.Dtos.General;
using backend_dotnet8.Core.Dtos.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Services.Interfaces
{
    public interface IMessageService
    {
        Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessageDto);
        Task<IEnumerable<GetMessageDto>> GetMessagesAsync();
        Task<IEnumerable<GetMessageDto>> GetMyMessagesAsync(ClaimsPrincipal User);
    }
}
