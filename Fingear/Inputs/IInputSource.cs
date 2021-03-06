﻿using System.Collections.Generic;

namespace Fingear.Inputs
{
    public interface IInputSource
    {
        string DisplayName { get; }
        InputSourceType Type { get; }
        IEnumerable<IInput> InstantiatedInputs { get; }
        IEnumerable<IInput> GetAllInputs();
    }
}