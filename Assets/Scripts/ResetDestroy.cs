using ARMagicBar.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDestroy : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    void Start()
    {
        UIButtonHandler.OnResetButtonClick += DestroyBody;
    }

    private void DestroyBody()
    {
        DestroyImmediate(obj);
    }

    void OnDestroy()
    {
        UIButtonHandler.OnResetButtonClick -= DestroyBody;
    }
}
