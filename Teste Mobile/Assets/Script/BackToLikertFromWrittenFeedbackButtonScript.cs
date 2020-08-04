using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
