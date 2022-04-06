using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChooseOperationUI : MonoBehaviour
{
    private TMP_Dropdown dropDown;
    public static Action OperationChanged;

    // Start is called before the first frame update
    void Start()
    {
        dropDown = GetComponent<TMP_Dropdown>();

        dropDown.ClearOptions();
        List<string> options = new List<string>();
        options.Add(eVectorOperations.dotProduct.ToString());
        options.Add(eVectorOperations.crossProduct.ToString());
        options.Add(eVectorOperations.reflection.ToString());
        options.Add(eVectorOperations.projection.ToString());

        dropDown.AddOptions(options);
        dropDown.onValueChanged.AddListener(delegate { SetVectorOperation(dropDown.value); });
    }



    public void SetVectorOperation(int operationIndex)
    {
        eVectorOperations operation = (eVectorOperations)operationIndex;
        Managers.Vectors.vectorOperation.operation = operation;
        OperationChanged?.Invoke();
    }
}
