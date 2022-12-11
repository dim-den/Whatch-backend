using System;
using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class CreateUpdateActorDto
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Lastname { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Country { get; set; }
    
    [Required]
    public DateTime Birthday { get; set; }
}