using AppConfigMicroservice.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppConfigMicroservice.Features.Config.Models
{
    public class ConfigEntity : IEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("application_id")]
        public int? ApplicationId { get; set; }

        [Column("env_type")]
        public int? EnvType { get; set; }

        [Column("config_type")]
        public int? ConfigType { get; set; }

        [Column("config")]
        public string? Config { get; set; }
    }
}
