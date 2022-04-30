using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class VisualizationStateDropDown : MonoBehaviour
{
    private TMP_Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        dropDown = GetComponent<TMP_Dropdown>();

        dropDown.ClearOptions();
        List<string> options = new List<string>();
        options.Add(eVisualizationState.vectorOperations.ToString());
        options.Add(eVisualizationState.matrixTransformations.ToString());

        dropDown.AddOptions(options);
        dropDown.onValueChanged.AddListener(delegate { SetVisualizationState(dropDown.value); });
        dropDown.value = 0;
    }



    public void SetVisualizationState(int operationIndex)
    {
        eVisualizationState newState = (eVisualizationState)operationIndex;
        Managers.VisualizationState.SetVisualizationState(newState);
    }
}
