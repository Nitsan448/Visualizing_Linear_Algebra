using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private TextMeshProUGUI resultText;

    public void Startup()
    {
        status = ManagerStatus.Started;
        return;
    }

    private void Update()
    {
        resultText.text = $"Result = {Managers.Vectors.result}";
    }
}
