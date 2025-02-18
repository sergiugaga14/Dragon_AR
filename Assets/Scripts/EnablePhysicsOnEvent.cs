using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhysicsOnEvent : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        UIButtonHandler.OnStartButtonClick += StartPhysics;
    }

    private void StartPhysics()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnDestroy()
    {
        UIButtonHandler.OnStartButtonClick -= StartPhysics;
    }

}
