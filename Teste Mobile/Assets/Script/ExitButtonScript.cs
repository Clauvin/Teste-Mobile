using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ExitButtonScript v1.0.0
/// 
/// What it does: takes care of the code that closes the program when the Exit Button at the Main Panel is pressed.
/// 
/// Also: since it needs to call functions from mainPanelManagerScript which is in the mainPanelManager object,
///     it loads the manager at the start.
/// 
/// </summary>
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

