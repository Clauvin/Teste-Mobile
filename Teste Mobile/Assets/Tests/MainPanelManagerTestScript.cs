﻿using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{

    /// <summary>
    /// MainPanelManagerTestScript v1.0.2
    /// 
    /// What it does: takes care of tests involving directly the MainPanelManager class.
    /// 
    /// </summary>
    [TestFixture]
    [Author("Clauvin", "gamification.feedback@gmail.com")]
    public class MainPanelManagerTestScript
    {
        MainPanelManagerScript main_panel_manager_script;
        GameObject object_to_hold_the_main_panel_manager_script;

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("TestScript tests starting.");
        }

        [SetUp]
        public void ResetScene()
        {
            TestContext.WriteLine("Setup started");
            object_to_hold_the_main_panel_manager_script = new GameObject();
            main_panel_manager_script = object_to_hold_the_main_panel_manager_script.AddComponent<MainPanelManagerScript>();
            main_panel_manager_script.aboutPanel = new GameObject();
            main_panel_manager_script.feedbackPanel = new GameObject();
            main_panel_manager_script.guidelinesPanel = new GameObject();
            main_panel_manager_script.mainPanel = new GameObject();
            TestContext.WriteLine("Setup finished");
        }

        [Test]
        public void The_showMainPanelFunction_Works()
        {

            Action this_test_function = this.The_showMainPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.showMainPanel(),
                    (string)MainPanelManagerScript.result_message_show_main_panel_true);
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
        public void The_hideMainPanelFunction_Works()
        {
            Action this_test_function = this.The_hideMainPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");
                Assert.AreEqual(main_panel_manager_script.hideMainPanel(),
                    (string)MainPanelManagerScript.result_message_hide_main_panel_true);
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
        public void The_showGuidelinesPanelFunction_Works()
        {
            Action this_test_function = this.The_showGuidelinesPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.showGuidelinesPanel(),
                (string)MainPanelManagerScript.result_message_show_guidelines_panel_true);
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
        public void The_hideGuidelinesPanelFunction_Works()
        {
            Action this_test_function = this.The_hideGuidelinesPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.hideGuidelinesPanel(),
                    (string)MainPanelManagerScript.result_message_hide_guidelines_panel_true);
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
        public void The_showFeedbackPanelFunction_Works()
        {
            Action this_test_function = this.The_showFeedbackPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.showMainFeedbackPanel(),
                    (string)MainPanelManagerScript.result_message_show_feedback_panel_true);
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
        public void The_hideFeedbackPanelFunction_Works()
        {
            Action this_test_function = this.The_hideFeedbackPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.hideMainFeedbackPanel(),
                   (string)MainPanelManagerScript.result_message_hide_feedback_panel_true);
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
        public void The_showAboutPanelFunction_Works()
        {
            Action this_test_function = this.The_showAboutPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.showAboutPanel(),
                    (string)MainPanelManagerScript.result_message_show_about_panel_true);
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
        public void The_hideAboutPanelFunction_Works()
        {
            Action this_test_function = this.The_hideAboutPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.hideAboutPanel(),
                   (string)MainPanelManagerScript.result_message_hide_about_panel_true);
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
        public void The_setPanelFunction_Works()
        {
            Action this_test_function = this.The_setPanelFunction_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            MethodInfo method = GetMethod(main_panel_manager_script, "setPanel");
            if (!main_panel_manager_script.mainPanel.activeSelf)
                Assert.Fail("The main panel should be active at start.");

            method.Invoke(main_panel_manager_script, new object[] { main_panel_manager_script.mainPanel, false });

            if (main_panel_manager_script.mainPanel.activeSelf)
            {
                WriteTestLogScript.WriteOnLogThatTestFailed(this_test_function_name);
                Assert.Fail("SetPanel did not make main_panel_manager_script inactive");
            }

            WriteTestLogScript.WriteOnLogThatTestPassed(this_test_function_name);
            Assert.Pass();
        }

        [Test]
        public void The_sendMessageAboutIfTheObjectIsActive_Works()
        {
            Action this_test_function = this.The_sendMessageAboutIfTheObjectIsActive_Works;
            string this_test_function_name = this_test_function.Method.Name;

            WriteTestLogScript.WriteString("Starting " + this_test_function_name + " test.");

            MethodInfo method = GetMethod(main_panel_manager_script, "sendMessageAboutIfTheObjectIsActive");

            object passed = method.Invoke(main_panel_manager_script, new object[]
                { main_panel_manager_script.mainPanel, true, "passed", "haven't passed" });

            if (passed.ToString().Equals("passed"))
            {
                WriteTestLogScript.WriteOnLogThatTestPassed(this_test_function_name);
                Assert.Pass();
            }
            else
            {
                WriteTestLogScript.WriteOnLogThatTestFailed(this_test_function_name);
                Assert.Fail();
            }
        }

        [OneTimeTearDown]
        public void WriteEndOfLog()
        {
            WriteTestLogScript.WriteString("TestScript tests finishing.");
        }

        private MethodInfo GetMethod(UnityEngine.Object the_object, string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");

            var method = the_object.GetType()
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }
    }
}
