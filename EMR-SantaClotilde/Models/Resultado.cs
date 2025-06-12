using System;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public int PacienteId { get; set; }

    public int? CitaId { get; set; }

    public int MedicoSolicitante { get; set; }

    public string TipoExamen { get; set; } = null!;

    public string NombreExamen { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaResultado { get; set; }

    public string? Resultado1 { get; set; }

    public string? UnidadMedida { get; set; }

    public string? ArchivoAdjunto { get; set; }

    public bool Sincronizado { get; set; }

    public virtual Cita? Cita { get; set; }

    public virtual Usuario MedicoSolicitanteNavigation { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
