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
    public class LikertFeedbackPanelTestScript
    {
        GameObject main_panel_manager;
        GameObject main_panel;
        GameObject feedback_panel;

        GameObject likert_feedback_panel;

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("AboutPanelTestScript tests starting.");
        }

        [SetUp]
        public void ResetScene()
        {
            TestContext.WriteLine("Setup started");
            GameObject the_main = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/Prefab Main Menu"));
            the_main.name = "Prefab Main Menu";
            TestContext.WriteLine("Setup finished");
        }

        // A Test behaves as an ordinary method
        [Test]
        public void BackButtonWorks()
        {
            Action del = this.BackButtonWorks;
            string ret = del.Method.Name;

            UnityEngine.Object[] list = Resources.FindObjectsOfTypeAll(typeof(GameObject));

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            feedback_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().feedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                fb_script.whenPressed();
                BackToMainFromLikertFeedbackButtonScript bm_script = feedback_panel.transform.GetChild(1).GetChild(1).
                    GetComponent<BackToMainFromLikertFeedbackButtonScript>();
                bm_script.whenPressed();
                Assert.AreEqual(main_panel.activeSelf, true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }

            WriteTestLogScript.TestPassed(ret);
        }

        [Test]
        public void LoadingLikertInfoWorks()
        {
            Action del = this.LoadingLikertInfoWorks;
            string ret = del.Method.Name;

            UnityEngine.Object[] list = Resources.FindObjectsOfTypeAll(typeof(GameObject));

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                fb_script.whenPressed();




                Assert.AreEqual(likert_feedback_panel.activeSelf, true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }

        }

        [Test]
        public void SavingLikertInfoWorks()
        {



        }
    }
}

