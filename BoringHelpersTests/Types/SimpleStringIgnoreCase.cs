using BoringHelpers.Types;
using System;
using System.Collections.Generic;

namespace BoringHelpersTests.Types
{
    public class SimpleStringIgnoreCase : CaseInsensitiveMetadata
    {
        public SimpleStringIgnoreCase(string value)
            : base(value) { }
    }
}
