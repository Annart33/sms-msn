using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Stores;

namespace API.Services
{

    public interface IMessageService
    {
        Task SaveMessage(Message message);
        Task<List<Message>> GetAllMessages();
    }

    public class MessageService : IMessageService
    {

        private readonly IMessageStore _messageStore;
        
        public MessageService(IMessageStore messageStore)
        {
            _messageStore = messageStore;
        }

        public async Task SaveMessage(Message message)
        {
            await _messageStore.SaveMessage(message);
        }
        
        public async Task<List<Message>> GetAllMessages()
        {
            return await _messageStore.GetAllMessages();
        }
    }
}