using System.ComponentModel.DataAnnotations;

namespace TryItApi.Models;

public class Item
{
    public int Id { get; set; } // assigned by server, no [Required]
     [Required]
    public string Name { get; set; } = string.Empty;
     [Required]
    public decimal Price { get; set; }
}
