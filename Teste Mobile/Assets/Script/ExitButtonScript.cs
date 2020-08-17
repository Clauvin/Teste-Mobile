﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    public ExitButtonScript() { }

    // Start is called before the first frame update
    void Start()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    override public void whenPressed()
    {
        mainPanelManagerScript.exitProgram();
    }
}

