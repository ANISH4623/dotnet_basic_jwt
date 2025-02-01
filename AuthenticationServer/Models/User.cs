
public class User
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
   
    public enum Roles
    {
        Admin,
        User
    }
    public Roles UserRole { get; set; }
}