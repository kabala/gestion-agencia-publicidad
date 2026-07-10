using AngularApp3.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace AngularApp3.Server.Data;
public class AgenciaContext(DbContextOptions<AgenciaContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Campana> Campanas => Set<Campana>();
    public DbSet<Disenador> Disenadores => Set<Disenador>();
    public DbSet<Entregable> Entregables => Set<Entregable>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente { ClienteId=1, NombreEmpresa="Café Central", Contacto="Ana Torres", Telefono="0991234567", Email="ana@cafecentral.com" },
            new Cliente { ClienteId=2, NombreEmpresa="Deportes Andinos", Contacto="Luis Mora", Telefono="0987654321", Email="luis@deportesandinos.com" },
            new Cliente { ClienteId=3, NombreEmpresa="Clínica Vida", Contacto="María López", Telefono="0974455667", Email="maria@clinicavida.com" },
            new Cliente { ClienteId=4, NombreEmpresa="EcoHogar", Contacto="Carlos Ruiz", Telefono="0961122334", Email="carlos@ecohogar.com" });
        modelBuilder.Entity<Campana>().HasData(
            new Campana { CampanaId=1, ClienteId=1, Nombre="Sabor de temporada", Presupuesto=8500, FechaInicio=new DateTime(2026,1,15) },
            new Campana { CampanaId=2, ClienteId=2, Nombre="Corre Ecuador", Presupuesto=15000, FechaInicio=new DateTime(2026,2,10) },
            new Campana { CampanaId=3, ClienteId=3, Nombre="Chequeo a tiempo", Presupuesto=12000, FechaInicio=new DateTime(2026,3,5) },
            new Campana { CampanaId=4, ClienteId=4, Nombre="Hogar sostenible", Presupuesto=9750, FechaInicio=new DateTime(2026,4,20) });
        modelBuilder.Entity<Disenador>().HasData(
            new Disenador { DisenadorId=1, Nombre="Sofía Vega", Especialidad="Diseño gráfico", Email="sofia@agencia.com", Telefono="0995551100" },
            new Disenador { DisenadorId=2, Nombre="Mateo Paz", Especialidad="Diseño web", Email="mateo@agencia.com", Telefono="0985552200" },
            new Disenador { DisenadorId=3, Nombre="Valentina Cruz", Especialidad="Ilustración", Email="valentina@agencia.com", Telefono="0975553300" },
            new Disenador { DisenadorId=4, Nombre="Diego León", Especialidad="Contenido audiovisual", Email="diego@agencia.com", Telefono="0965554400" });
        modelBuilder.Entity<Entregable>().HasData(
            new Entregable { EntregableId=1, CampanaId=1, DisenadorId=1, Tipo="Identidad visual", FechaEntrega=new DateTime(2026,2,5) },
            new Entregable { EntregableId=2, CampanaId=1, DisenadorId=3, Tipo="Publicaciones para redes", FechaEntrega=new DateTime(2026,2,20) },
            new Entregable { EntregableId=3, CampanaId=2, DisenadorId=4, Tipo="Video promocional", FechaEntrega=new DateTime(2026,3,15) },
            new Entregable { EntregableId=4, CampanaId=3, DisenadorId=2, Tipo="Página de campaña", FechaEntrega=new DateTime(2026,4,12) },
            new Entregable { EntregableId=5, CampanaId=4, DisenadorId=1, Tipo="Catálogo digital", FechaEntrega=new DateTime(2026,5,25) },
            new Entregable { EntregableId=6, CampanaId=2, DisenadorId=3, Tipo="Afiches", FechaEntrega=new DateTime(2026,3,8) });
    }
}
