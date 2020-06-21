using UnityEngine;
using UnityEngine.UI;

public class MainPanelManagerScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject guidelinesPanel;
    public GameObject feedbackPanel;
    public GameObject aboutPanel;

    public Button guidelinesButton;
    public Button mainFeedbackButton;
    public Button aboutButton;
    public Button exitButton;

    public const string result_message_show_main_panel_true = "showMainPanel true";
    public const string result_message_show_main_panel_false = "showMainPanel false";
    public const string result_message_hide_main_panel_true = "hideMainPanel true";
    public const string result_message_hide_main_panel_false = "hideMainPanel false";
    public const string result_message_show_guidelines_panel_true = "showGuidelinesPanel true";
    public const string result_message_show_guidelines_panel_false = "showGuidelinesPanel false";
    public const string result_message_hide_guidelines_panel_true = "hideGuidelinesPanel true";
    public const string result_message_hide_guidelines_panel_false = "hideGuidelinesPanel false";
    public const string result_message_show_feedback_panel_true = "showFeedbackPanel true";
    public const string result_message_show_feedback_panel_false = "showFeedbackPanel false";
    public const string result_message_hide_feedback_panel_true = "hideFeedbackPanel true";
    public const string result_message_hide_feedback_panel_false = "hideFeedbackPanel false";
    public const string result_message_show_about_panel_true = "showAboutPanel true";
    public const string result_message_show_about_panel_false = "showAboutPanel false";
    public const string result_message_hide_about_panel_true = "hideAboutPanel true";
    public const string result_message_hide_about_panel_false = "hideAboutPanel false";

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        mainPanel.SetActive(true);
        guidelinesPanel.SetActive(false);
        feedbackPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public string loadGuidelinesCheck()
    {
        return "todo";
    }

    public string showMainPanel()
    {
        setPanel(mainPanel, true);

        return sendMessageAboutActive(mainPanel, true, result_message_show_main_panel_true,
            result_message_show_main_panel_false);
    }

    public string hideMainPanel()
    {
        setPanel(mainPanel, false);

        return sendMessageAboutActive(mainPanel, false, result_message_hide_main_panel_true,
            result_message_hide_main_panel_false);
    }

    public string showGuidelinesPanel()
    {
        setPanel(guidelinesPanel, true);

        return sendMessageAboutActive(guidelinesPanel, true, result_message_show_guidelines_panel_true,
            result_message_show_guidelines_panel_false);
    }

    public string hideGuidelinesPanel()
    {
        setPanel(guidelinesPanel, false);

        return sendMessageAboutActive(guidelinesPanel, false, result_message_hide_guidelines_panel_true,
            result_message_hide_guidelines_panel_false);
    }

    public string showMainFeedbackPanel()
    {
        setPanel(feedbackPanel, true);

        return sendMessageAboutActive(feedbackPanel, true, result_message_show_feedback_panel_true,
            result_message_show_feedback_panel_false);
    }

    public string hideMainFeedbackPanel()
    {
        setPanel(feedbackPanel, false);

        return sendMessageAboutActive(feedbackPanel, false, result_message_hide_feedback_panel_true,
            result_message_hide_feedback_panel_false);
    }

    public string showAboutPanel()
    {
        setPanel(aboutPanel, true);

        return sendMessageAboutActive(aboutPanel, true, result_message_show_about_panel_true,
            result_message_show_about_panel_false);
    }

    public string hideAboutPanel()
    {
        setPanel(aboutPanel, false);

        return sendMessageAboutActive(aboutPanel, false, result_message_hide_about_panel_true,
            result_message_hide_about_panel_false);
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