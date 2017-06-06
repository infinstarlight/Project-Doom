using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMessageTarget : MonoBehaviour, ICustomMessageTarget
{
    public void Message1()
    {
        Debug.Log("Message 1 received");
    }

    public void Message2()
    {
        Debug.Log("Message 2 received");
    }
}
