using System.Collections.Generic;
using InstaCounter.Data;
using MongoDB.Driver;

namespace InstaCounter.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _account;
        
        public AccountService(InstaHistoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _account = database.GetCollection<Account>(settings.InstaHistoryCollectionName);
        }
        
        public List<Account> Get() =>
            _account.Find(account => true).ToList();

        public Account Get(string id) =>
            _account.Find<Account>(account => account.Id == id).FirstOrDefault();

        public Account Create(Account account)
        {
            _account.InsertOne(account);
            return account;
        }

        public void Update(string id, Account accountIn) =>
            _account.ReplaceOne(account => account.Id == id, accountIn);

        public void Remove(Account accountIn) =>
            _account.DeleteOne(account => account.Id == accountIn.Id);

        public void Remove(string id) => 
            _account.DeleteOne(account => account.Id == id);
        
        
        
    }
}