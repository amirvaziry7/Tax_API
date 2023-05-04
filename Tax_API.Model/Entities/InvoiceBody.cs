namespace Tax_Api.Model.Entities
{
    public class Invoice
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public List<InvoiceBody> InvoiceBodies { get; set; }
        public InvoicePayment invoicePayment { get; set; }
    }
    public class InvoiceBody
    {
        public int sstid { get; set; }
        public string sstt { get; set; }
        public int am { get; set; }
        public string mu { get; set; }
        public double fee { get; set; }
        public double cfee { get; set; }
        public string cut { get; set; }
        public double exr { get; set; }
        public double prdis { get; set; }
        public double dis { get; set; }
        public double adis { get; set; }
        public double vra { get; set; }
        public double vam { get; set; }
        public double tsstam { get; set; }

#nullable enable
        public string? odt { get; set; }
        public double? odr { get; set; }
        public double? odam { get; set; }
        public string? olt { get; set; }
        public double? olr { get; set; }
        public double? olam { get; set; }
        public double? consfee { get; set; }
        public double? spro { get; set; }
        public double? bros { get; set; }
        public double? tcpbs { get; set; }
        public double? cop { get; set; }
        public double? vop { get; set; }
        public int? bsrn { get; set; }
#nullable disable
    }
}
