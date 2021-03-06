using System.ComponentModel.DataAnnotations;

namespace dog_breed_world.Models
{
  public class UserLogin
  {
    [Key]
    public int? Id { get; set; }
    [Required]
    public string? Username { get; set; }
    public string? Password { get; set; }
  }
}
