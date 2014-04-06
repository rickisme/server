using GameServer.Config;
using GameServer.Model.Account;
using GameServer.Model.Character;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace GameServer.Database
{
    public class MdbCharacter
    {
        private static MdbCharacter Instance;

        public static MdbCharacter GetInstance()
        {
            return (Instance != null) ? Instance : Instance = new MdbCharacter();
        }

        private MongoClient m_Client;
        private MongoServer m_Server;
        private MongoDatabase m_Database;

        private string MDBCharacterTable = "characters";

        public MdbCharacter()
        {
            m_Client = new MongoClient(Configuration.Database.Url);
            m_Server = m_Client.GetServer();
            m_Database = m_Server.GetDatabase(Configuration.Database.Name);
        }
        public IDictionary<int, Character> GetListChar(string username)
        {
           IDictionary<int, Character> result = new Dictionary<int, Character>();
           var collection = m_Database.GetCollection<Character>(MDBCharacterTable);
           var query = Query<Character>.EQ(c => c.AccountName, username);
           var cursor = collection.Find(query);
           var count = cursor.Count(); 
           if (count > 0)
           {
               // load list character 
           }
           return result;
        }
        public void AddCharacter(Character Char)
        {
            var collection = m_Database.GetCollection<Character>(MDBCharacterTable);
            collection.Insert(Char);
        }
    }
}
