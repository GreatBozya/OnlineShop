using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IOrderService
    {
        void AddOrder(Order order);
        void CancelOrder(Order order);
        void GetOrders();
    }
    class OrderServise : IOrderService
    {
        List<Order> orders = new List<Order>();
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public void CancelOrder(Order order)
        {
            orders.Remove(order);
        }
        public void GetOrders()
        {
            foreach (Order order in orders)
            {
                int tp = order.CalculateTotalPrice();
                Console.WriteLine($"{order.customer.Cname}\n\tТовар:\n\t   * {order.product.Pname} x {order.Oquantity}\n\tИтоговая стоимость: {tp}\n");
            }
        }
    }
    class Product
    {
        public string Pname;
        public int price;
        public int quantity;
        public Product(string Pname, int price, int quantity)
        {
            this.Pname = Pname;
            this.price = price;
            this.quantity = quantity;
        }
    }
    class Customer
    {
        public string Cname;
        public string email;
        public Customer(string Cname, string email)
        {
            this.Cname = Cname;
            this.email = email;
        }
    }
    class Order
    {
        public Product product;
        public Customer customer;
        public int Oquantity;
        public Order(Product product, Customer customer, int Oquantity)
        {
            this.product = product;
            this.customer = customer;
            this.Oquantity = Oquantity;
        }
        public int CalculateTotalPrice()
        {
            if (Oquantity <= product.quantity)
            {
                return Oquantity * product.price;
            }
            else
            {
                return 0;
            }
        }
    }
    struct Address
    {
        string street;
        string city;
        int zipCode;

        public void Print()
        {
            Console.WriteLine($"ул. {street}, г. {city}, {zipCode}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderServise orderServise = new OrderServise();
            Product guitar = new Product("Шедевро-гитара", 100, 42);
            Product lWing = new Product("Левое крыло самолёта Airbus A319", 999999, 2);
            Customer tosha = new Customer("Анатолий Лизогуб", "stopPostingAbout@among.us");
            Customer vitya = new Customer("Виталя Подливкин", "GNAAmaster@yandex.ru");
            Order orderTosha = new Order(guitar, tosha, 5);
            Order orderVitya = new Order(lWing, vitya, 1);
            orderServise.AddOrder(orderTosha);
            orderServise.AddOrder(orderVitya);
            orderServise.GetOrders();

            Console.ReadKey();
        }
    }
}
