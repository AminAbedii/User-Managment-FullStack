using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.DataLayer.Entities
{
    public class Log : BaseEntity<long>
    {
        public string? UserName { get; set; }
        public string Description { get; set; }
    }
}
