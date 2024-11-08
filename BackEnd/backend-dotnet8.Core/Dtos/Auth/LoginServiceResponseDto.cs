﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.Core.Dtos.Auth
{
    public class LoginServiceResponseDto
    {
        public string NewToken { get; set; }

        // This would be returned to front-end
        public UserInfoResult UserInfo { get; set; }
    }
}
