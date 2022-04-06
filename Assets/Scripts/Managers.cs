using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static UIManager UI { get; private set; }
    public static VectorsManager Vectors { get; private set; }
    private List<IGameManager> startSequence;

    void Awake()
    {
        UI = GetComponentInChildren<UIManager>();
        Vectors = GetComponentInChildren<VectorsManager>();
        startSequence = new List<IGameManager>();
        startSequence.Add(UI);
        startSequence.Add(Vectors);
        StartCoroutine(StartupManagers());
    }
    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in startSequence)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log($"Progress: {numReady}/{numModules}");
            yield return null;
        }
        Debug.Log("All managers started up");
    }
}
