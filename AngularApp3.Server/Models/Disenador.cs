using System.ComponentModel.DataAnnotations;
namespace AngularApp3.Server.Models;
public class Disenador
{
    public int DisenadorId { get; set; }
    [Required, StringLength(100)] public string Nombre { get; set; } = string.Empty;
    [Required, StringLength(80)] public string Especialidad { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(100)] public string Email { get; set; } = string.Empty;
    [Required, Phone, StringLength(20)] public string Telefono { get; set; } = string.Empty;
    public ICollection<Entregable> Entregables { get; set; } = new List<Entregable>();
}
