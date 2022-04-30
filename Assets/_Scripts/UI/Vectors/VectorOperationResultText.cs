using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VectorOperationResultText : MonoBehaviour
{
    private TextMeshProUGUI _resultText;

	private void OnEnable()
	{
		_resultText = GetComponent<TextMeshProUGUI>();
		VectorsManager.VectorsUpdated += UpdateResultText;
	}

	private void OnDisable()
	{
		VectorsManager.VectorsUpdated -= UpdateResultText;
	}

	private void UpdateResultText()
	{
        _resultText.text = $"Result = {Managers.Vectors.result}";
    }
}
