using System.ComponentModel.DataAnnotations;

namespace TryItApi.Models;

public class Item
{
    [Required]
    public int Id { get; set; }
     [Required]
    public string Name { get; set; } = string.Empty;
     [Required]
    public decimal Price { get; set; }
}
