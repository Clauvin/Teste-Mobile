using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    public AboutButtonScript() { }

    // Start is called before the first frame update
    void Start()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void whenPressed()
    {
        mainPanelManagerScript.hideMainPanel();
        mainPanelManagerScript.showAboutPanel();
    }
}
