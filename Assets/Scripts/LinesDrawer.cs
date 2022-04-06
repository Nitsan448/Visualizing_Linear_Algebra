using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
    [SerializeField] private Material _firstVectorMaterial;
    [SerializeField] private Material _secondVectorMaterial;
    [SerializeField] private Material _resultVectorMaterial;

    [SerializeField] private float _startWidth = 0.03f;
    [SerializeField] private float _endWidth = 0.015f;
    
    private GameObject _firstLine;
    private GameObject _secondLine;
    private GameObject _resultLine;

    private void Start()
    {
        _firstLine = new GameObject();
        _secondLine = new GameObject();
        _resultLine = new GameObject();

        _firstLine.AddComponent<LineRenderer>();
        _secondLine.AddComponent<LineRenderer>();
        _resultLine.AddComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateAllLines();
    }

    private void UpdateAllLines()
    {
        UpdateLine(_firstLine, Vector3.zero, Managers.Vectors.firstVector, _firstVectorMaterial);
        UpdateLine(_secondLine, Vector3.zero, Managers.Vectors.secondVector, _secondVectorMaterial);

        Vector3 result;
        if (Managers.Vectors.result.GetType() == typeof(Vector3))
        {
            result = (Vector3)Managers.Vectors.result;
            UpdateLine(_resultLine, Vector3.zero, result, _resultVectorMaterial);
        }
        else
        {
            UpdateLine(_resultLine, Vector3.zero, Vector3.zero, _resultVectorMaterial);
        }
    }

    void UpdateLine(GameObject line, Vector3 startPosition, Vector3 endPosition, Material material)
    {
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.startWidth = _startWidth;
        lineRenderer.endWidth = _endWidth;

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
