using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRbPosition : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private Vector3 rbStartPosition;
    private Quaternion rbStartRotation;
    void Start()
    {
        UIButtonHandler.OnResetButtonClick += ResetRigitBodyPosition;
        rbStartPosition = rb.transform.localPosition;
        rbStartRotation = rb.transform.localRotation;
    }

    void ResetRigitBodyPosition()
    {
        rb.isKinematic = true;
        rb.transform.localPosition = rbStartPosition;
        rb.transform.localRotation = rbStartRotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnDestroy()
    {
        UIButtonHandler.OnResetButtonClick -= ResetRigitBodyPosition;
    }
}
