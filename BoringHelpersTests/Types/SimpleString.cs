﻿using BoringHelpers.Types;
using System;
using System.Collections.Generic;

namespace BoringHelpersTests.Types
{
    public class SimpleString : SimpleMetadata<string>
    {
        public SimpleString(string value)
            : base(value) { }
    }
}
