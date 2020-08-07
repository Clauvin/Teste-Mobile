using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    [Author("Cláuvin", "")]
    public class WrittenFeedbackPanelTestScript
    {
        GameObject main_panel_manager;
        GameObject main_panel;

        GameObject feedback_panel_manager;
        GameObject likert_feedback_panel;
        GameObject written_feedback_panel;

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("WrittenFeedbackPanelTestScript tests starting.");
        }

        [SetUp]
        public void ResetScene()
        {
            TestContext.WriteLine("Setup started");
            GameObject the_main = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/Prefab Main Menu"));
            the_main.name = "Prefab Main Menu";
            TestContext.WriteLine("Setup finished");
        }

        [Test]
        public void BackButtonWorks()
        {
            Action del = this.BackButtonWorks;
            string ret = del.Method.Name;

            UnityEngine.Object[] list = Resources.FindObjectsOfTypeAll(typeof(GameObject));

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;
            written_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().writtenFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                fb_script.whenPressed();
                ToWrittenFeedbackFromLikertFeedbackButtonScript wf_lf_script = likert_feedback_panel.transform.GetChild(1).GetChild(2).
                    GetComponent<ToWrittenFeedbackFromLikertFeedbackButtonScript>();
                wf_lf_script.whenPressed();
                BackToLikertFromWrittenFeedbackButtonScript bl_wf_script = written_feedback_panel.transform.GetChild(1).GetChild(4).
                    GetComponent<BackToLikertFromWrittenFeedbackButtonScript>();
                bl_wf_script.whenPressed();
                Assert.AreEqual(likert_feedback_panel.activeSelf, true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }

            WriteTestLogScript.TestPassed(ret);
        }

        //Test 1: back button.
        //Test 2: loading info.
        //Test 3: saving info.
        //Test 4: loading and saving info to Likert. (the other chat)
        //Test 5: Writing name and info works.
    }

}
