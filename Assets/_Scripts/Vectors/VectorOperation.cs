using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class VectorOperation
{
    public eVectorOperations operation;

    public VectorOperation(eVectorOperations vectorOperation)
    {
        operation = vectorOperation;
    }

    public object DoOperation(Vector3 firstVector, Vector3 secondVector)
    {
        switch (operation)
        {
            case eVectorOperations.dotProduct:
                return Vector3.Dot(firstVector, secondVector);

            case eVectorOperations.crossProduct:
                return Vector3.Cross(firstVector, secondVector);

            case eVectorOperations.reflection:
                return Vector3.Reflect(firstVector, secondVector);

            case eVectorOperations.projection:
                return Vector3.Project(firstVector, secondVector);
        }
        return Vector3.zero;
    }
}
