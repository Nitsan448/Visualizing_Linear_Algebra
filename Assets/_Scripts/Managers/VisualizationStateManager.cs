using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationStateManager: MonoBehaviour, IGameManager
{
	public eManagerStatus status { get; private set; }

	[SerializeField] private GameObject _vectorOperationsUI;
	[SerializeField] private GameObject _vectorOperationsObjects;

	[SerializeField] private GameObject _transformationsUI;
	[SerializeField] private GameObject _transformationsObjects;

	[SerializeField] private eVisualizationState _startingVisualizationState;

	private static eVisualizationState _visualizationState;

	public void Startup()
	{
		status = eManagerStatus.Initializing;
		SetVisualizationState(_startingVisualizationState);
		status = eManagerStatus.Started;
	}

	public void SetVisualizationState(eVisualizationState newState)
	{
		_visualizationState = newState;

		switch (_visualizationState)
		{
			case eVisualizationState.vectorOperations:
				UpdateVectorOperationsEnabledState(true);
				UpdateTransformationsEnabledState(false);
				break;
			case eVisualizationState.matrixTransformations:
				UpdateTransformationsEnabledState(true);
				UpdateVectorOperationsEnabledState(false);
				break;
		}
	}

	private void UpdateVectorOperationsEnabledState(bool enabled)
	{
		_vectorOperationsUI.SetActive(enabled);
		_vectorOperationsObjects.SetActive(enabled);
	}
	private void UpdateTransformationsEnabledState(bool enabled)
	{
		_transformationsUI.SetActive(enabled);
		_transformationsObjects.SetActive(enabled);
	}
}
