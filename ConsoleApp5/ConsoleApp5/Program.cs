using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IOrderService
    {
        void AddOrder(Order order);
        void CancelOrder(Order order);
        List<Order> GetOrders();
    }
    class OrderServise : IOrderService
    {
        public void AddOrder(Order order)
        {

        }
        public void CancelOrder(Order order)
        {

        }
        List<Order> orders = new List<Order>();
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
        Product product;
        Customer customer;
        public int Oquantity;
        public Order(Product product, Customer customer, int Oquantity)
        {
            this.product = product;
            this.customer = customer;
            this.Oquantity = Oquantity;
        }
        public void CalculateTotalPrice()
        {
            if (Oquantity <= product.quantity)
            {
                Console.WriteLine($"Итоговая цена: {Oquantity * product.price}");
            }
            else
            {
                Console.WriteLine("Заказ отменён");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product guitar = new Product("Шедевро-гитара", 100, 42);
            Product lWing = new Product("Левое крыло самолёта Airbus A319", 999999, 2);
            Customer tosha = new Customer("Анатолий Лизогуб", "stopPostingAbout@among.us");
            Customer vitya = new Customer("Виталя Подливкин", "GNAAmaster@yandex.ru");
            Order orderTosha = new Order(guitar, tosha, 2);
            orderTosha.CalculateTotalPrice();

            Console.ReadKey();
        }
    }
}
