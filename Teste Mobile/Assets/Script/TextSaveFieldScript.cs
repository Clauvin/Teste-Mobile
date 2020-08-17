using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSaveFieldScript : SaveFieldScript
{
    // Start is called before the first frame update
    void Start()
    {
        JumpStart();
    }

    public void JumpStart()
    {
        if (SaveManagerScript.data_dictionary == null)
        {
            SaveManagerScript.data_dictionary = new Dictionary<string, string>();
        }

        if (SaveManagerScript.data_dictionary.ContainsKey(name))
        {
            SaveManagerScript.data_dictionary.TryGetValue(name, out value);
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
