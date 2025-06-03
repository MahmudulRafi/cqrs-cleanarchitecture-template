﻿using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Application.Exceptions
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
