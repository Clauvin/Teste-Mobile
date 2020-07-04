using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainFromAboutButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    public override void whenPressed()
    {
        mainPanelManagerScript.hideAboutPanel();
        mainPanelManagerScript.showMainPanel();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
