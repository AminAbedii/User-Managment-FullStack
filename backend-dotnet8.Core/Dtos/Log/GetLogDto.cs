using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Dtos.Log
{
    public class GetLogDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UserName { get; set; }
        public string Description { get; set; }
    }
}
