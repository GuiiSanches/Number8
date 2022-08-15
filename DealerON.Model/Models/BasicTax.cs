using DealerON.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Model.Models
{
    public class BasicTax : ITax
    {
        private decimal _TaxPercent => (decimal)10;
        public decimal GetTaxPercent()
        {
            return _TaxPercent;
        }
    }
}
