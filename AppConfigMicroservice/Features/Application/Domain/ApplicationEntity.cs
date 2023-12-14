using AppConfigMicroservice.Common.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppConfigMicroservice.Features.Application.Domain;

public class ApplicationEntity : IEntity
{
    [Column("id")]
    [Key]
    public long Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("port")]
    public string? Port { get; set; }
}
