using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MegaDesk_WebApp.Models
{
    public class DeskQuote
    {
        public int id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Range(24,96)]
        public float Width { get; set; }

        [Range(12,48)]
        public float Depth { get; set; }

        [Range(0,7)]
        public int Drawers { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Surface Material")]
        public SurfaceMaterial Material { get; set; }

        [Display(Name = "Production Time")]
        public int ProductionTime { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get { return CalculatePrice(); } }

        public float CalculatePrice()
        {
            float area = Width * Depth;
            int baseCost = 200;
            float areaCost = (area > 1000) ? area - 1000 : 0;
            int drawerCost = Drawers * 50;

            int materialCost;
            switch (Material)
            {
                case SurfaceMaterial.Oak:
                    materialCost = 200;
                    break;
                case SurfaceMaterial.Laminate:
                    materialCost = 100;
                    break;
                case SurfaceMaterial.Pine:
                    materialCost = 50;
                    break;
                case SurfaceMaterial.Rosewood:
                    materialCost = 300;
                    break;
                case SurfaceMaterial.Veneer:
                    materialCost = 125;
                    break;
                default:
                    materialCost = 0;
                    break;
            }

            // Determines the production cost based on production
            // time and size of the desk
            int rushOrderCost = 0;
            if (this.ProductionTime != 14)
            {
                int sizeOfDeskIndex;
                if (area < 1000) sizeOfDeskIndex = 0;
                else if (area > 2000) sizeOfDeskIndex = 2;
                else sizeOfDeskIndex = 1;

                rushOrderCost = rushOrderCostTable[ProductionTime, sizeOfDeskIndex];
            }

            float totalCost = baseCost
                            + areaCost
                            + drawerCost
                            + materialCost
                            + rushOrderCost;

            return totalCost;
        }

        #region Fields

        // Array to hold the rush order price based on
        // table size and production time.
        int[,] rushOrderCostTable = new int[3, 3]
        {
            { 60, 70, 80 },
            { 40, 50, 60 },
            { 30, 35, 40 }
        };

        #endregion

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
