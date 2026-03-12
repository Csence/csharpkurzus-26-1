using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Calculator.Core;

public sealed class Either<TSuccess, TError>
{
    private readonly TSuccess? _success;
    private readonly bool _isSucces;
    private readonly TError? _error;

    private Either(TSuccess success)
    {
        _success = success;
        _isSucces = true;
    }

    private Either(TError error)
    {
        _error = error; 
        _isSucces = false;
    }

    public static implicit operator Either<TSuccess, TError>(TSuccess success)
    {
        return new Either<TSuccess, TError>(success);
    }

    public static implicit operator Either<TSuccess, TError>(TError error)
    {
        return new Either<TSuccess, TError>(error);
    }

    public bool TryGetSuccess([NotNullWhen(true)] out TSuccess?  success)
    {
        if (_isSucces)
        {
            success = _success!;
            return true;
        }

        success = default;
        return false;
    }

    public bool TryGetError([NotNullWhen(true)]out TError? error)
    {
        if (!_isSucces)
        {
            error = _error!;
            return true; 
        }

        error = default; 
        return false;
    }
}
