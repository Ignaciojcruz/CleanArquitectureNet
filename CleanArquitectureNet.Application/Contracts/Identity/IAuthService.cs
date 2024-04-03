using CleanArquitectureNet.Application.Models.Identity;

namespace CleanArquitectureNet.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        
    }
}
