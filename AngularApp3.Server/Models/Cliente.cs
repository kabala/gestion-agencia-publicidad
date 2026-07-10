using System.ComponentModel.DataAnnotations;
namespace AngularApp3.Server.Models;
public class Cliente
{
    public int ClienteId { get; set; }
    [Required, StringLength(100), Display(Name = "Empresa")]
    public string NombreEmpresa { get; set; } = string.Empty;
    [Required, StringLength(100)] public string Contacto { get; set; } = string.Empty;
    [Required, Phone, StringLength(20)] public string Telefono { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(100)] public string Email { get; set; } = string.Empty;
    public ICollection<Campana> Campanas { get; set; } = new List<Campana>();
}
