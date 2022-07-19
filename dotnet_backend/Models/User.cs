using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dog_breed_world.Models
{
  public class User
  {
    [Key]
    public int? Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [NotMapped]
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? EmailAddress { get; set; }
    [Required]
    public string? GivenName { get; set; }
    [Required]
    public string? Surname { get; set; }
    public string? Role { get; set; }
    public string? Salt { get; set; }
    public string? Hash { get; set; }
    
    public DateTime? createdAt { get; set; } = DateTime.Now;
    public DateTime? updatedAt { get; set; } = DateTime.Now;
  }
}
