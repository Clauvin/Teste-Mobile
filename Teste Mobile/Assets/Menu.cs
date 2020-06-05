using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using System.Collections;

public class Menu : MonoBehaviour
{

    public Button start;
    public Button form;
    public Button help;
    public Button exit;
    public Button back;
    public Button yes;
    public Button no;

    public GameObject formPanel;
    public GameObject helpPanel;
    public GameObject exitPanel;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        formPanel.SetActive(false);
        helpPanel.SetActive(false);
        exitPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    // Function for Start Button, loads Main Scene 
    public void StartPress()
    {
        Debug.Log("ops");
        SceneManager.LoadScene(1);
    }

    public void FormPress()
    {
        formPanel.SetActive(true);

    }

    // Function for Help Button, enables Help Panel
    public void HelpPress()
    {
        helpPanel.SetActive(true);
    }

    // Function for Exit Button, exits the application
    public void ExitPress()
    {
        exitPanel.SetActive(true);
    }

    // Function for Back Button, disables Help Panel
    public void BackPress()
    {
        helpPanel.SetActive(false);
    }

    public void YesPress()
    {
        //System.Diagnostics.Process.GetCurrentProcess().Kill();
        Application.Quit();
    }
    public void NoPress()
    {
        Debug.Log("ei não");
        exitPanel.SetActive(false);
    }
}