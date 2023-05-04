namespace Tax_Api.Common
{
    public static class Extension
    {
        public static long GetTimeStamp()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            TimeSpan timeSpan = DateTime.Now - epoch;

            return (long)timeSpan.TotalSeconds;
        }
    }
}
