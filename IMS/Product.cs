using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IMS
{
    [DataContract]
    public class Product
    {
        private int Id;
        private string Name;
        private string Description;
        private int Quantity;
        private int Price;

        [DataMember]
        public int ProductId
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public string ProductName
        {
            get { return Name; }
            set { Name = value; }
        }
        [DataMember]
        public string ProductDescription
        {
            get { return Description; }
            set { Description = value; }
        }
        [DataMember]
        public int ProductQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        [DataMember]
        public int ProductPrice
        {
            get { return Price; }
            set { Price = value; }
        }

    }
}
