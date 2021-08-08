using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework2.webapi.Classes;

namespace Homework2.webapi.Worker
{
    /// <summary>
    /// Регулятор
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Закрыть выставленный счёт
        /// </summary>
        /// <param name="client">клиент</param>
        /// <param name="orderId">номер счёта</param>
        public void CloseOrder(Client client, int orderId)
        {
            for (int i = 0; i < client.OpenedOrders.Count; i++)
            {
                if (client.OpenedOrders[i].Id == orderId)
                {
                    client.ClosedOrders.Add(client.OpenedOrders[i]);
                    client.OpenedOrders.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Закрыть все выставленные действующие счета
        /// </summary>
        /// <param name="client">клиент</param>
        public void CloseAllOrders(Client client)
        {
            foreach (var item in client.OpenedOrders)
            {
                client.ClosedOrders.Add(item);
            }
            client.OpenedOrders.Clear();
        }
        /// <summary>
        /// Добавить исполнителя <paramref name="employer"/> в контракт <paramref name="contract"/>
        /// </summary>
        /// <param name="contract">контракт</param>
        /// <param name="employer">исполнитель</param>
        public void AddEmployer(Contract contract, Employe employer)
        {
            contract.Employers.Add(employer);
            contract.Order = Status.InProgress;
        }
        /// <summary>
        /// Выставить счёт по контракту <paramref name="contract"/>
        /// </summary>
        /// <param name="contract">контракт</param>
        /// <returns></returns>
        public Invoice GetInvoice(Contract contract)
        {
            if (contract.InvoiceCount < contract.Parts)
            {
                contract.InvoiceCount += 1;
                return new Invoice(contract.InvoiceCount, contract.ContractCost / contract.Parts, contract.Id);
            }
            return null;
        }
        /// <summary>
        /// Выставить счёт на остаток по контракту
        /// </summary>
        /// <param name="contract">контракт</param>
        /// <returns>список счетов</returns>
        public List<Invoice> FinalInvoice(Contract contract)
        {
            List<Invoice> result = new List<Invoice>();
            for (int i = contract.InvoiceCount; i < contract.Parts; i++)
            {
                result.Add(GetInvoice(contract));
            }
            return result;
        }
        /// <summary>
        /// Закрыть контракт
        /// </summary>
        /// <param name="contract">контракт</param>
        public void CloseContract(Contract contract)
        {
            contract.CloseDate = DateTime.Now;
            contract.Order = Status.Closed;
        }
        /// <summary>
        /// Добавить табель учёта рабочего времени в контракт
        /// </summary>
        /// <param name="name">наименование работ</param>
        /// <param name="ETS">табель учёта рабочего времени</param>
        /// <param name="contract">контракт</param>
        public void AddTimeSheetToContract(string name, EmployerTimeSheet ETS, Contract contract)
        {
            contract.Estimate.Add(name, ETS);
        }

    }
}
