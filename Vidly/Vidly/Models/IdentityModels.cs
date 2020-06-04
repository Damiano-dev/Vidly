using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    // È possibile aggiungere dati del profilo per l'utente aggiungendo altre proprietà alla classe ApplicationUser. Per altre informazioni, vedere https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string NumeroPatente { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroDiTelefono { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Film> films { get; set; }
        public DbSet<Cliente> clienti { get; set; }
        public DbSet<TipoAbbonamento> abbonamenti { get; set; }
        public DbSet<Genere> generi { get; set; }
        public DbSet<Rental> rental { get; set; }
        public DbSet<ImmagineFilm> immagineFilms { get; set; }
        public DbSet<MappingImmaginiFilms> MappingImmaginiFilms { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection",throwIfV1Schema:false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}