using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ToWrittenFeedbackFromLikertFeedbackButtonScript v1.0.0
/// 
/// What it does: takes care of making the Next Button from the Likert Feedback Panel, when clicked,
///     hide the Likert Feedback Panel and show the Written Feedback Panel.
///     
/// Also: Since it needs to call functions from feedbackPanelManagerScript which is in the feedbackPanelManager object,
///     it loads the manager at the start.
/// </summary>
public class ToWrittenFeedbackFromLikertFeedbackButtonScript : ButtonScript
{
    public GameObject feedbackPanelManager;
    FeedbackPanelManagerScript feedbackPanelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        loadFeedbackPanelManager();
    }

    private void loadFeedbackPanelManager()
    {
        feedbackPanelManagerScript = feedbackPanelManager.GetComponent<FeedbackPanelManagerScript>();
    }

    public override void whenPressed()
    {
        if ((feedbackPanelManagerScript == null) && (feedbackPanelManager != null)) loadFeedbackPanelManager();
        else if (feedbackPanelManager == null)
        {
            throw new System.NullReferenceException("ToWrittenFeedbackFromLikertFeedbackButtonScript.feedbackPanelManager is null.");
        }

        feedbackPanelManagerScript.hideLikertFeedbackPanel();
        feedbackPanelManagerScript.showWrittenFeedbackPanel();
    }

}
