using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using System.Collections;

public class MainPanelManagerScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject guidelinesPanel;
    public GameObject feedbackPanel;
    public GameObject aboutPanel;
    public GameObject languagePanel;

    public Button guidelinesButton;
    public Button mainFeedbackButton;
    public Button aboutButton;
    public Button exitButton;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        /*formPanel.SetActive(false);
        helpPanel.SetActive(false);
        exitPanel.SetActive(false);*/
    }

    public string loadGuidelinesCheck()
    {
        return "todo";
    }

    public string showMainPanel()
    {
        setPanel(mainPanel, true);

        return sendMessageAboutActive(mainPanel, true, "showMainPanel true", "showMainPanel false");
    }

    public string hideMainPanel()
    {
        setPanel(mainPanel, false);

        return sendMessageAboutActive(mainPanel, false, "hideMainPanel true", "hideMainPanel false");
    }

    public string showGuidelinesPanel()
    {
        setPanel(guidelinesPanel, true);

        return sendMessageAboutActive(guidelinesPanel, true, "showGuidelinesPanel true", "showGuidelinesPanel false");
    }

    public string hideGuidelinesPanel()
    {
        setPanel(guidelinesPanel, false);

        return sendMessageAboutActive(guidelinesPanel, false, "hideGuidelinesPanel true", "hideGuidelinesPanel false");
    }

    public string showMainFeedbackPanel()
    {
        setPanel(feedbackPanel, true);

        return sendMessageAboutActive(feedbackPanel, true, "showMainFeedbackPanel true", "showMainFeedbackPanel false");
    }

    public string hideMainFeedbackPanel()
    {
        setPanel(feedbackPanel, false);

        return sendMessageAboutActive(feedbackPanel, false, "hideMainFeedbackPanel true", "hideMainFeedbackPanel false");
    }

    public string showAboutPanel()
    {
        setPanel(aboutPanel, true);

        return sendMessageAboutActive(aboutPanel, true, "showAboutPanel true", "showAboutPanel false");
    }

    public string hideAboutPanel()
    {
        setPanel(aboutPanel, false);

        return sendMessageAboutActive(aboutPanel, false, "hideAboutPanel true", "showAboutPanel false");
    }

    private void setPanel(GameObject panel, bool true_or_false)
    {
        panel.SetActive(true_or_false);
    }

    private string sendMessageAboutActive(GameObject oobject, bool if_equal_this, string then_text, string else_text)
    {
        if (oobject.activeSelf == if_equal_this) return then_text;
        else return else_text;
    }

    public void exitProgram()
    {
        Application.Quit();
    }


}