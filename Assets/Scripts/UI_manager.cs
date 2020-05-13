using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour {

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
            messageText.text = "There has been a disturbance in time, by a mysterious man nicknamed Morbus. Morbus has traveled back in time with one of our time machines and he has also taken a biological weapon called ZOID-73 with him.";
            textWriter.AddWriter(messageText, "There has been a disturbance in time, by a mysterious man nicknamed Morbus. Morbus has traveled back in time with one of our time machines and he has also taken a biological weapon called ZOID-73 with him.", 0.05f);
        }
        if (scenes == 1)
        {
            messageText.text = "ZOID-73 as you know was an infectious disease that turns organisms into mindless aggressors."; 
            textWriter.AddWriter(messageText, "ZOID-73 as you know was an infectious disease that turns organisms into mindless aggressors.", 0.05f);
        }
        if (scenes == 2)
        {
            messageText.text = "Since there are only two time machines, and Morbus took one, you have been tasked with dealing with Morbus.";
            textWriter.AddWriter(messageText, " Since there are only two time machines, and Morbus took one, you have been tasked with dealing with Morbus.", 0.05f);
        }
        if (scenes == 3)
        {
            messageText.text = "We have helped you track down Morbus’ timeline, but It’s up to you to stop him.";
            textWriter.AddWriter(messageText, "We have helped you track down Morbus’ timeline, but It’s up to you to stop him.", 0.05f);
        }
        if (scenes == 4)
        {
            messageText.text = "We have packed some items with you, but you are on your own. Good Luck Agent Epsilon.";
            textWriter.AddWriter(messageText, "We have packed some items with you, but you are on your own. Good Luck Agent Epsilon.", 0.05f);
        }
    }
}
