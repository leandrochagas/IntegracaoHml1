using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IntegracaoPsP.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            /*Configurações de algumas entidades*/
            // modelBuilder.Configurations.Add(new AtletaConfiguration());


            // Keep this:
            // modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");


            // Change TUser to ApplicationUser everywhere else - IdentityUser and ApplicationUser essentially 'share' the AspNetUsers Table in the database:
            //EntityTypeConfiguration<ApplicationUser> table =
            // modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            //table.Property((ApplicationUser u) => u.UserName).IsRequired();


        }

   


        public DbSet<Domain.Entities.Log.LogMessage> LogMensagens { get; set; }

        #region entidades de Paramatrizacao e XSD
        public DbSet<Domain.Entities.Others.Parametro> Parametros { get; set; }
        public DbSet<Domain.Entities.Others.ModeloXsd> ModelosXsd { get; set; }
        #endregion

        #region Entidades para tratamento de arquivos txts
        //public DbSet<Domain.Entities.Manifesto.HeaderManifesto> HeadersManifesto { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Boletim> Boletins { get; set; }
        //public DbSet<Domain.Entities.Manifesto.BoletimMaster> BoletinsMaster { get; set; }
        //public DbSet<Domain.Entities.Manifesto.BoletimDescricao> BoletinsDescricao { get; set; }
        //public DbSet<Domain.Entities.Manifesto.CargaSolta> CargasSoltas { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Conteiner> Conteineres { get; set; }
        //public DbSet<Domain.Entities.Manifesto.ConteinerCheio> ConteineresCheios { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Frete> Fretes { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Granel> Granels { get; set; }
        //public DbSet<Domain.Entities.Manifesto.MercadoriaConteinerizada> MercadoriasConteinerizadas { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Parceiro> Parceiros { get; set; }
        //public DbSet<Domain.Entities.Manifesto.Trailler> Traillers { get; set; }
        //public DbSet<Domain.Entities.Manifesto.PortodeEscala> PortosdeEscalas { get; set; }
        #endregion

        #region Entidades de Tratamento de Integracao
        public DbSet<Domain.Entities.Xml.Integration> Integracoes { get; set; }
        public DbSet<Domain.Entities.Xml.IntegrationHistoryErro> HistoricoErroIntegracoes { get; set; }
        public DbSet<Domain.Entities.Xml.IntegrationHistoric> Historico { get; set; }
        
        #endregion


        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        //if (entry.State == EntityState.Added)
        //        //{
        //        //    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        //}

        //        //if (entry.State == EntityState.Modified)
        //        //{
        //        //    entry.Property("DataCadastro").IsModified = false;
        //        //}
        //        //entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
        //        entry.Property("Usuario").CurrentValue == "" ? "" : entry.Property("Usuario").CurrentValue = HttpContext.Current.User.Identity.Name;

        //    }
        //    return base.SaveChanges();
        //}


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}