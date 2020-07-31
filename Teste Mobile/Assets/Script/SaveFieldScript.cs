using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFieldScript : MonoBehaviour
{
    public string name = "";
    public string value = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SendDataToSaveManager()
    {
        SaveManagerScript.AddData(name, value);
    }
}
