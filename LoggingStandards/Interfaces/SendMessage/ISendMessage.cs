using System;
using System.Threading.Tasks;

namespace CerberusClientLogging.Interfaces.SendMessage
{
    public interface ISendMessage
    {
        Task<bool> SendMessageAsync(string payload, Guid messageId);
    }
}