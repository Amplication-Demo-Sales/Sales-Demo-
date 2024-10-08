namespace CarRentalManagementMobile.APIs.Dtos;

public class UserWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }
}
