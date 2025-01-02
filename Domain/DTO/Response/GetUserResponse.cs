namespace Domain.DTO.Response
{
    public class GetUserResponse
    {
        public string? Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool AccountConfirmed { get; set; }
    }
}
