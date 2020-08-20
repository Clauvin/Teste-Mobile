using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    /// <summary>
    /// AboutPanelTestScript v1.0.1
    /// 
    /// What it does: takes care of tests involving directly the About Panel buttons, and the About Panel itself.
    /// 
    /// </summary>
    [TestFixture]
    [Author("Cláuvin", "")]
    public class AboutPanelTestScript
    {
        GameObject main_panel_manager;
        GameObject main_panel;
        GameObject about_panel;

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

        [Test]
        public void TheBackButtonFromTheAboutPanelWorks()
        {
            Action del = this.TheBackButtonFromTheAboutPanelWorks;
            string ret = del.Method.Name;

            main_panel_manager = GameObject.Find("Prefab Main Menu");
            main_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().mainPanel;
            about_panel = main_panel_manager.GetComponentInChildren<MainPanelManagerScript>().aboutPanel;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");

                AboutButtonScript about_button_script = main_panel_manager.
                    GetComponentInChildren<MainPanelManagerScript>().
                    aboutButton.
                    GetComponent<AboutButtonScript>();
                about_button_script.whenPressed();

                BackToMainFromAboutButtonScript back_to_main_from_about_script = about_panel.transform.GetChild(2).
                    GetComponent<BackToMainFromAboutButtonScript>();
                back_to_main_from_about_script.whenPressed();

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
    }
}
