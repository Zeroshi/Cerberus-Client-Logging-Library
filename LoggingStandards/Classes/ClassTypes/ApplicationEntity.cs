﻿using System;
using CerberusLogging.Interfaces.Objects;


namespace CerberusLogging.Classes.ClassTypes
{
    internal class ApplicationEntity : IApplicationEntity
    {
        public string ApplicationMessage { get; set; } = String.Empty;
        public string CurrentMethod { get; set; } = string.Empty;
        public IEntityBase? EntityBase { get; set; }
    }
}