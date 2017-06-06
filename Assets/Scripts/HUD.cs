using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    private void OnEnable()
    {
        //Subscribe to HealthUpdate event
        PlayerHealthAmy.OnHealthUpdated += HandleOnHealthUpdated; ;
    }

    void HandleOnHealthUpdated()
    {
        Debug.Log("HealthUpdated was received");
    }
}
