using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);
        } 
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-1f * movementSpeed * Time.deltaTime * Vector3.forward);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1f * rotationSpeed * Time.deltaTime, 0));
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }

              
    }
}
