using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        GameObject feedback_panel_manager;
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

            main_panel = GameObject.Find("Prefab Main Menu").GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            feedback_panel = GameObject.Find("Prefab Main Menu").
                GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                FeedbackButtonScript fb_script = GameObject.Find("Prefab Main Menu").GetComponentInChildren<MainPanelManagerScript>().
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

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                fb_script.whenPressed();

                GameObject viewport_content = likert_feedback_panel.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).
                    gameObject;

                List<GameObject> sliders = new List<GameObject>();
                int amount_of_sliders = viewport_content.transform.childCount;

                for (int i = 0; i < amount_of_sliders; i++)
                {
                    sliders.Add(viewport_content.transform.GetChild(i).gameObject);
                }

                for (int i = 0; i < sliders.Count; i++)
                {
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().value = "1";
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().FromFieldToLikert();
                }

                BackToMainFromLikertFeedbackButtonScript back_button = main_panel_manager.
                    GetComponentInChildren<FeedbackPanelManagerScript>().
                    backToMainButton.GetComponent<BackToMainFromLikertFeedbackButtonScript>();

                back_button.whenPressed();
                fb_script.whenPressed();

                int total_value_expected = amount_of_sliders;
                int total_value_found = 0;

                for (int i = 0; i < sliders.Count; i++)
                {
                    total_value_found += int.Parse(sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().
                        value);
                }

                Assert.AreEqual(total_value_expected == total_value_found, true);
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
            //Go to the likert panel
            Action del = this.SavingLikertInfoWorks;
            string ret = del.Method.Name;

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");

                FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                fb_script.whenPressed();

                GameObject viewport_content = likert_feedback_panel.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).
                    gameObject;

                List<GameObject> sliders = new List<GameObject>();
                int amount_of_sliders = viewport_content.transform.childCount;

                for (int i = 0; i < amount_of_sliders; i++)
                {
                    sliders.Add(viewport_content.transform.GetChild(i).gameObject);
                }

                SaveManagerScript save_manager = GameObject.Find("Save Manager").GetComponent<SaveManagerScript>();
                if (SaveManagerScript.save_file_address == null) save_manager.InitializingSaveFileAddress();
                SaveManagerScript.save_data = new Dictionary<string, string>();
                SaveManagerScript.to_save_and_load = new List<string>();

                for (int i = 0; i < sliders.Count; i++)
                {
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().value = "1";
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().FromFieldToLikert();
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().SendDataToSaveManager();
                }

                save_manager.FromDictionaryToSave();

                StreamReader reader = new StreamReader(SaveManagerScript.save_file_address);
                List<string> a_list = new List<string>();

                bool likert_values_were_correctly_saved = true;

                Debug.Log(SaveManagerScript.save_file_address);

                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    a_list.Add(line);
                    Debug.Log(line);
                }
                reader.Close();

                foreach (string key_value in a_list)
                {
                    string[] key_and_value_separated = key_value.Split(new char[] { '|' });
                    if (key_and_value_separated[0].Contains("Question"))
                    {
                        if (key_and_value_separated[1].CompareTo("1") != 0)
                        {
                            likert_values_were_correctly_saved = true;
                        }
                    }
                }

                Assert.IsTrue(likert_values_were_correctly_saved);

                //Save the info
                //Check if the info has been properly saved.

            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }
        }
    }
}

