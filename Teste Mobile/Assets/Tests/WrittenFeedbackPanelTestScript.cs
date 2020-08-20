using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    /// <summary>
    /// WrittenFeedbackPanelTestScript v1.0.0
    /// 
    /// What it does: takes care of tests involving directly the WrittenFeedback Panel, and the buttons and sliders in it.
    /// </summary>
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
        public void TheBackButtonFromTheWrittenFeedbackPanelWorks()
        {
            Action del = this.TheBackButtonFromTheWrittenFeedbackPanelWorks;
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
                BackToLikertFromWrittenFeedbackButtonScript bl_wf_script = written_feedback_panel.transform.GetChild(1).GetChild(5).
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

        [Test]
        public void SavingWrittenTestWorks()
        {
            Action del = this.SavingWrittenTestWorks;
            string ret = del.Method.Name;

            UnityEngine.Object[] list = Resources.FindObjectsOfTypeAll(typeof(GameObject));

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;
            written_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().writtenFeedbackPanel;

            WriteTestLogScript.WriteString("Starting " + ret + " test.");

            FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                mainFeedbackButton.GetComponent<FeedbackButtonScript>();
            fb_script.whenPressed();

            GameObject name_input_field = written_feedback_panel.transform.GetChild(1).GetChild(1).gameObject;
            GameObject considerations_input_field = written_feedback_panel.transform.GetChild(1).GetChild(3).gameObject;

            SaveManagerScript save_manager = GameObject.Find("Save Manager").GetComponent<SaveManagerScript>();

            // Go to Written Feedback

            ToWrittenFeedbackFromLikertFeedbackButtonScript wf_lf_script = likert_feedback_panel.transform.
                    GetChild(1).GetChild(2).
                    GetComponent<ToWrittenFeedbackFromLikertFeedbackButtonScript>();
            wf_lf_script.whenPressed();

            try
            {
                // Write into Written Feedback
                if (SaveManagerScript.save_file_address == null) save_manager.InitializingSaveFileAddress();
                SaveManagerScript.data_dictionary = new Dictionary<string, string>();
                SaveManagerScript.list_used_to_save_and_load_stuff = new List<string>();

                string message_to_save_for_this_test = "Message for test of unit testing";

                name_input_field.GetComponent<InputField>().text = message_to_save_for_this_test;

                considerations_input_field.GetComponent<InputField>().text = message_to_save_for_this_test;

                save_manager.FromDictionaryDataToSaveFile();

                // Save what was written in Written Feedback
                name_input_field.GetComponent<TextSaveFieldScript>().FromTextToValue();
                name_input_field.GetComponent<TextSaveFieldScript>().SendDataToSaveManager();
                considerations_input_field.GetComponent<TextSaveFieldScript>().FromTextToValue();
                considerations_input_field.GetComponent<TextSaveFieldScript>().SendDataToSaveManager();

                save_manager.FromDictionaryDataToSaveFile();

                // Check if what was written was saved

                StreamReader reader = new StreamReader(SaveManagerScript.save_file_address);
                List<string> a_list = new List<string>();

                bool name_was_correctly_saved = false;
                bool considerations_was_correctly_saved = false;

                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    a_list.Add(line);
                }
                reader.Close();



                foreach (string key_value in a_list)
                {
                    string[] key_and_value_separated = key_value.Split(new char[] { '|' });
                    if (key_and_value_separated[0] == "Name")
                    {
                        if (key_and_value_separated[1] == message_to_save_for_this_test)
                        {
                            name_was_correctly_saved = true;
                        }
                    }

                    if (key_and_value_separated[0] == "Considerations")
                    {
                        if (key_and_value_separated[1] == message_to_save_for_this_test)
                        {
                            considerations_was_correctly_saved = true;
                        }
                    }
                }

                Assert.IsTrue(name_was_correctly_saved && considerations_was_correctly_saved);

            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }
        }


        [Test]
        public void LoadingWrittenInfoWorks()
        {
            Action del = this.LoadingWrittenInfoWorks;
            string ret = del.Method.Name;

            UnityEngine.Object[] list = Resources.FindObjectsOfTypeAll(typeof(GameObject));

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            likert_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().likertFeedbackPanel;
            written_feedback_panel = main_panel_manager.GetComponentInChildren<FeedbackPanelManagerScript>().writtenFeedbackPanel;

            WriteTestLogScript.WriteString("Starting " + ret + " test.");

            FeedbackButtonScript fb_script = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().
                mainFeedbackButton.GetComponent<FeedbackButtonScript>();
            fb_script.whenPressed();

            GameObject name_input_field = written_feedback_panel.transform.GetChild(1).GetChild(1).gameObject;
            GameObject considerations_input_field = written_feedback_panel.transform.GetChild(1).GetChild(3).gameObject;

            SaveManagerScript save_manager = GameObject.Find("Save Manager").GetComponent<SaveManagerScript>();

            try
            {
                if (SaveManagerScript.save_file_address == null) save_manager.InitializingSaveFileAddress();

                StreamWriter writer = new StreamWriter(SaveManagerScript.save_file_address, true);

                writer.WriteLine("Name|A");
                writer.WriteLine("Considerations|A");

                writer.Close();

                save_manager.FromSaveFileToDataDictionary();
                SaveManagerScript.EraseSaveFile();
                SaveManagerScript.list_used_to_save_and_load_stuff.Clear();

                ToWrittenFeedbackFromLikertFeedbackButtonScript wf_lf_script = likert_feedback_panel.transform.
                    GetChild(1).GetChild(2).
                    GetComponent<ToWrittenFeedbackFromLikertFeedbackButtonScript>();
                wf_lf_script.whenPressed();

                name_input_field.GetComponent<TextSaveFieldScript>().JumpStart();
                name_input_field.GetComponent<TextSaveFieldScript>().FromValueToText();
                string name = name_input_field.GetComponent<InputField>().text;

                considerations_input_field.GetComponent<TextSaveFieldScript>().JumpStart();
                considerations_input_field.GetComponent<TextSaveFieldScript>().FromValueToText();
                string considerations = considerations_input_field.GetComponent<InputField>().text;

                string name_in_file;
                SaveManagerScript.data_dictionary.TryGetValue(name_input_field.GetComponent<SaveFieldScript>().name, out name_in_file);

                string considerations_in_file;
                SaveManagerScript.data_dictionary.TryGetValue(considerations_input_field.GetComponent<SaveFieldScript>().name,
                    out considerations_in_file);

                bool name_comparison = name_in_file.CompareTo(name) == 0;
                bool considerations_comparison = considerations_in_file.CompareTo(considerations) == 0;

                Assert.AreEqual(name_comparison && considerations_comparison, true);
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
        public void SendingMailWorks()
        {
            Action del = this.SendingMailWorks;
            string ret = del.Method.Name;

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
                GameObject send_button = written_feedback_panel.transform.GetChild(1).GetChild(4).gameObject;

                SaveManagerScript.data_dictionary = new Dictionary<string, string>();

                SendingFeedbackScript sending_feedback_script = send_button.GetComponent<SendingFeedbackScript>();

                sending_feedback_script.SendingFeedback();

                bool good_message = false;

                GameObject name_input_field = written_feedback_panel.transform.GetChild(1).GetChild(1).gameObject;
                GameObject considerations_input_field = written_feedback_panel.transform.GetChild(1).GetChild(3).gameObject;

                bool good_title_message_appeared = name_input_field.GetComponent<InputField>().text.
                    CompareTo(SendingFeedbackScript.good_title_message) == 0;

                bool good_body_message_appeared = considerations_input_field.GetComponent<InputField>().text.
                    CompareTo(SendingFeedbackScript.good_body_message) == 0;

                if ((good_title_message_appeared) && (good_body_message_appeared))
                {
                    good_message = true;
                }

                Assert.AreEqual(good_message, true);

            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }

        }

        [OneTimeTearDown]
        public void Avoiding()
        {
            TestContext.WriteLine("Erasing save file");
            if (File.Exists(SaveManagerScript.save_file_address)) File.Delete(SaveManagerScript.save_file_address);
            TestContext.WriteLine("Save file erased");
        }
    }
}
