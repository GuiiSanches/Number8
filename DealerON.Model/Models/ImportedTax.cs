using DealerON.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Model.Models.Abstract
{
    public class ImportedTax : ITax
    {
        private decimal _TaxPercent => (decimal)5;
        public decimal GetTaxPercent()
        {
            return _TaxPercent;
        }
    }
}
