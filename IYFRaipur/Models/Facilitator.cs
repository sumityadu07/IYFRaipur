﻿namespace IYFRaipur.Models
{
    public class Facilitator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Preacher Preacher { get; set; }
    }
}