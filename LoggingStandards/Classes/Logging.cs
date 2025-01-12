using System;
using System.Threading.Tasks;
using CerberusClientLogging.Interfaces;
using CerberusLogging.Classes.Enums;
using Microsoft.Extensions.Logging;

namespace CerberusClientLogging.Implementations
{
    public class Logging : IBaseLogging
    {
        public async Task<bool> SendApplicationLogAsync(
            string applicationMessage,
            string currentMethod,
            LogLevel logLevel,
            string log,
            string? applicationName,
            string? platform,
            bool? onlyInnerException,
            string? note,
            Exception? error,
            ITransactionDestination? transactionDestination,
            TransactionDestinationTypes? transactionDestinationTypes,
            IEncryption? encryption,
            IEnvironment? environment,
            IIdentifiableInformation? identifiableInformation,
            string? payload)
        {
            // Example Implementation: Replace this with actual logic.
            Console.WriteLine($"Application Message: {applicationMessage}");
            Console.WriteLine($"Current Method: {currentMethod}");
            Console.WriteLine($"Log Level: {logLevel}");
            Console.WriteLine($"Log: {log}");
            Console.WriteLine($"Application Name: {applicationName}");
            Console.WriteLine($"Platform: {platform}");
            Console.WriteLine($"Only Inner Exception: {onlyInnerException}");
            Console.WriteLine($"Note: {note}");
            Console.WriteLine($"Error: {error?.Message}");
            Console.WriteLine($"Transaction Destination: {transactionDestination?.Name}");
            Console.WriteLine($"Transaction Destination Types: {transactionDestinationTypes}");
            Console.WriteLine($"Encryption: {encryption?.IsEnabled}");
            Console.WriteLine($"Environment: {environment?.Name}");
            Console.WriteLine($"Identifiable Information: {identifiableInformation?.Identifier}");
            Console.WriteLine($"Payload: {payload}");

            // Simulate a task delay for async
            await Task.Delay(10);

            // Indicate successful execution
            return true;
        }
    }
}
