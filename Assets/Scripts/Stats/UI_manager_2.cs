using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager_2 : MonoBehaviour
{

    [SerializeField] private TextWriter textWriter;
    public int scenes = 0;
    private Text messageText;

    private int bob;

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<Text>();
    }
    private void Start()
    {

        if (scenes == 0)
        {
            messageText.text = "This is you, an agent named Epsilon.";
            textWriter.AddWriter(messageText, "This is you, an agent named Epsilon.", 0.05f);
        }
        if (scenes == 1)
        {
            messageText.text = "These are the little ones. Fight them to get armor.";
            textWriter.AddWriter(messageText, "These are the little ones. Fight them to get armor.", 0.05f);
        }
        if (scenes == 2)
        {
            messageText.text = "This is your friend! Try interacting with him and see what happens.";
            textWriter.AddWriter(messageText, "This is your friend! Try interacting with him and see what happens.", 0.05f);
        }
        if (scenes == 3)
        {
            messageText.text = "This is the final boss. Kill him to win the game (?)";
            textWriter.AddWriter(messageText, "This is the final boss. Kill him to win the game (?)", 0.05f);
        }
        if (scenes == 4)
        {
            messageText.text = "Click Click click! figure it out. Good luck on your adventure in the infection game.";
            textWriter.AddWriter(messageText, "Click Click click! figure it out. Good luck on your adventure in the infection game.", 0.05f);
        }
    }
}
