using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// LikertSaveFieldScript v1.0.0
/// 
/// What it does: takes care of getting data from the SaveManager data_dictionary and passing to a
///     LikertField at the LikertFeedbackPanel.
/// </summary>
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
