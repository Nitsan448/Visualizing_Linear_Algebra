using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VectorsManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public object result { get; private set; }

    public Vector3 firstVector { get; private set; }
    public Vector3 secondVector { get; private set; }

    public VectorOperation vectorOperation { get; private set; }

    public static Action VectorUpdated;

    [SerializeField] private bool controlVectorsWithMouse;
    [SerializeField] private bool controlVectorOne;

	private void OnEnable()
	{
        VectorUpdated += UpdateResult;
        ChooseOperationUI.OperationChanged += UpdateResult;
	}

	private void OnDisable()
	{
        VectorUpdated -= UpdateResult;
        ChooseOperationUI.OperationChanged -= UpdateResult;
    }

	public void Startup()
    {
        status = ManagerStatus.Initializing;

        firstVector = new Vector3(5, 12, 0);
        secondVector = new Vector3(-4/5f, 3/5f, 0);
        result = Vector3.zero;
        vectorOperation = new VectorOperation(eVectorOperations.dotProduct);

        status = ManagerStatus.Started;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        //Only update result if vectors or operation changed (use event)
        result = vectorOperation.DoOperation(firstVector, secondVector);

        if (controlVectorsWithMouse)
        {
            ControlVectorsWithMouse();
        }
    }

    private void UpdateResult()
    {
        result = vectorOperation.DoOperation(firstVector, secondVector);
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

        if (controlVectorOne)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 vector = Camera.main.ScreenToWorldPoint(mousePos);

            firstVector = worldPosition;
            VectorUpdated?.Invoke();
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 vector = Camera.main.ScreenToWorldPoint(mousePos);
            secondVector = worldPosition;
            VectorUpdated?.Invoke();
        }
    }

    public void SetFirstVector(string newVector)
	{
        firstVector = StringToVector3(newVector);
        VectorUpdated?.Invoke();
	}

    public void SetSecondVector(string newVector)
    {
        secondVector = StringToVector3(newVector);
        VectorUpdated?.Invoke();
    }

    private static Vector3 StringToVector3(string vector)
	{
        if (vector.StartsWith("(") && vector.EndsWith(")"))
        {
            vector = vector.Substring(1, vector.Length - 2);
        }
        else if (vector.StartsWith("("))
        {
            vector = vector.Substring(1, vector.Length - 1);
        }
        else if (vector.EndsWith(")"))
        {
            vector = vector.Substring(0, vector.Length - 2);
        }
        string[] vectorValues = vector.Split(',');

        Vector3 result = new Vector3(float.Parse(vectorValues[0]),
            float.Parse(vectorValues[1]), float.Parse(vectorValues[2]));

        return result;
    }
}
