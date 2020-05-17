using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public TransitionController transitionController;

    public void Menu()
    {
        transitionController.FadeToLevel(0);
    }
}
