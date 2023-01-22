using System.Text;
using TaskManager.Domain.Repositories;

namespace TaskManager.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    public void Authenticate(string credentials)
    {
        var username = Environment.GetEnvironmentVariable("USERNAME")?.ToLower();
        var password = Environment.GetEnvironmentVariable("PASSWORD");
        var (receivedUsername, receivedPassword) = ExtractCredentialsFromBasicToken(credentials);

        var isValidUsername = username == receivedUsername;
        var isValidPassword = password == receivedPassword;

        if (!isValidPassword || !isValidUsername)
        {
            throw new Exception("Invalid credentials");
        }
    }
    
    private static (string, string) ExtractCredentialsFromBasicToken(string token)
    {
        try
        {
            var encoding = Encoding.GetEncoding("UTF-8");
            var base64Credentials = token.Split(' ')[1];
            var credentialsBites = Convert.FromBase64String(base64Credentials);
            token = encoding.GetString(credentialsBites);
            var separator = token.IndexOf(':');
            var username = token[..separator];
            var password = token[(separator + 1)..];

            return (username.ToLower(), password);
        }
        catch (Exception e)
        {
            throw new Exception("Invalid credentials");
        }
    }
}