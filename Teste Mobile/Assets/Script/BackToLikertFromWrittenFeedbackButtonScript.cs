using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BackToLikertFromWrittenFeedbackButtonScript v1.0.0
/// 
/// What it does: takes care of making the Back Button from the Written Feedback Panel, when clicked,
///     hide the Written Feedback Panel and show the Likert Feedback Panel.
///     
/// Also: Since it needs to call functions from feedbackPanelManagerScript which is in the feedbackPanelManager object,
///     it loads the manager at the start.
/// </summary>
public class BackToLikertFromWrittenFeedbackButtonScript : ButtonScript
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
            throw new System.NullReferenceException("BackToLikertFromWrittenFeedbackButtonScript.feedbackPanelManager is null.");
        }

        feedbackPanelManagerScript.hideWrittenFeedbackPanel();
        feedbackPanelManagerScript.showLikertFeedbackPanel();
    }
}
