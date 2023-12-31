﻿using System;
using System.Threading.Tasks;
using CerberusClientLogging.Classes.ClassTypes;
using CerberusClientLogging.Classes.Queues;
using CerberusClientLogging.Interfaces;
using CerberusClientLogging.Interfaces.SendMessage;
using CerberusLogging.Classes.Enums;
using CerberusLogging.Interfaces.Objects;
using Microsoft.Extensions.Logging;
using static CerberusLogging.Classes.Enums.MetaData;

namespace CerberusClientLogging.Classes
{
    public class Logging : IBaseLogging
    {
        private readonly LoggingDestination.Type _loggingType;
        private readonly LogLevel _loggingLevel;
        private readonly string _connectionString;
        private readonly string _queueName;
        private readonly string _topicName;
        private readonly ISendMessage _targetDestinationTool;
        private readonly string _applicationName;

        public Logging(string applicationName, LoggingDestination.Queue queueType, LogLevel logLevel,
            string connectionString, string queueName)
        {
            _loggingLevel = logLevel;
            _connectionString = connectionString;
            _queueName = queueName;
            _applicationName = applicationName;

            switch (queueType)
            {
                case LoggingDestination.Queue.Azure_Queue:
                    _targetDestinationTool = new AzureQueueStorage(queueName, connectionString);
                    break;
                // case LoggingDestination.Queue.RabbitMq_Queue:
                //     _targetDestinationTool = new RabbitMqQueue(queueName, connectionString);
                //     break;
                // case LoggingDestination.Queue.Azure_Service_Bus:
                //     _targetDestinationTool = new AzureServiceBusQueue(queueName, connectionString);
                //     break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(queueType), "Invalid queue type.");
            }
        }

        public Logging(string applicationName, LoggingDestination.Database database, LogLevel logLevel,
            string connectionString)
        {
            _loggingLevel = logLevel;
            _connectionString = connectionString;
            _applicationName = applicationName;

            // switch for database types
        }

        //// Storage Queue with Topics
        //public Logging(LoggingDestination.Type loggingType, LogLevel logLevel, string connectionString, string queueName, string topicName)
        //{
        //    _loggingType = loggingType;
        //    _loggingLevel = logLevel;
        //    _connectionString = connectionString;
        //    _queueName = queueName;
        //    _topicName = topicName;
        //}

        //// API
        //public Logging(LoggingDestination.Type loggingType, LogLevel logLevel, string apiUrl, string apiName, string payloadLocation)
        //{
        //    _loggingType = loggingType;
        //    _loggingLevel = logLevel;
        //    _connectionString = apiUrl;
        //}

        private async Task<bool> SendToQueueSelection(string payload)
        {
            return await _targetDestinationTool.SendMessageAsync(payload, new Guid());
        }

        public void Event(LogLevel logLevel, string message)
        {
            var events = new EntityBase
            {
                LogLevel = logLevel,
                Log = message
            };

            var entityBase = new EntityBase();
            var app = new ApplicationEntity();
        }

        public Task<bool> SendApplicationLogAsync(string applicationMessage, string currentMethod, LogLevel logLevel,
            string log)
        {
            return SendBaseLogInformationAsync(applicationMessage, currentMethod, logLevel, log);
        }

        private Task<bool> SendBaseLogInformationAsync(string applicationMessage, string currentMethod,
            LogLevel logLevel, string log)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendApplicationLogAsync(string applicationMessage, string currentMethod, LogLevel logLevel,
            string log,
            string? applicationName = null, string? platform = null, bool? onlyInnerException = null,
            string? note = null, Exception? error = null, TransactionDestination? transactionDestination = null,
            TransactionDestinationTypes? transactionDestinationTypes = null, Encryption? encryption = null,
            MetaData.Environment? environment = null, IdentifiableInformation? identifiableInformation = null,
            string? payload = null)
        {
            return SendApplicationLogAsync(applicationMessage, currentMethod, logLevel, log, platform,
                onlyInnerException,
                note, error, encryption, environment, identifiableInformation, payload);
        }

        public async Task<bool> SendApplicationLogAsync(string applicationMessage, string currentMethod,
            LogLevel logLevel, string log, string? platform = null, bool? onlyInnerException = null,
            string? note = null, Exception? error = null, Encryption? encryption = null,
            CerberusLogging.Classes.Enums.MetaData.Environment? environment = null,
            IdentifiableInformation? identifiableInformation = null,
            string? payload = null)
        {
            var applicationLog = new ApplicationEntity();
            applicationLog.ApplicationMessage = applicationMessage;
            applicationLog.CurrentMethod = currentMethod;
            applicationLog.EntityBase = await CreateBaseLogInformationAsync(logLevel, log, platform,
                onlyInnerException, note, error, encryption, environment, identifiableInformation, payload);

            string applicationJson = await CreateApplicationLogMessageJson(applicationLog);
            return await SendJsonMessageAsync(applicationJson);
        }

        public Task<IEntityBase> CreateBaseLogInformationAsync(LogLevel logLevel, string log, string? platform,
            bool? onlyInnerException, string? note, Exception? error,
            Encryption? encryption, CerberusLogging.Classes.Enums.MetaData.Environment? environment,
            IdentifiableInformation? identifiableInformation, string? payload)
        {
            IEntityBase entityBase = new EntityBase();
            entityBase.LogLevel = logLevel;
            entityBase.Log = log;
            entityBase.Application_Name = _applicationName;
            entityBase.Platform = platform;
            entityBase.OnlyInnerException = onlyInnerException;
            entityBase.Note = note;
            entityBase.Error = error;
            entityBase.Encryption = encryption;
            entityBase.Environment = environment;
            entityBase.IdentifiableInformation = identifiableInformation;
            entityBase.Payload = payload;

            return Task.FromResult(entityBase);
        }

        private async Task<bool> SendJsonMessageAsync(string jsonMessage)
        {
            if (_loggingType == LoggingDestination.Type.Azure_Queue ||
                _loggingType == LoggingDestination.Type.Azure_Service_Bus ||
                _loggingType == LoggingDestination.Type.RabbitMq_Queue ||
                _loggingType == LoggingDestination.Type.RabbitMq_Topic)
            {
                return await Task
                    .FromResult(await SendToQueueSelection("azqueue |" + jsonMessage).ConfigureAwait(false))
                    .ConfigureAwait(false);
            }
            else if (_loggingType == LoggingDestination.Type.PostgreSql_Database ||
                     _loggingType == LoggingDestination.Type.PostgreSql_Database)
            {
                // todo: add database connections
            }
            else if (_loggingType == LoggingDestination.Type.API_Restful)
            {
                // todo: add api rest connections
            }

            return false;
        }

        private Task<string> CreateApplicationLogMessageJson(ApplicationEntity applicationEntity)
        {
            var convertToJson = new ConvertToJson();
            return Task.FromResult(convertToJson.ConvertApplicationMessageToJson<ApplicationEntity>(applicationEntity));
        }
    }
}