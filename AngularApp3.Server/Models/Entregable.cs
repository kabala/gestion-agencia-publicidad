using System.ComponentModel.DataAnnotations;
namespace AngularApp3.Server.Models;
public class Entregable
{
    public int EntregableId { get; set; }
    [Display(Name = "Campaña")] public int CampanaId { get; set; }
    [Display(Name = "Diseñador")] public int DisenadorId { get; set; }
    [Required, StringLength(80)] public string Tipo { get; set; } = string.Empty;
    [DataType(DataType.Date), Display(Name = "Fecha de entrega")] public DateTime FechaEntrega { get; set; }
    public Campana? Campana { get; set; }
    public Disenador? Disenador { get; set; }
}
