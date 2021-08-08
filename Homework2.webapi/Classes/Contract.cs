using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.webapi.Classes
{
    public enum Status
    {
        Open,
        InProgress,
        Closed
    }
    public class Contract
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Заказчик
        /// </summary>
        public Client Customer { get; set; }
        /// <summary>
        /// Лист исполнителей
        /// </summary>
        public List<Employe> Employers { get; set; }
        /// <summary>
        /// Дата заключения контракта
        /// </summary>
        public DateTime OpenDate { get; set; }
        /// <summary>
        /// Дата завершения контракта
        /// </summary>
        public DateTime CloseDate { get; set; }
        /// <summary>
        /// Статус контракта
        /// </summary>
        public Status Order { get; set; }
        /// <summary>
        /// Количество частей контракта
        /// </summary>
        public int Parts { get; private set; }
        /// <summary>
        /// Количество выставленных счетов
        /// </summary>
        public int InvoiceCount { get; set; }
        /// <summary>
        /// Полная стоимость контракта
        /// </summary>
        public double ContractCost { get; set; }
        /// <summary>
        /// Список работ по контракту
        /// </summary>
        public Dictionary<string,EmployerTimeSheet> Estimate { get; set; }

        public Contract(Client customer, Employe employer)
        {
            Customer = customer;
            Employers = new List<Employe>();
            Estimate = new Dictionary<string, EmployerTimeSheet>();
            Employers.Add(employer);
            OpenDate = DateTime.Now;
            Order = Status.Open;
        }
        public Contract(Client customer, List<Employe> employers)
        {
            Customer = customer;
            Employers = employers;
        }
        
    }
}
