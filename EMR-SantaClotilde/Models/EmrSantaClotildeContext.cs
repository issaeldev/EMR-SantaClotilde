using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMR_SantaClotilde.Models;

public partial class EmrSantaClotildeContext : DbContext
{
    public EmrSantaClotildeContext()
    {
    }

    public EmrSantaClotildeContext(DbContextOptions<EmrSantaClotildeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=EMR_SantaClotilde;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__citas__3213E83FD94D133E");

            entity.ToTable("citas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.AdicionalMotivo).HasColumnName("adicional_motivo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("programada")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaHora).HasColumnName("fecha_hora");
            entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .HasColumnName("motivo");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Sincronizado).HasColumnName("sincronizado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK_citas_usuarios");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK_citas_pacientes");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__paciente__3213E83F0CF1EC32");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.Dni, "UQ__paciente__D87608A7A49BB098").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Alergias).HasColumnName("alergias");
            entity.Property(e => e.Antecedentes).HasColumnName("antecedentes");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__resultad__3213E83F4DB6108B");

            entity.ToTable("resultados");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ArchivoAdjunto)
                .HasMaxLength(255)
                .HasColumnName("archivo_adjunto");
            entity.Property(e => e.CitaId).HasColumnName("cita_id");
            entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaResultado).HasColumnName("fecha_resultado");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.MedicoSolicitante).HasColumnName("medico_solicitante");
            entity.Property(e => e.NombreExamen)
                .HasMaxLength(100)
                .HasColumnName("nombre_examen");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Resultado1).HasColumnName("resultado");
            entity.Property(e => e.Sincronizado).HasColumnName("sincronizado");
            entity.Property(e => e.TipoExamen)
                .HasMaxLength(50)
                .HasColumnName("tipo_examen");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");

            entity.HasOne(d => d.Cita).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK_resultados_citas");

            entity.HasOne(d => d.MedicoSolicitanteNavigation).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.MedicoSolicitante)
                .HasConstraintName("FK_resultados_usuarios");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK_resultados_pacientes");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F85BC562C");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Username, "UQ__usuarios__F3DBC572BA51BEB7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .HasColumnName("especialidad");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
