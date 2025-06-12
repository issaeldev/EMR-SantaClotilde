using System;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string? Especialidad { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
