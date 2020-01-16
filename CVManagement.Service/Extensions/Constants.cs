using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Extensions
{
    public class Constants
    {
        public class StatusInt
        {
            public const int Close = 0;
            public const int Open = 1;
            public const int Process = 2;
        }
        public class StatusString
        {
            public const string Close = "Close";
            public const string Open = "Open";
            public const string Process = "Process";
            public const string NoStatus = "No Status";
        }
    }
}
