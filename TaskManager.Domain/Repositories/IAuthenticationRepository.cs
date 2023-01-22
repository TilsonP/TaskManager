using System.Net.Security;

namespace TaskManager.Domain.Repositories;

public interface IAuthenticationRepository
{
    void Authenticate(string credentials);
}