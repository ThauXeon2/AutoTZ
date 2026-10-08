using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoTZ
{
    record Auto(string Brand, string Type, int Hp, string Owner)
    {
        private int _price;
        public double Rating;
        private double _averageConsumption;
        private string _owner { get; init; } = Owner;
        public int Price { get { return _price; }set { _price = value; } }
        public double AverageConsumption { get { return _averageConsumption; } set { _averageConsumption = value; }}
        public string Owner { get { return _owner; }}
        public bool IsStrong() => Hp >= 200;
        public bool IsGRating() => Rating >= 8.5;
        public bool IsMoreEx(int price) => Price <= price;
        public void Cheaper(double at)
        {
            if (at <= 30 && at >= 1)
            {
                Price = (int)(Price-(Price*(at/100)));
                Console.WriteLine(Price);
            }
                
        }
        public double Liters(double distance) =>Math.Round((distance / 100) * AverageConsumption,2);
        public double PriceDistance(int fuelCost, double distance)=>Liters(distance)*fuelCost;
        public void NewRating(double rating)
        {
            if (rating >= 1 && rating <= 10)
                Rating = rating;
        }
        public override string ToString() => $"Az autót a {Brand} cég gyártotta, ez a {Type} típusú, {Owner} a gazdája és {Price} forintba került";



    }
}
