using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject currentMenu;

    public void GoBack()
    {
        currentMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
