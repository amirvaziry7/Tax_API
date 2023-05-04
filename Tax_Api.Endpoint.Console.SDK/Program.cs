using Tax_Api.Common;
using Tax_Api.Model.Entities;
using TaxCollectData.Library.Abstraction.Signatory;
using TaxCollectData.Library.Business;
using TaxCollectData.Library.Dto.Config;
using TaxCollectData.Library.Dto.Content;
using TaxCollectData.Library.Dto.Properties;
using TaxCollectData.Library.Enums;

string PK = "";
string Path = "Path Private Key";
using (StreamReader OSR = new StreamReader(Path))
{
    while (!OSR.EndOfStream)
    {
        PK += OSR.ReadLine();
    }
}





TaxApiService.Instance.Init("",
    new SignatoryConfig(PK, null),
    new NormalProperties(ClientType.SELF_TSP),
    "https://sandboxrc.tax.gov.ir");
var ResultServerInformation = await TaxApiService.Instance.TaxApis.GetServerInformationAsync();

var economicCodeInformation =
TaxApiService.Instance.TaxApis.GetEconomicCodeInformation("");

var Token = TaxApiService.Instance.TaxApis.RequestToken();


var random = new Random();
long randomSerialDecimal = random.Next(999999999);
var now = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
var taxId = TaxApiService.Instance.TaxIdGenerator.GenerateTaxId("",
randomSerialDecimal, DateTime.Now);
var header = new InvoiceHeaderDto
{
    Inty = 1,
    Inp = 1,
    Inno = randomSerialDecimal.ToString(),
    Ins = 1,
    Tins = "Economy Code",
    Tprdis = 1000_000,
    Tdis = 0,
    Tvam = 0,
    Todam = 0,
    Tbill = 1000_000,
    Setm = 1,
    Cap = 1000_000,
    Insp = 1000_000,
    Tvop = 0,
    Tax17 = 0,
    Indatim = now,
    Indati2m = now,
    Taxid = taxId
};
var body = new InvoiceBodyDto
{
    Sstid = "1111111111",
    Sstt = "پاستوریزه چرب کم شیر",
    Mu = "23",
    Am = 2,
    Fee = 500_000,
    Prdis = 500_000,
    Dis = 0,
    Adis = 500_000,
    Vra = 0,
    Vam = 0,
    Tsstam = 1000_000
};
var payment = new PaymentDto
{
    Iinn = "1131244211",
    Acn = "2131244212",
    Trmn = "3131244213",
    Trn = "4131244214"
};
var invoices = new List<InvoiceDto>{
 new()
 {
 Body = new() {body},
 Header = header,
 Payments = new() {payment}
 }
};





var ResultSendInvoice = await TaxApiService.Instance.TaxApis.SendInvoicesAsync(invoices, null);

var packetResponse = ResultSendInvoice.Body.Result.First();
var uid = packetResponse.Uid;
var referenceNumber = packetResponse.ReferenceNumber;

Console.WriteLine(uid);
Console.WriteLine(referenceNumber);

