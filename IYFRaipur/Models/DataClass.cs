using IYFRaipur.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IYFRaipur.Models
{
    public class DataClass:IIdentifiable
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
