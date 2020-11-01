using System;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Domain.Models
{
    public class Airplane
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Capacity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}