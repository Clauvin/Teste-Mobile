using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikertSaveFieldScript : SaveFieldScript
{
    void Start()
    {
        if (SaveManagerScript.data_dictionary.ContainsKey(name))
        {
            SaveManagerScript.data_dictionary.TryGetValue(name, out value);
        }
        else
        {
            value = "3";
        }

        FromFieldToLikert();
        
    }

    public void FromFieldToLikert()
    {
        GetComponent<Slider>().value = float.Parse(this.value);
    }

    public void FromLikertToField()
    {
        value = GetComponent<Slider>().value.ToString();
    }
}
