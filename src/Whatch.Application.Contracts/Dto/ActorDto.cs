using System;
using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class ActorDto : EntityDto<int>
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Country { get; set; }
    public DateTime Birthday { get; set; }
}