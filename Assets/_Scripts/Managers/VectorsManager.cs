using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VectorsManager : MonoBehaviour, IGameManager
{
    public static Action VectorsUpdated;

    public eManagerStatus status { get; private set; }
    public object result { get; private set; }
    public VectorOperation vectorOperation { get; private set; }
    public Dictionary<int, Vector3> vectorByIndex{ get; private set; }

    [SerializeField] private bool controlFirstVector;

	public void Startup()
    {
        status = eManagerStatus.Initializing;

        vectorOperation = new VectorOperation(eVectorOperations.dotProduct);
        InitializeVectorByIndexDictionary();
        UpdateResult();

        status = eManagerStatus.Started;
    }

    private void InitializeVectorByIndexDictionary()
	{
        vectorByIndex = new Dictionary<int, Vector3>();
        vectorByIndex[1] = new Vector3(1, 1, 0);
        vectorByIndex[2] = new Vector3(-1, -1, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ControlVectorsWithMouse();
        }
    }

    public void SetVectorByString(int vector, string newVector)
    {
        vectorByIndex[vector] = StringExtensions.VectorStringToVector3(newVector);
        UpdateResult();
    }

    public void UpdateResult()
    {
        result = vectorOperation.DoOperation(vectorByIndex[1], vectorByIndex[2]);
        VectorsUpdated?.Invoke();
    }

    private Vector3 FloatListToVector(List<float> floatList)
	{
        return new Vector3(floatList[0], floatList[1], floatList[2]);
	}

    private void ControlVectorsWithMouse()
    {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Vector3 worldPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        if (controlFirstVector)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 vector = Camera.main.ScreenToWorldPoint(mousePos);
            vectorByIndex[1] = worldPosition;
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 vector = Camera.main.ScreenToWorldPoint(mousePos);
            vectorByIndex[2] = worldPosition;
        }
        UpdateResult();
    }
}
