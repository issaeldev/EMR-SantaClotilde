using System;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Models;

public partial class Cita
{
    public int Id { get; set; }

    public int PacienteId { get; set; }

    public int MedicoId { get; set; }

    public DateTime FechaHora { get; set; }

    public string Estado { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Motivo { get; set; }

    public string? Observaciones { get; set; }

    public bool Sincronizado { get; set; }

    public string? AdicionalMotivo { get; set; }

    public virtual Usuario Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
