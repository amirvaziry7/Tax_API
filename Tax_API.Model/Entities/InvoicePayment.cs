namespace Tax_Api.Model.Entities
{
    public class InvoicePayment
    {
#nullable enable
        public int? iinn { get; set; }
        public int? acn { get; set; }
        public int? trmn { get; set; }
        public int? trn { get; set; }
        public int? pcn { get; set; }
        public int? pid { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        public int? pdt { get; set; }
#nullable disable
    }
}
