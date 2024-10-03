﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_dotnet8.DataLayer.Entities
{
    public class Message : BaseEntity<long>
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string Text { get; set; }
    }
}
