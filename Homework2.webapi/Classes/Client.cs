using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.webapi.Classes
{
    public class Client
    {
        private int Id { get; set; }
        public string Name { get; private set; }
        public Contract MyContract { get; private set; }
        public List<Invoice> OpenedOrders { get; private set; }
        public List<Invoice> ClosedOrders { get; private set; }
        public Client(string name, Contract contract, int id)
        {
            Name = name;
            MyContract = contract;
            Id = id;
        }
        public void CloseOrder(int orderId)
        {
            for (int i = 0; i < OpenedOrders.Count; i++)
            {
                if (OpenedOrders[i].Id==orderId)
                {
                    ClosedOrders.Add(OpenedOrders[i]);
                    OpenedOrders.RemoveAt(i);
                }
            }
        }
        public void CloseAllOrders()
        {
            foreach (var item in OpenedOrders)
            {
                ClosedOrders.Add(item);
            }
            OpenedOrders.Clear();
        }
    }
}
