using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Task_2
{
    internal class Store : MonoBehaviour
    {
        private readonly Good _iPhone12 = new Good("Iphone 12");
        private readonly Good _iPhone11 = new Good("Iphone 11");

        private readonly Warehouse _warehouse = new Warehouse();

        private Shop _shop;

        public void Start()
        {
            _shop = new Shop(_warehouse);

            _warehouse.Delive(_iPhone12, 10);
            _warehouse.Delive(_iPhone11, 1);

            foreach (var cell in _warehouse.StockGoods)
            {
                Console.WriteLine($"{cell.Good} - {cell.Count}");
            }

            Cart cart = _shop.Cart();
            cart.Add(_iPhone12, 4);
            cart.Add(_iPhone11, 3);

            foreach (var good in cart.OrderedGoods)
            {
                Console.WriteLine($"{good.Good} - {good.Count}");
            }

            Console.WriteLine(cart.Order().Paylink);
        }
    }
}
