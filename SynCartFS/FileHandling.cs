using System.IO;
namespace SynCartFS
{
    public static class FileHandling
    {
        public static void Create()
        {
            //Create Directory
            if(!Directory.Exists("SynCartFS"))
            {
                Directory.CreateDirectory("SynCartFS");
            }

            //Create CustomerDetails.csv
            if(!File.Exists("SynCartFS/CustomerDetails.csv"))
            {
                File.Create("SynCartFS/CustomerDetails.csv").Close();
            }

            //Create Orders.csv
            if(!File.Exists("SynCartFS/Orders.csv"))
            {
                File.Create("SynCartFS/Orders.csv").Close();
            }

            //Create Products.csv
            if(!File.Exists("SynCartFS/Products.csv"))
            {
                File.Create("SynCartFS/Products.csv").Close();
            }
        }

        public static void ReadCSV()
        {
            //Read Customer Details
            string [] customersRead=File.ReadAllLines("SynCartFS/CustomerDetails.csv");
            for(int i=0;i<customersRead.Length;i++)
            {
                CustomerDetails customerDetail=new CustomerDetails(customersRead[i]);
                Operation.customers.Add(customerDetail);
            }

            //Read Product Details
            string [] productRead=File.ReadAllLines("SynCartFS/Products.csv");
            for(int i=0;i<productRead.Length;i++)
            {
                Product productDetail=new Product(productRead[i]);
                Operation.products.Add(productDetail);
            }

            //Read Order Details
            string [] orderRead=File.ReadAllLines("SynCartFS/Orders.csv");
            for(int i=0;i<orderRead.Length;i++)
            {
                Order orderDetail=new Order(orderRead[i]);
                Operation.orders.Add(orderDetail);
            }
        }

        public static void WriteCSV()
        {
            //Write Products
            string[] productsWrite=new string[Operation.products.Count];
            for(int i=0;i<Operation.products.Count;i++)
            {
                productsWrite[i]=Operation.products[i].ProductID+","+Operation.products[i].ProductName+","+Operation.products[i].Stock+","+Operation.products[i].Price+","+Operation.products[i].ShippingDuration;
            }
            //Writing to File
            File.WriteAllLines("SynCartFS/Products.csv",productsWrite);

            //Write CustomerDetails
            string[] customersWrite=new string[Operation.customers.Count];
            for(int i=0;i<Operation.customers.Count;i++)
            {
                customersWrite[i]=Operation.customers[i].CustomerID+","+Operation.customers[i].CustomerName+","+Operation.customers[i].City+","+Operation.customers[i].MobileNumber+","+Operation.customers[i].WalletBalance+","+Operation.customers[i].EmailID+",";
            }
            //Writing to File
            File.WriteAllLines("SynCartFS/CustomerDetails.csv",customersWrite);

            //Write Orders
            string[] ordersWrite=new string [Operation.orders.Count];
            for(int i=0;i<Operation.orders.Count;i++)
            {
                ordersWrite[i]=Operation.orders[i].OrderID+","+Operation.orders[i].CustomerID+","+Operation.orders[i].ProductID+","+Operation.orders[i].TotalPrice+","+Operation.orders[i].PurchaseDate.ToString("dd/MM/yyyy")+","+Operation.orders[i].Quantity+","+Operation.orders[i].OrderStatus;
            }
            //Writing to File
            File.WriteAllLines("SynCartFS/Orders.csv",ordersWrite); 
        }
    }
}