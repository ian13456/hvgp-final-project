using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private GameManager()
    {
        // initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
        // because the game manager will be created before the objects
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    /* -------------------------------------------------------------------------- */
    /*                     ADD GAME MANAGER MEMBERS DOWN HERE                     */
    /* -------------------------------------------------------------------------- */
    public void test(bool tester)
    {
        Debug.Log(tester ? "damn." : "damn?");
    }
}
