using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializaingCustomClasses
{
    class Program
    {
        [Serializable]
        class ShoppingCartItem : IDeserializationCallback
        {
            public int productId;
            public double price;
            public int quantity;
            [NonSerialized] public double total;

            public ShoppingCartItem(int _prodID, double _prc, int _quant)
            {
                this.productId = _prodID;
                this.price = _prc;
                this.quantity = _quant;
                this.total = price * quantity;
            }

            public void setProductId(int prodID)
            {
                this.productId = prodID;
            }

            public int getProductID()
            {
                return this.productId;
            }

            public void setPrice(double prc)
            {
                this.price = prc;
            }

            public double getPrice()
            {
                return this.productId;
            }

            public void setQuantity(int quan)
            {
                this.quantity = quan;
            }

            public int getQuantity()
            {
                return this.quantity;
            }

            void IDeserializationCallback.OnDeserialization(Object sender)
            {
                this.total = price * quantity;
            }

            public double getTotal()
            {
                return this.total;
            }


        }

        static void Main(string[] args)
        {
            //ShoppingCartItem item = new ShoppingCartItem(12345, 11.99, 25);
            //FileStream fs = new FileStream("ShoppingCartItem.data", FileMode.Create);
            FileStream fs = new FileStream("ShoppingCartItem.data", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(fs, item);

            ShoppingCartItem _items;
            _items = (ShoppingCartItem)bf.Deserialize(fs);

            fs.Close();

            Console.WriteLine("Product ID: " + _items.getPrice());
            Console.WriteLine("Price: " + _items.getPrice());
            Console.WriteLine("Quantity: " + _items.getQuantity());
            Console.WriteLine("Total: $" + _items.getTotal());
          
        }
    }
}
