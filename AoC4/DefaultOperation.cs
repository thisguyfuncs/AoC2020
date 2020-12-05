﻿using static System.Guid;

namespace AoC4
{
    public class DefaultOperation :
       ITransientOperation,
       IScopedOperation,
       ISingletonOperation
    {
        public string OperationId { get; } = NewGuid().ToString()[^4..];
    }
}
