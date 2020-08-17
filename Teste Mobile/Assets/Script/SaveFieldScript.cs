using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SaveFieldScript v1.0.0
/// 
/// What it does: parent class of all other SaveField classes.
///     Mainly responsible for sending data to the save manager.
/// 
/// Also: yeah, I also though that the paragraph above is redundant.
/// </summary>
public class SaveFieldScript : MonoBehaviour
{
    public string name;
    public string value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SendDataToSaveManager()
    {
        SaveManagerScript.AddDataToDictionary(name, value);
    }
}
