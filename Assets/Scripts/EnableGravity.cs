using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        UIButtonHandler.OnStartButtonClick += StartGravity;
        Debug.Log("SERJ");
    }

    private void StartGravity()
    {
        Debug.Log("SERJ2");

    }

}
