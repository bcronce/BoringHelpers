using System;
using System.Collections.Generic;

namespace BoringHelpers.Types
{
    public abstract class CaseInsensitiveMetadata : SimpleMetadata<string>
    {
        protected override IEqualityComparer<string> EqualityComparer { get { return StringComparer.OrdinalIgnoreCase; } }
        protected override IComparer<string> Comparer { get { return StringComparer.OrdinalIgnoreCase; } }

        protected CaseInsensitiveMetadata(string value)
            : base(value) { }
    }
}
