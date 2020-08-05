using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSaveFieldScript : SaveFieldScript
{
    // Start is called before the first frame update
    void Start()
    {
        if (SaveManagerScript.save_data.ContainsKey(name))
        {
            SaveManagerScript.save_data.TryGetValue(name, out value);
        }
        else
        {
            value = "";
        }

        FromValueToText();
    }

    public void FromValueToText()
    {
        GetComponent<InputField>().text = value;
    }

    public void FromTextToValue()
    {
        value = GetComponent<InputField>().text;
    }
}
