namespace JwtWAspNetCore.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Socio")]
    public class Socio
    {
        [Key]
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
