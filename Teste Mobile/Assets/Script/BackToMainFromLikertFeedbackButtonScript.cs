using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainFromLikertFeedbackButtonScript : ButtonScript
{
    public GameObject mainPanelManager;
    public GameObject feedbackPanelManager;
    MainPanelManagerScript mainPanelManagerScript;
    FeedbackPanelManagerScript feedbackPanelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        loadMainPanelManager();
        loadFeedbackPanelManager();
    }

    private void loadMainPanelManager()
    {
        mainPanelManagerScript = mainPanelManager.GetComponent<MainPanelManagerScript>();
    }

    private void loadFeedbackPanelManager()
    {
        feedbackPanelManagerScript = feedbackPanelManager.GetComponent<FeedbackPanelManagerScript>();
    }

    public override void whenPressed()
    {
        if ((mainPanelManagerScript == null) && (mainPanelManager != null)) loadMainPanelManager();
        else if (mainPanelManager == null)
        {
            throw new System.NullReferenceException("BackToMainFromLikertFeedbackButtonScript.mainPanelManager is null.");
        }

        if ((feedbackPanelManagerScript == null) && (feedbackPanelManager != null)) loadFeedbackPanelManager();
        else if (feedbackPanelManager == null)
        {
            throw new System.NullReferenceException("BackToMainFromLikertFeedbackButtonScript.feedbackPanelManager is null.");
        }

        feedbackPanelManagerScript.hideLikertFeedbackPanel();
        mainPanelManagerScript.showMainPanel();
    }

}

