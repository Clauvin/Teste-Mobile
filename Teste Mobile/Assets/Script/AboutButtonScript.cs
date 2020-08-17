﻿using System.Collections;
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

    private void loadMainPanelManager()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    override public void whenPressed()
    {
        if ((mainPanelManagerScript == null) && (mainPanelManager != null)) loadMainPanelManager();
        else if (mainPanelManager == null)
        {
            throw new System.NullReferenceException("AboutButtonScript.mainPanelManager is null.");
        }

        mainPanelManagerScript.hideMainPanel();
        mainPanelManagerScript.showAboutPanel();
    }

}
