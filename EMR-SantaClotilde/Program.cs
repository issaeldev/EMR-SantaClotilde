using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using EMR_SantaClotilde.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                var mainForm = serviceProvider.GetRequiredService<Inicio>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrar el contexto de BD
            services.AddDbContext<EmrSantaClotildeContext>(options =>
                options.UseSqlServer("Server=DESKTOP-F9RKFQ1; Database=EMR_SantaClotilde; Trusted_Connection=True; Encrypt=False;"));

            // Registrar repositorios
            services.AddScoped<ICitaRepository, CitaRepository>();

            // Registrar servicios
            services.AddScoped<ICitaService, CitaService>();

            // Registrar formularios
            services.AddTransient<Inicio>();
            // Agrega aquí más formularios que requieran inyección
        }
    }
}