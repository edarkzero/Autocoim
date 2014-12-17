using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocoim
{
    class Voucher
    {
        public Voucher(string n)
        {
            name = n;
            doc_num = "";
            razon_social = "";
            vendor_doc_num = "";
            txt_field = "";            
            tax_amount = 0;
            tax_det_perc = 0;
            taxable_amount = 0;
            document_date = new DateTime();
            posting_date = new DateTime();
            today = DateTime.Today;
            setComprobanteData();            
        }

        public void print()
        {
            PdfManager pdfManager = new PdfManager(PdfManager.TYPE_IVA,this);
            pdfManager.render();
        }

        public void setComprobanteData()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Autocoim");
            bool diferentPeriod = false;
            string comprobanteDate;

            try
            {
                comprobanteDate = key.GetValue("comprobante date").ToString();

                if (comprobanteDate != getPeriodoFiscal())
                {
                    key.SetValue("comprobante date", getPeriodoFiscal());
                    diferentPeriod = true;
                }
            }
            catch
            {
                key.SetValue("comprobante date", getPeriodoFiscal());
                comprobanteDate = getPeriodoFiscal();
            }

            try
            {
                comprobante_key = (int)key.GetValue("comprobante key");

                if (!diferentPeriod)
                {
                    key.SetValue("comprobante key", ++comprobante_key);
                }
                else
                {
                    key.SetValue("comprobante key", 0);
                    comprobante_key = 0;
                }
            }
            catch
            {
                key.SetValue("comprobante key", 0);
                comprobante_key = 0;
            }

            key.Close();
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

        public string DocNum
        {
            get
            {
                return doc_num;
            }
            set
            {
                if (value != null)
                    doc_num = value;
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    name = value;
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
                tax_det_perc = Math.Abs(value);
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
                tax_amount = Math.Abs(value);
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
                taxable_amount = Math.Abs(value);
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

        public string getNroComprobante()
        {
            return getPeriodoFiscal() + comprobante_key;
        }

        public string getPeriodoFiscal()
        {
            return today.ToString("yyyyMM");
        }      
  
        public string getFechaComprobante()
        {
            return today.ToShortDateString();
        }

        public string getTaxPercent()
        {
            return tax_det_perc + "%";
        }

        public string getTax()
        {
            return Math.Round(taxable_amount * (tax_det_perc / 100), 2).ToString();
        }

        private string razon_social, vendor_doc_num, txt_field, name,doc_num;
        private double tax_det_perc, tax_amount, taxable_amount;
        private DateTime document_date, posting_date,today;
        private int comprobante_key;
        public const string RAZON_FS = "FLOWSERVE DE VENEZUELA C.C.A.";
        public const string RIF_FS = "J002723335";
        public const string DIR_FS = "AV. 68 # 149B155 ZONA INDUSTRIAL II ETAPA MARACAIBO ESTADO ZULIA VENEZUELA";
        public const string NOTA = "Ley IVA  Art. 11: Serán Responsables del pago del impuesto en calidad de agentes de retención, los comprobantes o adquirentes de determinados bienes muebles y los receptores de ciertos servicios, a quienes la administración tributaria decida como tal.";
    }
}
