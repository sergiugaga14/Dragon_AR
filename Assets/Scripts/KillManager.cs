using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    private int killCount = 0;
    public static KillManager Instance;  // Singleton reference

    [SerializeField] private TextMeshProUGUI killCountText;  // UI Text element

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
        Debug.Log("Kill Count: " + killCount);
        UpdateKillCountUI();
    }

    public void ResetKillCount()
    {
        killCount = 0;
        UpdateKillCountUI();
    }

    public int GetKillCount()
    {
        return killCount;
    }

    private void UpdateKillCountUI()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }
}
