using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2.webapi.Classes
{
    public class Invoice
    {
        public int Id { get; private set; }
        public int ContractId { get; private set; }
        public int ListId { get; private set; }
        public double Bill { get; private set; }
        public Invoice(int id,double bill, int contractId)
        {
            Id = id;
            Bill = bill;
            ContractId = contractId;
        }
        public void SetListId(int listId)
        {
            ListId = listId;
        }
    }
}
