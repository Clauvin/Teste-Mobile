using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagerScript : MonoBehaviour
{
    protected void setPanel(GameObject panel, bool true_or_false)
    {
        panel.SetActive(true_or_false);
    }

    protected string sendMessageAboutIfTheObjectIsActive(GameObject the_object, bool if_equal_this,
        string then_text, string else_text)
    {
        if (the_object.activeSelf == if_equal_this) return then_text;
        else return else_text;
    }


}
