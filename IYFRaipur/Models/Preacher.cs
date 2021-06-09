using System;
using System.Collections.Generic;
using System.Text;

namespace IYFRaipur.Models
{
    public class Preacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Counselor Counselor { get; set; }
    }
}
