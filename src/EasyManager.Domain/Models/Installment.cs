using System;
using EasyManager.Domain.Core.Model;

namespace EasyManager.Domain.Models
{
    public class Installment : Entity
    {
        public int Number { get; set; }
        public DateTime Due { get; set; }
        public double Value { get; set; }
        public string Information { get; set; }
    }
}