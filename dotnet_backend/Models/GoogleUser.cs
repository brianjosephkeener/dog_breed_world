using System.ComponentModel.DataAnnotations;

namespace dog_breed_world.Models
{
  public class GoogleUser
  {
    [Key]
    public int? Id { get; set; }
    [Required]
    // JWT issuer
    public string? iss { get; set; }

    public int? nbf { get; set; }
    // Server client ID
    public string? aud { get; set; }
    // Unique ID of the user's Google Account
    public string? sub { get; set; }
    // If present, the host domain of the user's GSuite email address
    public string? hd { get; set; }
    // The user's email address
    public string? email { get; set; }
    // true, if Google has verified the email address
    public bool? email_verified { get; set; }
    public string? azp { get; set; }
    public string? name { get; set; }
    // If present, a URL to user's profile picture
    public string? picture { get; set; }
    public string? given_name { get; set; }
    public string? family_name { get; set; }
    // Unix timestamp of the assertion's creation time
    public DateTime?  iat { get; set; }
    // Unix timestamp of the assertion's expiration time
    public DateTime? exp { get; set; }
    public string? jti { get; set; }
    public DateTime? createdAt { get; set; } = DateTime.Now;
    public DateTime? updatedAt { get; set; } = DateTime.Now;
  }
}
