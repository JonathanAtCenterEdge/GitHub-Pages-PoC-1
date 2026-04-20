using System.ComponentModel.DataAnnotations;

namespace RestfulService.Dtos;

public class ItemDto
{
    [Required]
    public long Id { get; set; }

    [Required]
    [MinLength(6)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
