using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateLevels : MonoBehaviour
{
    public Button tutorialLv;
    public Button firstLv;
    public Button secondLv;
    public Button thirdLv;
    public Button fourthLv;
    
    void Start()
    {
        switch (PlayerPrefs.GetInt("levelsWon")) {
            case 0:
                tutorialLv.interactable = true;
                firstLv.interactable = false;
                secondLv.interactable = false;
                thirdLv.interactable = false;
                fourthLv.interactable = false;
                break;
            case 1:
                tutorialLv.interactable = true;
                firstLv.interactable = true;
                secondLv.interactable = false;
                thirdLv.interactable = false;
                fourthLv.interactable = false;
                break;
            case 2:
                tutorialLv.interactable = true;
                firstLv.interactable = true;
                secondLv.interactable = true;
                thirdLv.interactable = false;
                fourthLv.interactable = false;
                break;
            case 3:
                tutorialLv.interactable = true;
                firstLv.interactable = true;
                secondLv.interactable = true;
                thirdLv.interactable = true;
                fourthLv.interactable = false;
                break;
            case 4:
                tutorialLv.interactable = true;
                firstLv.interactable = true;
                secondLv.interactable = true;
                thirdLv.interactable = true;
                fourthLv.interactable = true;
                break;
            case 5:
                tutorialLv.interactable = true;
                firstLv.interactable = true;
                secondLv.interactable = true;
                thirdLv.interactable = true;
                fourthLv.interactable = true;
                break;

        }
    }
}
