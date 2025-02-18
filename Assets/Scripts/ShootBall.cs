using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float ballForwardForce = 500f;

    void Start()
    {
        UIButtonHandler.OnShootButtonClick += ShootBallOnClick;
    }

    private void ShootBallOnClick()
    {
        GameObject dragon = GameObject.FindWithTag("BlueDragon");
        Vector3 spawnPosition = dragon.transform.position + dragon.transform.forward * 0.1f;
        spawnPosition.y += 0.1f;
        Quaternion spawnRotation = dragon.transform.rotation;
        Debug.Log(spawnPosition);
  
        GameObject spawnedBall = Instantiate(ball, spawnPosition, spawnRotation);
        Rigidbody rb= spawnedBall.GetComponent<Rigidbody>();
        Vector3 modifiedForward = Quaternion.AngleAxis(20f, dragon.transform.right) * dragon.transform.forward;

        if (rb != null )
        {
            rb.AddForce(modifiedForward * ballForwardForce);
        }

        Destroy(spawnedBall, 5f);
    }

   }
