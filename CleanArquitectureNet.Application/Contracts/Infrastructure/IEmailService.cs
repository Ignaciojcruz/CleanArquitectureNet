using CleanArquitectureNet.Application.Models;

namespace CleanArquitectureNet.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
