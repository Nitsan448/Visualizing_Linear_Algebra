using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VectorUI : MonoBehaviour
{
	[SerializeField] private bool firstVector;

	private void OnEnable()
	{
		VectorsManager.VectorUpdated += UpdateVectorUI;
	}

	private void OnDisable()
	{
		VectorsManager.VectorUpdated -= UpdateVectorUI;
	}

	private void Start()
	{
		GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate { SetVector(); });
	}

	private void SetVector()
	{
		if (firstVector)
		{
			Managers.Vectors.SetFirstVector(GetComponent<TMP_InputField>().text);
		}
		else
		{
			Managers.Vectors.SetSecondVector(GetComponent<TMP_InputField>().text);
		}
	}

	private void UpdateVectorUI()
	{
		Vector3 vector = Vector3.zero;
		if (firstVector)
		{
			vector = Managers.Vectors.firstVector;
		}
		else
		{
			vector = Managers.Vectors.secondVector;
		}
		string newVectorText = "(" + vector.x.ToString("F") + ", " + vector.y.ToString("F") + ", " + vector.z.ToString("F") + ")";

		GetComponent<TMP_InputField>().text = newVectorText;
	}
}
