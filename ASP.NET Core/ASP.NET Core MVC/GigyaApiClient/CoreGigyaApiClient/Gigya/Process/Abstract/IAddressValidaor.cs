using System;
using System.Collections.Generic;
using Gigya.Model.Models;

namespace Gigya.Process.Abstract
{
    public interface IAddressValidaor
    {
        Tuple<bool, IDictionary<string, string>> ValidateAddress(Address address);
    }
}
