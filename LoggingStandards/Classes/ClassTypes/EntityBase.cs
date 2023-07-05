using System;
using CerberusLogging.Interfaces.Objects;
using Microsoft.Extensions.Logging;
using static CerberusLogging.Classes.Enums.MetaData;

namespace CerberusLogging.Classes.ClassTypes
{

    /// <summary>
    /// Metadata concerning the message
    /// </summary>
    public class EntityBase : IEntityBase
    {
        public Guid MessageId { get; set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public LogLevel LogLevel { get; set; } = LogLevel.None;
        public string? Application_Name { get; set; }
        public string Log { get; set; } = string.Empty;
        public string? Platform { get; set; }
        public bool? OnlyInnerException { get; set; }
        public string? Note { get; set; }
        public Exception? Error { get; set; }
        public Encryption? Encryption { get; set; }
        public Enums.MetaData.Environment? Environment { get; set; }
        public IdentifiableInformation? IdentifiableInformation { get; set; }
        public string? Payload { get; set; }
    }
}
