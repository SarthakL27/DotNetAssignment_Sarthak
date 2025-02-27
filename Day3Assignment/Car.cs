using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Assignment
{
    class Car
    {

        private int cardid;
        private String brand;
        private String model;
        private String year;
        private int price;
        public int CarId { get {return cardid; } set { cardid = value; } }
        public string Brand { get { return brand; } set { brand = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string Year { get { return year; } set { year = value; } }

        public int Price { get { return price; } set { price=value; } }

        public Car()
        {
            CarId = 111;
            Brand = "maruti";
            Model = "swift";
            Year = "2007";
            Price = 950000;
            
        }
        public  void setCarDetails(int carid,String brand,String model,String year,int price)
        {
            this.cardid = carid;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
            Console.WriteLine("receiving car details");
        }

        public void getDetails()
        {
            Console.WriteLine("displaying values");

            Console.WriteLine("cardid:"+cardid+"\t"+"brand:"+brand+ "\t"+"model:"+model+"\t"+"year:"+year+"\t"+"price:"+price);
        }
        public  Car(int carId,String brand,String model,String year , int price )
        {
            CarId = cardid;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
