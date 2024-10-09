using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    [SerializeField]
    private Light spotlight;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        // Debug.Log(msg);
        if (msg == "OFF")
        {
            spotlight.enabled = false;
        } else if (msg == "ON")
        {
            spotlight.enabled = true;
        } else if (spotlight.enabled)
        {
            if (int.TryParse(msg, out int brightness))
            {
                float adjustedBrightness = Mathf.Lerp(0f, 1f, brightness / 150f);
                if (spotlight.enabled) spotlight.intensity = adjustedBrightness;
            }
        } 
        
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
