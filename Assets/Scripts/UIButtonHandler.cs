using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ShootButton;
    [SerializeField] private Button ResetButton;
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private TextMeshProUGUI winningText;

    public static event Action OnStartButtonClick;
    public static event Action OnShootButtonClick;
    public static event Action OnResetButtonClick;

    private int noOfGoats;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClicked);
        ShootButton.onClick.AddListener(OnShootButtonClicked);
        ResetButton.onClick.AddListener(OnResetButtonClicked);

        ShootButton.gameObject.SetActive(false);
        fixedJoystick.gameObject.SetActive(false);
        winningText.gameObject.SetActive(false);

    }

    void OnStartButtonClicked()
    {
        OnStartButtonClick?.Invoke();
        StartButton.gameObject.SetActive(false);
        ShootButton.gameObject.SetActive(true);
        fixedJoystick.gameObject.SetActive(true);
        noOfGoats = GameObject.FindGameObjectsWithTag("BlackGoat").Length;
    }

    void OnShootButtonClicked() 
    {
        OnShootButtonClick?.Invoke();
    }

    void OnResetButtonClicked()
    {
        OnResetButtonClick?.Invoke();
        StartButton.gameObject.SetActive(true);
        ShootButton.gameObject.SetActive(false);
        fixedJoystick.gameObject.SetActive(false);
        winningText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(KillManager.Instance.GetKillCount() == noOfGoats && noOfGoats != 0)
        {
            winningText.gameObject.SetActive(true);
        }
    }
}
