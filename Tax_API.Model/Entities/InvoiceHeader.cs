namespace Tax_Api.Model.Entities
{
    public class InvoiceHeader
    {
        public string taxid { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        public long indatim { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        public long indati2m { get; set; }
        public int inty { get; set; }
        public string inno { get; set; }
        public string irtaxid { get; set; }
        public int inp { get; set; }
        public int ins { get; set; }
        public int tins { get; set; }
        public int tob { get; set; }
        public int bid { get; set; }
        public int tinb { get; set; }
        public int bpc { get; set; }
        public double tprdis { get; set; }
        public double tdis { get; set; }
        public double tadis { get; set; }
        public double tvam { get; set; }
        public double tbill { get; set; }
        public int setm { get; set; }

#nullable enable
        public int? sbc { get; set; }
        public int? bbc { get; set; }
        public int? ft { get; set; }
        public string? bpn { get; set; }
        public int? scln { get; set; }
        public int? scc { get; set; }
        public int? crn { get; set; }
        public int? billid { get; set; }
        public double? todam { get; set; }
        public double? cap { get; set; }
        public double? insp { get; set; }
        public double? tvop { get; set; }
        public double? tax17 { get; set; }
#nullable disable
    }
}
