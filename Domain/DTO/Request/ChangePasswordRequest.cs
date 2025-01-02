using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Request
{
    public class ChangePasswordRequest
    {
        [Required] public string CurrentPassword { get; set; } = null!;
        [Required] public string NewPassword { get; set; } = null!;
        [Required] public string ConfirmNewPassword { get; set; } = null!;
    }
}
