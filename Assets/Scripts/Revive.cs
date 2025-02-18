using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private void Start()
    {
        UIButtonHandler.OnResetButtonClick += BringToLife;
    }

    private void BringToLife()
    {
        Animator animator = obj.GetComponent<Animator>();
        if(animator != null)
        {
            animator.SetBool("IsDead", false);
        }
    }

    private void OnDestroy()
    {
        UIButtonHandler.OnResetButtonClick -= BringToLife;
    }
}
