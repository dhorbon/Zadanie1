using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Product
    {
        //nawza producenta, możliwa do wyświetlenia, ustawiana w konstruktorze

        private string producerName;

        public string ProducerName
        {
            get { return producerName; }
        }


        //nawza produktu, możliwa do wyświetlenia i edycji

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }


        //kategoria, możliwa do wyświetlenia, ustawiana w konstruktorze
        string category;

        public string Category
        {
            get { return category; }
        }


        //identyfikator, możliwy do wyświetlenia, ustawiany w konstruktorze
        string id;
        
        public string Id
        {
            get { return id; }
        }


        //cena, zapisywana w groszach, obsługiwana przy pomocy zmiennej publicznej Price (z dużej litery)
        private int price;

        //pseudozmienna Price obsługuje zamiane z groszy w incie na cene w stringu
        public string Price
        {
            get
            { 
                return Convert.ToString(price/100);
            }
            //ta medoda jest w stanie wyżucić błąd, należy zabezpieczać input poza nią
            set
            {
                for(int i =0; i < value.Length; i++)
                {
                    if (value[i] == ',' || value[i] == '.')
                    {
                        if(i-value.Length == 2)
                        {
                            price = Convert.ToInt32(value[i]*10);
                        }else if(i - value.Length == 3)
                        {
                            price = Convert.ToInt32(value[i] * 100);
                        }
                        break;
                    }
                }
            }
        }

        //opis, możliwy do wyświetlenia i edycji
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        //ilość produktu na magazynie wyswietlana i zmieniana dowolnie
        public int amount;


        //konstruktor
        public Product(string productName, string producerName, string category, string desc, string id, string price)
        {
            this.productName = productName;
            this.producerName = producerName;
            this.category = category;
            this.desc = desc;
            this.id = id;
            this.Price = price;
            this.amount = 0;
        }
    }
}
