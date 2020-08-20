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
        GameObject prefab_main_menu;
        MainPanelManagerScript main_panel_manager;
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
            Action this_test_function = this.TheBackButtonFromTheAboutPanelWorks;
            string this_test_function_name = this_test_function.Method.Name;

            prefab_main_menu = GameObject.Find("Prefab Main Menu");
            main_panel_manager = prefab_main_menu.GetComponentInChildren<MainPanelManagerScript>();

            main_panel = main_panel_manager.mainPanel;
            about_panel = main_panel_manager.aboutPanel;

            try
            {
                WriteTestLogScript.WriteOnLogThatTestStarted(this_test_function_name);

                AboutButtonScript about_button_script = main_panel_manager.aboutButton.GetComponent<AboutButtonScript>();
                    about_button_script.whenPressed();

                BackToMainFromAboutButtonScript back_to_main_from_about_script = about_panel.transform.Find("Back Button").
                    GetComponent<BackToMainFromAboutButtonScript>();
                back_to_main_from_about_script.whenPressed();

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
    }
}
