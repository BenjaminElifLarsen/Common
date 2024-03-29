﻿namespace Common.MementoPattern;
public interface IOriginator<TMemento> where TMemento : IMemento
{
    TMemento CreateMemento();
}
