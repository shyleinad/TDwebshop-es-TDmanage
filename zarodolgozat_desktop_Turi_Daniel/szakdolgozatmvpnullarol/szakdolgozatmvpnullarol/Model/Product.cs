using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szakdolgozatmvpnullarol.Model
{
    public class Product
    {
        private string make; private string type; private string pic; private double price; private bool lefthanded = false;
        private string category; private string details; private int quanity; private string color;
        public string getMake { get => make; }
        public string getType { get => type; }
        public double getPrice { get => price; }
        public bool getLH { get => lefthanded; }
        public string getCat { get => category; }
        public string getDetails { get => details; }
        public int getQuanity { get => quanity; }
        public string getPic { get => pic; }
        public string getColor { get => color; }

        public Product(string make, string type, string pic, double price, bool lefthanded, string category, string details, int quanity, string color)
        {
            this.make = make; this.type = type; this.pic = pic; this.price = price; this.lefthanded = lefthanded; this.category = category; this.details = details; this.quanity = quanity; this.color = color;
        }
    }
}
