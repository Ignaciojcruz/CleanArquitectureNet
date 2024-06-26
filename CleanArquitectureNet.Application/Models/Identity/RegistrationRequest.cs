﻿namespace CleanArquitectureNet.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
