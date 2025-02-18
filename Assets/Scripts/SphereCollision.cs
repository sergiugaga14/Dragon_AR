using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading;

public class SphereCollision : MonoBehaviour
{
/*
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("BlackGoat"))
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
            }

            KillManager.Instance.IncreaseKillCount();
           
        }
    }
*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BlackGoat"))
        {
            Animator animator = other.gameObject.GetComponent<Animator>();
            if (animator != null && !animator.GetBool("IsDead"))
            {
                animator.SetBool("IsDead", true);
                KillManager.Instance.IncreaseKillCount();
            }
            
        }
    }

}
