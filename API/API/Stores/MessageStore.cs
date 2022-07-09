using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Common.Store;
using Dapper;

namespace API.Stores
{

    public interface IMessageStore
    {
        Task SaveMessage(Message message);
        Task<List<Message>> GetAllMessages();
    }

    public class MessageStore : IMessageStore
    {
        private readonly IDbConnectionHolder _connection;

        public MessageStore(IDbConnectionHolder connection)
        {
            _connection = connection;
        }
        
        public async Task SaveMessage(Message message)
        {
            const string sql = @"
                            INSERT INTO Messages (id, date, content, number)
                            VALUES (@Id, @Date, @Content, @Number)
                            ";

            await _connection.Application.ExecuteAsync(sql, message);
        }

        public async Task<List<Message>> GetAllMessages()
        {
            const string sql = @"SELECT * FROM Messages";
            return (await _connection.Application.QueryAsync<Message>(sql)).ToList();
        }
    }
}