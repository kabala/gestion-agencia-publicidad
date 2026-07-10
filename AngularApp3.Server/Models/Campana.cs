using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AngularApp3.Server.Models;
public class Campana
{
    public int CampanaId { get; set; }
    [Display(Name = "Cliente")] public int ClienteId { get; set; }
    [Required, StringLength(100)] public string Nombre { get; set; } = string.Empty;
    [Range(0.01, 999999999), Column(TypeName = "decimal(12,2)")] public decimal Presupuesto { get; set; }
    [DataType(DataType.Date), Display(Name = "Fecha de inicio")] public DateTime FechaInicio { get; set; }
    public Cliente? Cliente { get; set; }
    public ICollection<Entregable> Entregables { get; set; } = new List<Entregable>();
}
