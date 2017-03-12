using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedrosFruitStand.Models
{
    public class PFS : Controller
    {
        
        public List<ForGrid> TotalsByDateRange(List<FruitStandStuff> fList, string a, string b)
        {
            List<FruitStandStuff> query = new List<FruitStandStuff>();

            foreach (var c in fList)
            {
                query.Add(new FruitStandStuff
                {
                    FruitName = c.FruitName,
                    Qty = c.Qty,
                    Price = c.Price,
                    DateSold = c.DateSold
                });
            }

            

            var applesCost = query.Where(w => w.FruitName == "Apples" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(z => z.Price);
            var appleSold = query.Where(w => w.FruitName == "Apples" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(sum => sum.Qty);

            var bananasCost = query.Where(w => w.FruitName == "Bananas" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(z => z.Price);
            var bananasSold = query.Where(w => w.FruitName == "Bananas" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(sum => sum.Qty);

            var orangesCost = query.Where(w => w.FruitName == "Oranges" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(z => z.Price);
            var orangesSold = query.Where(w => w.FruitName == "Oranges" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(sum => sum.Qty);

            var pearsCost = query.Where(w => w.FruitName == "Pears" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(z => z.Price);
            var pearsSold = query.Where(w => w.FruitName == "Pears" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(sum => sum.Qty);

            var watermelonsCost = query.Where(w => w.FruitName == "Watermelons" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(z => z.Price);
            var watermelonsSold = query.Where(w => w.FruitName == "Watermelons" && w.DateSold >= Convert.ToDateTime(b) && w.DateSold <= Convert.ToDateTime(a)).Sum(sum => sum.Qty);
            

            List<ForGrid> lst = new List<ForGrid>();

            lst.Add(new ForGrid { FruitName = "Apples", TotalPrice = applesCost, TotalSold = appleSold });
            lst.Add(new ForGrid { FruitName = "Bananas", TotalPrice = bananasCost, TotalSold = bananasSold });
            lst.Add(new ForGrid { FruitName = "Pears", TotalPrice = pearsCost, TotalSold = pearsSold });
            lst.Add(new ForGrid { FruitName = "Oranges", TotalPrice = orangesCost, TotalSold = orangesSold });
            lst.Add(new ForGrid { FruitName = "Watermelons", TotalPrice = watermelonsCost, TotalSold = watermelonsSold });

            return lst;
        }
    }
    public class ForGrid
    {
        public string FruitName { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalSold { get; set; }
    }
    public class Stuff
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
    }

    public class FruitStandStuff
    {
        public string FruitName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime DateSold { get; set; }
    }
}