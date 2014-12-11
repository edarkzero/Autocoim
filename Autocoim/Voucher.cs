using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocoim
{
    class Voucher
    {
        public Voucher()
        {
            razon_social = "";
            vendor_doc_num = "";
            txt_field = "";
            tax_amount = 0;
            tax_det_perc = 0;
            taxable_amount = 0;
            document_date = new DateTime();
            posting_date = new DateTime();
        }

        public void print()
        {

        }

        public string RazonSocial
        {
            get
            {
                return razon_social;
            }
            set
            {
                if(value != null)
                    razon_social = value;
            }
        }

        public string VendorDocNum
        {
            get
            {
                return vendor_doc_num;
            }
            set
            {
                if (value != null)
                    vendor_doc_num = value;
            }
        }

        public string txtField
        {
            get
            {
                return txt_field;
            }
            set
            {
                if (value != null)
                    txt_field = value;
            }
        }

        public double taxDetPerc
        {
            get
            {
                return tax_det_perc;
            }
            set
            {
                if (value != null)
                    tax_det_perc = value;
            }
        }

        public double taxAmount
        {
            get
            {
                return tax_amount;
            }
            set
            {
                if (value != null)
                    tax_amount = value;
            }
        }

        public double taxableAmount
        {
            get
            {
                return taxable_amount;
            }
            set
            {
                if (value != null)
                    taxable_amount = value;
            }
        }

        public DateTime documentDate
        {
            get
            {
                return document_date;
            }
            set
            {
                if (value != null)
                    document_date = value;
            }
        }

        public DateTime postingDate
        {
            get
            {
                return posting_date;
            }
            set
            {
                if (value != null)
                    posting_date = value;
            }
        }

        private string razon_social,vendor_doc_num,txt_field;
        private double tax_det_perc,tax_amount,taxable_amount;
        private DateTime document_date, posting_date;
    }
}
