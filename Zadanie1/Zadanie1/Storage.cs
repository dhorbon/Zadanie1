using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Storage
    {
        //adres magazynu zapisany w formie obiektu adresowego, mozliwy do wyświetlenia, ustawiany w konstruktorze
        private Address address;

        public Address Address
        {
            get { return address; }
        }

        //wewnętrzna lista produktów
        public List<Product> Products;

        //konstruktor
        public Storage(Address address)
        { 
            this.address = address;
            Products = new List<Product>();
        }
    }
}
