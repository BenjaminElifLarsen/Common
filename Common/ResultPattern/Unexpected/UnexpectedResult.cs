﻿using Common.ResultPattern.Enums;

namespace Common.ResultPattern;

public class UnexpectedResult<T> : Result<T>
{
    private readonly string[] _errors;

    public UnexpectedResult(params string[] errors)
    {
        _errors = errors;
    }

    public override ResultTypes ResultType => ResultTypes.Unexpected;

    public override string[] Errors => _errors;

    public override T Data => default;
}
