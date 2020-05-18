using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TransitionController transitionController;

    public void PlayGame()
    {
        transitionController.FadeToLevel(2);
    }

    public void PlayStory()
    {
        transitionController.FadeToLevel(1);
    }

    public void PlayInstructions()
    {
        transitionController.FadeToLevel(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
