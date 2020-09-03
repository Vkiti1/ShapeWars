using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTutorial : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject tutorialMenu;

    public void TutorialOnClick()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void TutorialExit()
    {
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }
}
