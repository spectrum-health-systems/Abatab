﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using ScriptLinkStandard.Objects;

namespace ScriptLinkStandard.Interfaces
{
    public interface IFieldObject
    {
        string Enabled { get; set; }
        string FieldNumber { get; set; }
        string FieldValue { get; set; }
        string Lock { get; set; }
        string Required { get; set; }

        FieldObject Clone();
        string GetFieldValue();
        bool IsEnabled();
        bool IsLocked();
        bool IsModified();
        bool IsRequired();
        void SetAsDisabled();
        void SetAsEnabled();
        void SetAsLocked();
        void SetAsModified();
        void SetAsOptional();
        void SetAsRequired();
        void SetAsUnlocked();
        void SetFieldValue(string fieldValue);
        
        string ToHtmlString(bool includeHtmlHeaders);
        string ToJson();
    }
}
