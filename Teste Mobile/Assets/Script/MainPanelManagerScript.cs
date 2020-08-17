using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MainPanelManagerScript v1.0.0
/// 
/// What it does: takes care of the buttons and panels involving the main panel through the app.
///     Mainly responsible for the functions that activate and deactivate panels accessed through the main panel.
/// 
/// Also: yes, the show...() and hide...() functions return strings for the sake of good testing, keep those returns as they are.
/// </summary>
public class MainPanelManagerScript : PanelManagerScript
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

    void Start()
    {
        mainPanel.SetActive(true);
        guidelinesPanel.SetActive(false);
        feedbackPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public string loadGuidelinesCheck()
    {
        return "not needed at the moment";
    }

    public string showMainPanel()
    {
        setPanel(mainPanel, true);

        return sendMessageAboutIfTheObjectIsActive(mainPanel, true, result_message_show_main_panel_true,
            result_message_show_main_panel_false);
    }

    public string hideMainPanel()
    {
        setPanel(mainPanel, false);

        return sendMessageAboutIfTheObjectIsActive(mainPanel, false, result_message_hide_main_panel_true,
            result_message_hide_main_panel_false);
    }

    public string showGuidelinesPanel()
    {
        setPanel(guidelinesPanel, true);

        return sendMessageAboutIfTheObjectIsActive(guidelinesPanel, true, result_message_show_guidelines_panel_true,
            result_message_show_guidelines_panel_false);
    }

    public string hideGuidelinesPanel()
    {
        setPanel(guidelinesPanel, false);

        return sendMessageAboutIfTheObjectIsActive(guidelinesPanel, false, result_message_hide_guidelines_panel_true,
            result_message_hide_guidelines_panel_false);
    }

    public string showMainFeedbackPanel()
    {
        setPanel(feedbackPanel, true);

        return sendMessageAboutIfTheObjectIsActive(feedbackPanel, true, result_message_show_feedback_panel_true,
            result_message_show_feedback_panel_false);
    }

    public string hideMainFeedbackPanel()
    {
        setPanel(feedbackPanel, false);

        return sendMessageAboutIfTheObjectIsActive(feedbackPanel, false, result_message_hide_feedback_panel_true,
            result_message_hide_feedback_panel_false);
    }

    public string showAboutPanel()
    {
        setPanel(aboutPanel, true);

        return sendMessageAboutIfTheObjectIsActive(aboutPanel, true, result_message_show_about_panel_true,
            result_message_show_about_panel_false);
    }

    public string hideAboutPanel()
    {
        setPanel(aboutPanel, false);

        return sendMessageAboutIfTheObjectIsActive(aboutPanel, false, result_message_hide_about_panel_true,
            result_message_hide_about_panel_false);
    }

    public void exitProgram()
    {
        Application.Quit();
    }

}