using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

abstract class Delivery
{
    protected string address;
    protected string Address { get; set; }
}
class ShopDelivery : Delivery
{
    internal new string address = "Орджоникидзе, 1";
    internal new string Address
    {
        get
        {
            return address;
        }
    }
}
class HomeDelivery : Delivery
{
    Courier courier;
    internal HomeDelivery(string AddressParam)
    {
        courier = new Courier();
        Address = AddressParam;
        courier.DeliverTheOrder(address);
    }
    internal new string Address
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
}
class Courier
{
    internal void DeliverTheOrder(string addressParam)
    {
        Console.WriteLine("Курьер доставит ваш заказ по адресу {0}", addressParam);
    }
}
class Order<T, K> where T : Delivery where K : MyProducts
{
    internal T TypeOfDelivery
    {
        get
        { return TypeOfDelivery; }
        set
        { }
    }
    internal K TypesOfMyProducts
    {
        get { return TypesOfMyProducts/*.ShowBasket*/; }
        set { }
    }
    internal Order(T TypeOfDelivery, K TypesOfMyProducts)
    {
        this.TypeOfDelivery = TypeOfDelivery;
        this.TypesOfMyProducts = TypesOfMyProducts;
    }
}
class MyProducts
{
    readonly string TV = "Телевизор";
    readonly string PC = "ПК";
    readonly string Phone = "Телефон";
    private List<string> basket;
    internal MyProducts()
    {
        basket = new List<string>();
    }
    internal void AddProducts()
    {
        ShowProducts();
        Console.WriteLine("Напишите желаемый товар в виде Телефон / ПК / Телевизор" +
            "\nЧтобы посмотреть корзину товаров введите К\nЧтобы выйти и завершить выбор нажмите В");
        do
        {
            string Switch = Console.ReadLine();
            switch (Switch)
            {
                case "Телевизор":
                    basket.Add(TV);
                    Console.WriteLine("Вы добавили в корзину Телевизор");
                    break;
                case "Телефон":
                    basket.Add(Phone);
                    Console.WriteLine("Вы добавили в корзину Телефон");
                    break;
                case "ПК":
                    basket.Add(PC);
                    Console.WriteLine("Вы добавили в корзину ПК");
                    break;
                case "К":
                    ShowBasket();
                    break;
                case "В":
                    ShowBasket();
                    return;
                default:
                    Console.WriteLine("Неизвестный товар!");
                    break;
            }
        } while (true);
    }
    internal void ShowBasket()
    {
        Console.WriteLine("Ваша корзина товаров:");
        foreach (var temp in basket)
        {
            Console.WriteLine(temp);
        }
    }
    internal void ShowProducts()
    {
        Console.WriteLine("Ассортимент товаров:");
        Console.WriteLine(TV);
        Console.WriteLine(PC);
        Console.WriteLine(Phone);
    }
}
class Program
{
    private static Delivery ChooseDelivery()
    {
        ShopDelivery shopDelivery;
        HomeDelivery homeDelivery;
        Console.WriteLine("Выберите тип доставки:\n1 - Доставка в магазин" +
            "\n2 - Доставка на дом курьером");
        do
        {
            string Switch = Console.ReadLine();
            switch (Switch)
            {
                case "1":
                    shopDelivery = new ShopDelivery();
                    Console.WriteLine("Вы выбрали доставку в магазин! Самовывоз из магазина по адресу {0}", shopDelivery.Address);
                    return shopDelivery;
                case "2":
                    Console.Write("Введите адрес доставки: ");
                    string address = Console.ReadLine();
                    homeDelivery = new HomeDelivery(address);
                    return homeDelivery;
                default:
                    Console.WriteLine("Некорректный ввод! Формат 1 или 2!");
                    break;
            }
        } while (true);
    }
    static void Main(string[] args)
    {
        //Сделать перегрузку оператора + для сложения цен?
        Console.WriteLine("Добро пожаловать в магазин!");
        MyProducts myProducts = new();
        myProducts.AddProducts();
        var choosenDelivery = ChooseDelivery();
        Order<Delivery, MyProducts> order = new(choosenDelivery, myProducts);
        Console.WriteLine("Ваш заказ успешно сформирован!\nСписок ваших продуктов: {0}\nТип доставки: {1}", order.TypesOfMyProducts, 
        order.TypeOfDelivery);




    }
}