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
    /// <summary>
    /// LikertFeedbackPanelTestScript v1.0.0
    /// 
    /// What it does: takes care of tests involving directly the LikertFeedback Panel, and the buttons and sliders in it.
    /// </summary>
    [TestFixture]
    [Author("Cláuvin", "")]
    public class LikertFeedbackPanelTestScript
    {
        GameObject prefab_main_menu;
        GameObject main_panel;
        GameObject feedback_panel_manager;
        GameObject feedback_panel;

        GameObject likert_feedback_panel;

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("LikertFeedbackPanelTestScript tests starting.");
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
        public void TheBackButtonFromTheLikertFeedbackPanelWorks()
        {
            Action this_test_function = this.TheBackButtonFromTheLikertFeedbackPanelWorks;
            string this_test_function_name = this_test_function.Method.Name;

            main_panel = GameObject.Find("Prefab Main Menu").
                GetComponentInChildren<MainPanelManagerScript>().
                mainPanel;

            likert_feedback_panel = GameObject.Find("Prefab Main Menu").
                GetComponentInChildren<FeedbackPanelManagerScript>().
                likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteOnLogThatTestStarted(this_test_function_name);

                FeedbackButtonScript feedback_button_script = GameObject.Find("Prefab Main Menu").
                    GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.GetComponent<FeedbackButtonScript>();
                feedback_button_script.whenPressed();

                BackToMainFromLikertFeedbackButtonScript back_to_main_script = likert_feedback_panel.
                    transform.Find("Likert Feedback Panel Layout Manager").
                    Find("Back Button").
                    GetComponent<BackToMainFromLikertFeedbackButtonScript>();
                back_to_main_script.whenPressed();

                Assert.AreEqual(main_panel.activeSelf, true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.WriteOnLogThatTestFailed(this_test_function_name);
                Assert.Fail();
                return;
            }

            WriteTestLogScript.WriteOnLogThatTestPassed(this_test_function_name);
        }

        [Test]
        public void LoadingTheLikertDataToTheLikertSlidersWorks()
        {
            Action this_test_function = this.LoadingTheLikertDataToTheLikertSlidersWorks;
            string this_test_function_name = this_test_function.Method.Name;

            prefab_main_menu = GameObject.Find("Prefab Main Menu");

            main_panel = prefab_main_menu.
                GetComponentInChildren<MainPanelManagerScript>().
                mainPanel;

            likert_feedback_panel = prefab_main_menu.
                GetComponentInChildren<FeedbackPanelManagerScript>().
                likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

                FeedbackButtonScript feedback_button_script = prefab_main_menu.
                    GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.
                    GetComponent<FeedbackButtonScript>();
                feedback_button_script.whenPressed();

                GameObject viewport_content = likert_feedback_panel.transform.
                    Find("Likert Feedback Panel Layout Manager").
                    Find("Scroll View").
                    Find("Viewport").Find("Content").gameObject;

                // getting the sliders inside viewport_content
                List<GameObject> sliders = new List<GameObject>();
                int amount_of_sliders = viewport_content.transform.childCount;

                for (int i = 0; i < amount_of_sliders; i++)
                {
                    sliders.Add(viewport_content.transform.GetChild(i).gameObject);
                }

                //setting all of them to 1
                for (int i = 0; i < sliders.Count; i++)
                {
                    sliders[i].transform.Find("Likert Slider").GetComponent<LikertSaveFieldScript>().value = "1";
                    sliders[i].transform.Find("Likert Slider").GetComponent<LikertSaveFieldScript>().FromFieldToLikert();
                }

                BackToMainFromLikertFeedbackButtonScript back_to_main_button = prefab_main_menu.
                    GetComponentInChildren<FeedbackPanelManagerScript>().
                    backToMainButton.GetComponent<BackToMainFromLikertFeedbackButtonScript>();

                back_to_main_button.whenPressed();
                feedback_button_script.whenPressed();

                //checking if all the sliders still have a value equal to 1.
                //  There are ten sliders, so if they all have a value equal to 1, the sum of the values should be 10.
                //  Also, since the minimum value for a slider IS one, any different values will be caught as the
                //  result is bigger than 10.
                int total_value_expected = amount_of_sliders;
                int total_value_found = 0;

                for (int i = 0; i < sliders.Count; i++)
                {
                    total_value_found += int.Parse(sliders[i].transform.Find("Likert Slider").GetComponent<LikertSaveFieldScript>().
                        value);
                }

                Assert.AreEqual(total_value_expected == total_value_found, true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.WriteOnLogThatTestFailed(this_test_function_name);
                Assert.Fail();
                return;
            }

        }

        [Test]
        public void SavingTheDataFromTheLikertSlidersToTheSaveFileWorks()
        {
            //Go to the likert panel
            Action this_test_function = this.SavingTheDataFromTheLikertSlidersToTheSaveFileWorks;
            string this_test_function_name = this_test_function.Method.Name;

            prefab_main_menu = GameObject.Find("Prefab Main Menu");
            main_panel = prefab_main_menu.
                GetComponentInChildren<MainPanelManagerScript>().
                mainPanel;
            likert_feedback_panel = prefab_main_menu.
                GetComponentInChildren<FeedbackPanelManagerScript>().
                likertFeedbackPanel;

            try
            {
                WriteTestLogScript.WriteOnLogThatTestStarted(this_test_function_name);

                FeedbackButtonScript feedback_button_script = prefab_main_menu.
                    GetComponentInChildren<MainPanelManagerScript>().
                    mainFeedbackButton.
                    GetComponent<FeedbackButtonScript>();
                feedback_button_script.whenPressed();

                //yes, the way used to reach the likert sliders viewport needs a refactoring, since
                //  it's a hindrance for future changes at the likert panel prefab
                GameObject viewport_content = likert_feedback_panel.transform.
                    Find("Likert Feedback Panel Layout Manager").
                    Find("Scroll View").
                    Find("Viewport").Find("Content").gameObject;

                //getting all sliders
                List<GameObject> sliders = new List<GameObject>();
                int amount_of_sliders = viewport_content.transform.childCount;

                for (int i = 0; i < amount_of_sliders; i++)
                {
                    sliders.Add(viewport_content.transform.GetChild(i).gameObject);
                }

                //initializing the save system
                SaveManagerScript save_manager = GameObject.Find("Save Manager").GetComponent<SaveManagerScript>();
                if (SaveManagerScript.save_file_address == null) save_manager.InitializingSaveFileAddress();
                SaveManagerScript.data_dictionary = new Dictionary<string, string>();
                SaveManagerScript.list_used_to_save_and_load_stuff = new List<string>();

                //saving info from all sliders
                for (int i = 0; i < sliders.Count; i++)
                {
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().value = "1";
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().FromFieldToLikert();
                    sliders[i].transform.GetChild(0).GetComponent<LikertSaveFieldScript>().SendDataToSaveManager();
                }

                save_manager.FromDictionaryDataToSaveFile();

                StreamReader reader = new StreamReader(SaveManagerScript.save_file_address);
                List<string> list_of_saved_data = new List<string>();

                bool likert_values_were_correctly_saved = true;

                //reading saved info
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    list_of_saved_data.Add(line);
                }
                reader.Close();

                //checking if the saved info is correct
                foreach (string key_value in list_of_saved_data)
                {
                    string[] key_and_value_separated = key_value.Split(new char[] { '|' });
                    if (key_and_value_separated[0].Contains("Question"))
                    {
                        if (key_and_value_separated[1].CompareTo("1") != 0)
                        {
                            likert_values_were_correctly_saved = false;
                        }
                    }
                }

                Assert.IsTrue(likert_values_were_correctly_saved);

                //Save the info
                //Check if the info has been properly saved.

            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.WriteOnLogThatTestFailed(this_test_function_name);
                Assert.Fail();
                return;
            }
        }
    }
}

