using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
