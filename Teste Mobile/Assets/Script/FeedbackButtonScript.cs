﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FeedbackButtonScript v1.0.0
/// 
/// What it does: takes care of the code that makes the About Button, when clicked, hide the Main Panel and show the Feedback Panel.
/// 
/// Also: since it needs to call functions from mainPanelManagerScript which is in the mainPanelManager object,
///     it loads the manager at the start.
/// 
/// </summary>
public class FeedbackButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    public FeedbackButtonScript() { }

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
            throw new System.NullReferenceException("FeedbackButtonScript.mainPanelManager is null.");
        }

        mainPanelManagerScript.hideMainPanel();
        mainPanelManagerScript.showMainFeedbackPanel();
    }
}
