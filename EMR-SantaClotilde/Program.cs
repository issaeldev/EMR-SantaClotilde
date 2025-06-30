using EMR_SantaClotilde.Forms;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using EMR_SantaClotilde.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace EMR_SantaClotilde
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);


            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<Login>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrar el contexto de BD
            services.AddDbContextFactory<EmrSantaClotildeContext>(options =>
            options.UseSqlServer("Server=DESKTOP-F9RKFQ1; Database=EMR_SantaClotilde; Trusted_Connection=True; Encrypt=False;"));
            // Registrar repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IResultadoRepository, ResultadoRepository>();

            // Registrar servicios
            services.AddScoped<ICitaService, CitaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IResultadoService, ResultadoService>();




            // Registrar formularios
            services.AddTransient<Login>();
            services.AddTransient<Inicio>();
            services.AddTransient<Usuarios>();
            services.AddTransient<Pacientes>();
            services.AddTransient<Citas>();
            services.AddTransient<Resultados>();
            
            // Agrega aquí más formularios que requieran inyección
        }
    }
}