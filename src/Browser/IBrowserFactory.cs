// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;

using Wangkanai.Detection.Models;

namespace Wangkanai.Detection
{
    public interface IBrowserFactory
    {
        string? Maker { get; }
        Version? Version { get; }
        string? Name { get; }
        Browser Type { get; }
    }
}