using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GuidelinesButtonScript v1.0.0
/// 
/// What it does: takes care of making the Guidelines Button, when clicked, hide the Main Panel and show the Guidelines Panel.
/// 
/// Also: Since it needs to call functions from mainPanelManagerScript which is in the mainPanelManager object,
///     it loads the manager at the start.
/// </summary>
public class GuidelinesButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    MainPanelManagerScript mainPanelManagerScript;

    public GuidelinesButtonScript() { }

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
            throw new System.NullReferenceException("GuidelinesButtonScript.mainPanelManager is null.");
        }

        mainPanelManagerScript.hideMainPanel();
        mainPanelManagerScript.showGuidelinesPanel();
    }
}
