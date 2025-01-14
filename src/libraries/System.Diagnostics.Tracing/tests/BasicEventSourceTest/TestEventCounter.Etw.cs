// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Xunit;

namespace BasicEventSourceTests
{
    public partial class TestEventCounter
    {
        // Specifies whether the process is elevated or not.
        private static bool IsProcessElevated => Environment.IsPrivilegedProcess;

        [ConditionalFact(nameof(IsProcessElevated))]
        [ActiveIssue("https://github.com/dotnet/runtime/issues/25035")]
        public void Test_Write_Metric_ETW()
        {
            using (var listener = new EtwListener())
            {
                Test_Write_Metric(listener);
            }
        }
    }
}
