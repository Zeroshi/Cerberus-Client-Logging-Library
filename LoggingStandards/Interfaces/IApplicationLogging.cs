using System;
using System.Threading.Tasks;
using CerberusLogging.Classes.Enums;
using Microsoft.Extensions.Logging;
using static CerberusLogging.Classes.Enums.MetaData;

namespace CerberusClientLogging.Interfaces
{
    public interface IApplicationLogging
    {
        Task<bool> SendBaseLogInformationAsync(string applicationMessage, string currentMethod, LogLevel logLevel,
            string application_name, MetaData.Environment? enviroment, Encryption? encryption, string? platformlatform,
            bool? onlyInnerException, Exception? exception, IdentifiableInformation? identifiable_information,
            TransactionDestination? destination, TransactionDestinationTypes? destination_type, string? payload,
            string? note, string log);
    }
}