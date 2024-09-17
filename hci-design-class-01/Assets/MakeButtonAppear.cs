using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeButtonAppear : MonoBehaviour
{
    public GameObject textbox;

    private void Start()
    {
        Debug.Log("hello class :)");
    }

    public void TurnButtonOnAndOff()
    {
        if (textbox.activeSelf) textbox.SetActive(false);
        else textbox.SetActive(true);
    }
}
