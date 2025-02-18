using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBar : MonoBehaviour
{
    [SerializeField] private Canvas ARMagicBar;

    void Start()
    {
        UIButtonHandler.OnStartButtonClick += Hide;
        UIButtonHandler.OnResetButtonClick += Show;
    }

   private void Hide()
   {
        ARMagicBar.enabled = false;
   }

   private void Show()
   {
        ARMagicBar.enabled = true;
   }

    private void OnDestroy()
    {
        UIButtonHandler.OnStartButtonClick -= Hide;
        UIButtonHandler.OnResetButtonClick -= Show;
    }


}
