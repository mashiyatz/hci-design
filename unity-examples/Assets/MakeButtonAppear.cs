using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeButtonAppear : MonoBehaviour
{
    public GameObject textbox;

    private void Start()
    {
        Debug.Log("hello class :)");
        Debug.Log("read my announcements");
    }

    public void TurnButtonOnAndOff()
    {
        if (textbox.activeSelf) textbox.SetActive(false);
        else textbox.SetActive(true);
    }
}
