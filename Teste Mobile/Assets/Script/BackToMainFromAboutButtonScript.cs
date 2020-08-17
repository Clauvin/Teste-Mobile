using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BackToMainFromAboutButtonScript v1.0.0
/// 
/// What it does: takes care of making the Back Button from the About Panel, when clicked,
///     hide the About Panel and show the Main Panel.
///     
/// Also: Since it needs to call functions from mainPanelManagerScript which is in the mainPanelManager object,
///     it loads the manager at the start.
/// </summary>
public class BackToMainFromAboutButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        loadMainPanelManager();
    }

    private void loadMainPanelManager()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    public override void whenPressed()
    {
        if ((mainPanelManagerScript == null) && (mainPanelManager != null)) loadMainPanelManager();
        else if (mainPanelManager == null)
        {
            throw new System.NullReferenceException("BackToMainFromAboutButtonScript.mainPanelManager is null.");
        }

        mainPanelManagerScript.hideAboutPanel();
        mainPanelManagerScript.showMainPanel();
    }

}
