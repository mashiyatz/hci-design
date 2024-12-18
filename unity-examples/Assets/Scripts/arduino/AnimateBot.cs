using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBot : MonoBehaviour
{
    public enum CharacterState { STANDING, SITTING }
    private Animator animator;
    private CharacterState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = CharacterState.SITTING;
    }

    void OnMessageArrived(string msg)
    {
        if (msg == "STAND" && currentState == CharacterState.SITTING) Stand();
        else if (msg == "SIT" && currentState == CharacterState.STANDING) Sit();
    }

    void OnConnectionEvent(bool success)
    {
        if (success) Debug.Log("Connection established");
        else Debug.Log("Connection attempt failed or disconnection detected");
    }

    void Stand()
    {
        animator.ResetTrigger("Sit");
        animator.SetTrigger("Stand");
        currentState = CharacterState.STANDING;
    }

    void Sit()
    {
        animator.ResetTrigger("Stand");
        animator.SetTrigger("Sit");
        currentState = CharacterState.SITTING;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentState == CharacterState.SITTING) Stand();
        else if (Input.GetKeyDown(KeyCode.S) && currentState == CharacterState.STANDING) Sit();
           
    }
}
