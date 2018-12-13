﻿using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Localization;

namespace Volo.Abp.Settings
{
    public class SettingDefinition
    {
        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        [NotNull]
        public string Name { get; }

        [NotNull]
        public ILocalizableString DisplayName
        {
            get => _displayName;
            set => _displayName = Check.NotNull(value, nameof(value));
        }
        private ILocalizableString _displayName;

        [CanBeNull]
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        [CanBeNull]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Can clients see this setting and it's value.
        /// It maybe dangerous for some settings to be visible to clients (such as an email server password).
        /// Default: false.
        /// </summary>
        public bool IsVisibleToClients { get; set; }

        /// <summary>
        /// Is this setting inherited from parent scopes.
        /// Default: True.
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// Can be used to get/set custom properties for this setting definition.
        /// </summary>
        [NotNull]
        public Dictionary<string, object> Properties { get; }

        /// <summary>
        /// Is this setting stored as encrypted in the data source.
        /// Default: False.
        /// </summary>
        public bool IsEncrypted { get; set; }

        public SettingDefinition(
            string name,
            string defaultValue = null,
            ILocalizableString displayName = null,
            ILocalizableString description = null,
            bool isVisibleToClients = false,
            bool isInherited = true,
            bool isEncrypted = false)
        {
            Name = name;
            DefaultValue = defaultValue;
            IsVisibleToClients = isVisibleToClients;
            DisplayName = displayName ?? new FixedLocalizableString(name);
            Description = description;
            IsInherited = isInherited;
            IsEncrypted = isEncrypted;

            Properties = new Dictionary<string, object>();
        }
    }
}