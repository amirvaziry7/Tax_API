using Newtonsoft.Json;
using Tax_Api.Bussines;

InvoiceHeader invoiceHeader = new InvoiceHeader()
{
    taxid = Guid.NewGuid().ToString(),
    indatim = Extension.GetTimeStamp(),
    indati2m = Extension.GetTimeStamp(),
    inty = 1,
    inno = "1234567890",
    irtaxid = Guid.NewGuid().ToString().Substring(0, 22),
    inp = 1,
    ins = 1,
    tins = 1234567890,
    tob = 1,
    bid = 1111111111,
    tinb = 1111111111,
    sbc = null,
    bbc = null,
    billid = null,
    bpc = 1234567890,
    bpn = null,
    cap = null,
    crn = null,
    ft = null,
    insp = null,
    scc = null,
    scln = null,
    setm = 1,
    tadis = 545000,
    tax17 = null,
    tbill = 50000,
    tdis = 0,
    todam = null,
    tprdis = 545000,
    tvam = 45000,
    tvop = null
};
InvoiceBody invoiceBody = new InvoiceBody()
{
    sstid = 12,
    sstt = "موس کامپیوتر",
    am = 2,
    mu = "تعداد",
    fee = 250000,
    cfee = 1,
    cut = "نیمایی",
    exr = 1,
    prdis = 250000,
    dis = 0,
    adis = 250000,
    vra = 0.09,
    vam = 22500,
    odt = null,
    odr = null,
    odam = null,
    olt = null,
    olr = null,
    olam = null,
    consfee = null,
    spro = null,
    bros = null,
    bsrn = null,
    cop = null,
    tcpbs = null,
    tsstam = 272500,
    vop = null,
};
InvoicePayment invoicePayment = new InvoicePayment()
{
    acn = null,
    iinn = null,
    pcn = null,
    pdt = null,
    pid = null,
    trmn = null,
    trn = null
};

Invoice invoice = new Invoice()
{
    InvoiceBodies = new List<InvoiceBody>()
    {
        invoiceBody
    },
    InvoiceHeader = invoiceHeader,
    invoicePayment = invoicePayment
};

string json = JsonConvert.SerializeObject(invoice, Formatting.Indented);
Console.WriteLine(json);
var Crypt = CryptoUtilities.NormalJson(json, new Dictionary<string, string>());
Console.WriteLine(Crypt);

var SignData = Utilities.SignData(Crypt, "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCEQ/9+GqsFqHdy\r\nKy3NfLLusm898IwM9wmA/t/9kBnlwhrl2f4KkaTZmM/c+GxFZ4t2V+nrOwuGMTuU\r\nyLDbG75PB5CLUhZeH2oEIh9Be5cI4m/3iJN7cXpSmAlPk9Y37HE7UFrGQ4ThMFp0\r\nnYauy3Rhpt5NYcx6SQA504POb/y98XZClAt7tGcEnpZcVIVs9X/sKXngJhRuZiKg\r\nT3ebs8LdV6EIhE99Y2d6UHW+Qqzvp3hNlapK/8QGvJoaGR6o2vrl9p4OTmRdYsTD\r\nV52NFieexDuUyV0q4opJovS7k6RkWze4DTmtGZ7XeIdW2SK0QKdvYzc6HKPRNi2v\r\n53mUqqKxAgMBAAECggEABEclf2b2CPtgXSPEwgqeaDJi3xNNmVIAZ4De3mbzsnrl\r\nJzHmOcHpDb1nvDU3/cTuBaJtaz18N392Ro846qZOoQRc7kel9+5+zaJLpeDdI0U9\r\nIznCcOW8Q8l9dBqjTSjfZvBn9jWK+cRYSaEqcPL9STcGJcUz8ZDUwjoLT2EPgPZv\r\nYhq8ars3XbXPFeb8zyW1ORPGvuHZavn8wYSWN+v2NjmLFBaNCwmOxNulWcAM4uUx\r\n6PPRASDP4mzzrguYtIF0fixrw61iYK9/GO4U6AUdjLcR6vPciJM3lqIUXO/6+Ct2\r\nLbJIjCiV3S8Q1b78T5UEhD2kKRvlLpdt9NAbub9FIQKBgQC2bNFPRneE+Z2WT3hd\r\nvUqp3i6LIq+hu9BKuBheVH8xL8m6NaxZS5vq7FenPQPJcu5Cw+B45VkJVHWWkdm+\r\njc5Yd0OP7zEODpxi3XF2nMpIimlVObIy6xOmAvCkyk+k52+c+UoHswufv+6ZvftY\r\ncWJRovusny1EqfQBodqpvsW70QKBgQC5nEYOwJu7AS10PPLlJZtwL7DgCC/QDZs+\r\nFmokUfw0erspiseUx99Jel076DlHY0LHB0LfM/XhCR4U8kpKSU0NPXzMTcKXtISx\r\nex1P5BK1GAJTy69HmsmcXd1UlSSEj6fsGLhPs42Bwghjx9p8D3SIt9i1qws8KT7M\r\nvl7AWUuQ4QKBgCxQYsgPJhl3SYCp7WNYCDsbbdL+qgtvxDliXwkLHZqlMSu6vhMy\r\n+r0mjGRjvffBo380deLoU6igi6/33h0b9XQoBJGCWThA9FxPzrAxhjH47X12doNH\r\n943sSOi+/HnifopzRDh6lehIh31xWQ0y/d826EwWnrh/UHbVCnkRjpcBAoGBAImS\r\nUb7XddXKjqUsE6BSGn6xanjyuHWN0DXZqTxYZAWFvjmROlKFPnOYtYgUnHfUE4ev\r\nUxpayfDMsDY4S2X6JJkerORE8mk9DGj75oLzegYt0HPJcZYyHSK/06/Ah3uVepIc\r\n1GeGnujBJzTFyaPQVMCM+5vTNhWWQIzCwTnyNXchAoGAbv8RRWU1cYAH762cYf7D\r\nYC73HOKjLfgqDKXyBaYdCkTWU5ehlDGCCLnVuqA4JPssiauBn0/ByUjpWOgHz+72\r\nC79I+X4X6hGdB2fFi48JM8ZeCMHAJ4VjNBVyfU25Bf8guhh+BOIyiYrIZUFUD1Wu\r\n2rJLoUR114NFywaAkCRdQw4=");
Console.WriteLine(SignData);

byte[] _SecretKey = Utilities.GenerateRandomByteArray(16);
byte[] payload = Convert.FromBase64String(SignData);
byte[] _IV = Utilities.GenerateRandomByteArray(16); ;

var res = Utilities.AesEncrypt(payload, _SecretKey, _IV);
Console.WriteLine(res);
Console.ReadKey();