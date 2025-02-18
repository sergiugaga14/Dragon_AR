using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DragonCreator : MonoBehaviour
{
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private float spawnDistance = 2f;
    void Start()
    {
        UIButtonHandler.OnStartButtonClick += CreateDragon;
    }

    private void CreateDragon()
    {
        Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;

        // Instantiate object at the calculated position
        GameObject instance = Instantiate(dragonPrefab, spawnPosition, Quaternion.identity);

        // Make the object look at the camera
        instance.transform.LookAt(Camera.main.transform);
        
    }

}
