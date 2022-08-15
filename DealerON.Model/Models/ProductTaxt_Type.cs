using DealerON.Model.Models.Abstract;
using DealerON.Model.Models.Enum;
using DealerON.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Model.Models
{
    public class ProductTaxt_Type
    {
       public ProductTaxt_Type(EnumType taxType)
        {
            switch(taxType)
            {
                case EnumType.Book:
                    this.TaxValue = new FreeTax();
                    break;
                case EnumType.Food:
                    this.TaxValue = new FreeTax();
                    break;
                case EnumType.Medical:
                    this.TaxValue = new FreeTax();
                    break;
                case EnumType.Imported:
                    this.TaxValue = new ImportedTax();
                    break;
                default:
                    this.TaxValue = new BasicTax();
                    break;
            }
            
            this.Type = taxType;
        }
        public EnumType Type { get; set; }
        public ITax TaxValue { get; private set; }
    }
}
