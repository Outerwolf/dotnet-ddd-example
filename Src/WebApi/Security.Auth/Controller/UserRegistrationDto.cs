namespace WebApi.Security.Auth.Controller;

public record UserRegistrationDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Identification { get; set; }
    
}