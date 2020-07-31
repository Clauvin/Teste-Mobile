using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikertSaveFieldScript : SaveFieldScript
{
    void Start()
    {
        value = "3";    
    }

    public void FromLikertToField()
    {
        value = GetComponent<Slider>().value.ToString();
    }
}
