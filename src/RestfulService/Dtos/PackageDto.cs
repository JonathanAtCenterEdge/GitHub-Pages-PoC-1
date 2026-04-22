using System.ComponentModel.DataAnnotations;

namespace RestfulService.Dtos;

public class PackageDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public List<ItemDto> Items { get; set; } = [];
}
