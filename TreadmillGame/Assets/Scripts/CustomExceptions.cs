using System.Collections;
using System.Collections.Generic;
using System;

public class MultiplePersistentObjectsOfSameTypeException : Exception
{
    public MultiplePersistentObjectsOfSameTypeException()
    {

    }

    public MultiplePersistentObjectsOfSameTypeException(string message) : base(message)
    {

    }

    public MultiplePersistentObjectsOfSameTypeException(string message, Exception inner) : base(message, inner)
    {

    }
}


