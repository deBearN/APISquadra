﻿namespace APISquadra.Models
{
    public class Usuario
    {
        public Guid userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string userEmail { get; set; } = string.Empty;
        public string userPassword { get; set; } = string.Empty;
        public string userPhone { get; set; } = string.Empty;
        public decimal userSalario { get; set; }
        public string userCpf { get; set; } = string.Empty;
        public string userCargo { get; set; } = string.Empty;
    }
}
