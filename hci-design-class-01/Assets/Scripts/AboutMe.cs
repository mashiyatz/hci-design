using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AboutMe : MonoBehaviour
{
    public string[] messages;
    public TextMeshProUGUI textbox;
    private int messageCounter;

    void Start()
    {

        
    }

    private void OnEnable()
    {
        messageCounter = 0;
        textbox.text = messages[messageCounter];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            messageCounter += 1;
            if (messageCounter >= messages.Length) messageCounter = 0;
            textbox.text = messages[messageCounter];
            Debug.Log(messageCounter);
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            messageCounter -= 1;
            if (messageCounter < 0) messageCounter = messages.Length - 1;
            textbox.text = messages[messageCounter];
            Debug.Log(messageCounter);
        }       
    }
}
