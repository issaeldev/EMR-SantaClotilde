using System;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Dni { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Alergias { get; set; }

    public string? Antecedentes { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
