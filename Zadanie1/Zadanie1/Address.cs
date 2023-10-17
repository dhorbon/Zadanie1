using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class Address
    {
        //ulica, możliwa do wyświetlenia, ustawiana w konstruktorze
        private string street;

        public string Street
        {
            get { return street; }
        }

        //miasto, możliwe do wyświetlenia, ustawiane w konstruktorze
        private string city;

        public string City
        {
            get { return city; }
        }

        //numer budynku, możliwy do wyświetlenia, ustawiany w konstruktorze
        private string buildingNumber;

        public string BuildingNumber
        {
            get { return buildingNumber; }
        }

        //numer lokalu, możliwy do wyświetlenia, ustawiany w konstruktorze
        private string apartamentNumber;

        public string ApartamentNumber
        {
            get { return apartamentNumber; }
        }

        //kostruktor
        public Address(string street, string city, string buildingNumber, string apartamentNumber)
        { 
            this.street = street;
            this.city = city;
            this.buildingNumber = buildingNumber;
            this.apartamentNumber = apartamentNumber;
        }
    }
}
