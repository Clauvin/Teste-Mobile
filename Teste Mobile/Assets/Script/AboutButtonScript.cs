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
        loadMainPanelManager();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void whenPressed()
    {
        if ((mainPanelManagerScript == null) && (mainPanelManager != null)) loadMainPanelManager(); 

        mainPanelManagerScript.hideMainPanel();
        mainPanelManagerScript.showAboutPanel();
    }

    private void loadMainPanelManager()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }
}
