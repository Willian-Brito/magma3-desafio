namespace Magma3.API.Interfaces;

public interface IAuthService
{
    Task<string> GetToken();
}