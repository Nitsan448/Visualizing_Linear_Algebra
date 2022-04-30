using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TransformationsManager : MonoBehaviour, IGameManager
{
    public static Action TransformationApplied;
    public eManagerStatus status { get; private set; }
    public Transform ObjectToTransform;
    public eTransformValue transformValueToManipulate = eTransformValue.Position;

    [SerializeField] private TMP_InputField _firstRow;
    [SerializeField] private TMP_InputField _secondRow;
    [SerializeField] private TMP_InputField _thirdRow;
    [SerializeField] private TMP_InputField _fourthRow;

    private Matrix4x4 _matrix;

    public void Startup()
    {
        status = eManagerStatus.Initializing;
        status = eManagerStatus.Started;
    }

    public void ApplyTransformation()
	{
        UpdateMatrix();

		switch (transformValueToManipulate)
		{
            case eTransformValue.Position:
                ObjectToTransform.position = _matrix * ObjectToTransform.position;
                break;

            case eTransformValue.Rotation:
                Vector3 newRotation = _matrix * ObjectToTransform.eulerAngles;
                ObjectToTransform.rotation = Quaternion.Euler(newRotation);
                break;

            case eTransformValue.Scale:
                ObjectToTransform.localScale = _matrix * ObjectToTransform.localScale;
                break;
        }

        TransformationApplied?.Invoke();
    }

    private void UpdateMatrix()
	{
        FloatListToMatrixRow(0, StringExtensions.VectorStringToFloatList(_firstRow.text));
        FloatListToMatrixRow(1, StringExtensions.VectorStringToFloatList(_secondRow.text));
        FloatListToMatrixRow(2, StringExtensions.VectorStringToFloatList(_thirdRow.text));
        FloatListToMatrixRow(3, StringExtensions.VectorStringToFloatList(_fourthRow.text));
    }

    private void FloatListToMatrixRow(int row, List<float> floatList)
    {
        Vector4 result = new Vector4(floatList[0], floatList[1], floatList[2], floatList[3]);
        _matrix.SetRow(row, result);
    }
}
