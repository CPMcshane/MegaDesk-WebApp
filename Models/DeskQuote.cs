using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MegaDesk_WebApp.Models
{
    public class DeskQuote
    {
        public int id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public float Width { get; set; }

        public float Depth { get; set; }

        public int Drawers { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Surface Material")]
        public SurfaceMaterial Material { get; set; }

        [Display(Name = "Production Time")]
        public int ProductionTime { get; set; }
    }
}

public enum SurfaceMaterial
{
    Oak,
    Laminate,
    Pine,
    Rosewood,
    Veneer
}
