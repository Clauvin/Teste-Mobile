using UnityEngine;
using UnityEngine.UI;

public class FeedbackPanelManagerScript : MonoBehaviour
{
    public GameObject likertFeedbackPanel;
    public GameObject writtenFeedbackPanel;
    public GameObject sendFeedbackPanel;

    public Button backToMainButton;
    public Button nextToWrittenFeedbackButton;
    public Button backToLikertFeedbackPanel;
    public Button nextToSendFeedbackPanel;
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

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        likertFeedbackPanel.SetActive(false);
        writtenFeedbackPanel.SetActive(false);
        sendFeedbackPanel.SetActive(false);
    }

    public string showLikertFeedbackPanel()
    {
        setPanel(likertFeedbackPanel, true);

        return sendMessageAboutActive(likertFeedbackPanel, true, result_message_show_likert_feedback_panel_true,
            result_message_show_likert_feedback_panel_false);
    }

    public string hideLikertFeedbackPanel()
    {
        setPanel(likertFeedbackPanel, false);

        return sendMessageAboutActive(likertFeedbackPanel, false, result_message_hide_likert_feedback_panel_true,
            result_message_hide_likert_feedback_panel_false);
    }

    public string showWrittenFeedbackPanel()
    {
        setPanel(writtenFeedbackPanel, true);

        return sendMessageAboutActive(writtenFeedbackPanel, true, result_message_show_written_feedback_panel_true,
            result_message_show_written_feedback_panel_false);
    }

    public string hideWrittenFeedbackPanel()
    {
        setPanel(writtenFeedbackPanel, false);

        return sendMessageAboutActive(writtenFeedbackPanel, false, result_message_hide_written_feedback_panel_true,
            result_message_hide_written_feedback_panel_false);
    }

    public string showSendFeedbackPanel()
    {
        setPanel(sendFeedbackPanel, true);

        return sendMessageAboutActive(sendFeedbackPanel, true, result_message_show_send_feedback_panel_true,
            result_message_show_send_feedback_panel_false);
    }

    public string hideMainFeedbackPanel()
    {
        setPanel(sendFeedbackPanel, false);

        return sendMessageAboutActive(sendFeedbackPanel, false, result_message_hide_send_feedback_panel_true,
            result_message_hide_send_feedback_panel_false);
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
    
}