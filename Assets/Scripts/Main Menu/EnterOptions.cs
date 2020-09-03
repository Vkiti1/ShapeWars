using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOptions : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void OptionsOnClick()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
