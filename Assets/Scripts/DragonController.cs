using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick joystick;
    private Rigidbody rb;
    private Animator animator;
    public float resetTime = 0.5f;

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        UIButtonHandler.OnShootButtonClick += Attack;
    }

    private void Attack()
    {
        animator.SetBool("IsAttacking", true);
        StartCoroutine(ResetBoolAfterDelay("IsAttacking", resetTime));
    }

    private System.Collections.IEnumerator ResetBoolAfterDelay(string paramName, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(paramName, false);
    }

    private void FixedUpdate()
    {
        float xVal = joystick.Horizontal;
        float yVal = joystick.Vertical;

        Vector3 movement = new Vector3(xVal,0, yVal);
        rb.velocity = movement * speed;

        if (xVal != 0 && yVal != 0)
        {
            animator.SetBool("IsMoving", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlackGoat"))
        {
            Animator animator = other.gameObject.GetComponent<Animator>();
            if (animator != null && !animator.GetBool("IsDead"))
            {
                animator.SetBool("IsDead", true);
                KillManager.Instance.IncreaseKillCount();
            }

        }

    }



    private void OnDestroy()
    {
        Destroy(animator);
        KillManager.Instance.ResetKillCount();
        UIButtonHandler.OnShootButtonClick -= Attack;
    }
}
