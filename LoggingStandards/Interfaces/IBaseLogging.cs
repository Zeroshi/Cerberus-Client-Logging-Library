using System;
using System.Threading.Tasks;
using CerberusLogging.Classes.Enums;
using Microsoft.Extensions.Logging;
using static CerberusLogging.Classes.Enums.MetaData;

namespace CerberusClientLogging.Interfaces
{
    public interface IBaseLogging
    {
        //Task<bool> SendBaseLogInformationAsync(LogLevel logLevel, string application_name, string log);
        //Task<bool> SendBaseLogInformationAsync(LogLevel logLevel, string application_name, MetaData.Environment? enviroment, Encryption? encryption, string? platformlatform, bool? onlyInnerException, Exception? exception, IdentifiableInformation? identifiable_information, Type? destination, TransactionDestinationTypes? destination_type, string? payload, string? note, string log);


        //void Information(LogLevel logLevel, string message);
        //void Information(LogLevel logLevel, string application_name, string message);

        Task<bool> SendApplicationLogAsync(string applicationMessage, string currentMethod, LogLevel logLevel,
            string log,
            string? applicationName, string? platform, bool? onlyInnerException,
            string? note, Exception? error, TransactionDestination? transactionDestination,
            TransactionDestinationTypes? transactionDestinationTypes, Encryption? encryption,
            MetaData.Environment? environment, IdentifiableInformation? identifiableInformation, string? payload);
    }
}