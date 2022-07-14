using System.ComponentModel.DataAnnotations;

namespace dog_breed_world.Models
{
  public class User
  {
    [Key]
    public int? Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? EmailAddress { get; set; }
    public string? GivenName { get; set; }
    public string Surname { get; set; }
    public string Role { get; set; }
    
    public DateTime? createdAt { get; set; } = DateTime.Now;
    public DateTime? updatedAt { get; set; } = DateTime.Now;
  }
}
