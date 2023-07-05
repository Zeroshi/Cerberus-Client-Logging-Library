using CerberusLogging.Classes.ClassTypes;
using Microsoft.Extensions.Logging;

namespace CerberusLogging.Interfaces
{
    interface IApplication
    {
        void AttemptedTrace(LogLevel logLevel, string sender, string receiver, string message, ApplicationEntity applicationEntity);
        void StackTrace(LogLevel logLevel, string message);
    }
}
