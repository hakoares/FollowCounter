namespace InstaCounter.Data
{
    public class InstaHistoryDatabaseSettings: IInstaHistoryDatabaseSettings
    {
        public string InstaHistoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IInstaHistoryDatabaseSettings
    {
        string InstaHistoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}