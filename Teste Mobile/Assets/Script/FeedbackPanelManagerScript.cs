using UnityEngine;
using UnityEngine.UI;

public class FeedbackPanelManagerScript : PanelManagerScript
{
    public GameObject likertFeedbackPanel;
    public GameObject writtenFeedbackPanel;

    public Button backToMainButton;
    public Button nextToWrittenFeedbackButton;
    public Button backToLikertFeedbackPanelButton;
    public Button backToWrittenFeedbackButton;
    public Button sendButton;

    public const string result_message_show_likert_feedback_panel_true = "showLikertFeedbackPanel true";
    public const string result_message_show_likert_feedback_panel_false = "showLikertFeedbackPanel false";

    public const string result_message_hide_likert_feedback_panel_true = "hideLikertFeedbackPanel true";
    public const string result_message_hide_likert_feedback_panel_false = "hideLikertFeedbackPanel false";

    public const string result_message_show_written_feedback_panel_true = "showWrittenFeedbackPanel true";
    public const string result_message_show_written_feedback_panel_false = "showWrittenFeedbackPanel false";

    public const string result_message_hide_written_feedback_panel_true = "hideWrittenFeedbackPanel true";
    public const string result_message_hide_written_feedback_panel_false = "hideWrittenFeedbackPanel false";

    public const string result_message_show_send_feedback_panel_true = "showSendFeedbackPanel true";
    public const string result_message_show_send_feedback_panel_false = "showSendFeedbackPanel false";

    public const string result_message_hide_send_feedback_panel_true = "hideSendFeedbackPanel true";
    public const string result_message_hide_send_feedback_panel_false = "hideSendFeedbackPanel false";

    void Start()
    {
        likertFeedbackPanel.SetActive(false);
        writtenFeedbackPanel.SetActive(false);
    }

    public string showLikertFeedbackPanel()
    {
        setPanel(likertFeedbackPanel, true);

        return sendMessageAboutIfTheObjectIsActive(likertFeedbackPanel, true, result_message_show_likert_feedback_panel_true,
            result_message_show_likert_feedback_panel_false);
    }

    public string hideLikertFeedbackPanel()
    {
        setPanel(likertFeedbackPanel, false);

        return sendMessageAboutIfTheObjectIsActive(likertFeedbackPanel, false, result_message_hide_likert_feedback_panel_true,
            result_message_hide_likert_feedback_panel_false);
    }

    public string showWrittenFeedbackPanel()
    {
        setPanel(writtenFeedbackPanel, true);

        return sendMessageAboutIfTheObjectIsActive(writtenFeedbackPanel, true, result_message_show_written_feedback_panel_true,
            result_message_show_written_feedback_panel_false);
    }

    public string hideWrittenFeedbackPanel()
    {
        setPanel(writtenFeedbackPanel, false);

        return sendMessageAboutIfTheObjectIsActive(writtenFeedbackPanel, false, result_message_hide_written_feedback_panel_true,
            result_message_hide_written_feedback_panel_false);
    }
    
    private void setPanel(GameObject panel, bool true_or_false)
    {
        panel.SetActive(true_or_false);
    }


    
}