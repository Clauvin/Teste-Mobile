using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    [Author("Cláuvin", "")]
    public class TestMainPanelManagerScript
    {
        MainPanelManagerScript main_panel_manager_script;
        GameObject obj;

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("TestScript tests starting.");
        }

        [SetUp]
        public void ResetScene()
        {
            TestContext.WriteLine("Setup started");
            obj = new GameObject();
            main_panel_manager_script = obj.AddComponent<MainPanelManagerScript>();
            main_panel_manager_script.aboutPanel = new GameObject();
            main_panel_manager_script.feedbackPanel = new GameObject();
            main_panel_manager_script.guidelinesPanel = new GameObject();
            main_panel_manager_script.mainPanel = new GameObject();
            TestContext.WriteLine("Setup finished");
        }

        [Test]
        public void NewPanelShow()
        {

            Action del = this.NewPanelShow;
            string ret = del.Method.Name;

            WriteTestLogScript.WriteString("Starting " + ret + " test.");

            try
            {
                Assert.AreEqual(main_panel_manager_script.showMainPanel(),
                    (string)MainPanelManagerScript.result_message_show_main_panel_true);
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
        public void NewPanelHide()
        {
            Action del = this.NewPanelHide;
            string ret = del.Method.Name;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                Assert.AreEqual(main_panel_manager_script.hideMainPanel(),
                    (string)MainPanelManagerScript.result_message_hide_main_panel_true);
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
        public void GuidelinesPanelShow()
        {
            Assert.AreEqual(main_panel_manager_script.showGuidelinesPanel(),
                (string)MainPanelManagerScript.result_message_show_guidelines_panel_true);
        }

        [Test]
        public void GuidelinesPanelHide()
        {
            Assert.AreEqual(main_panel_manager_script.hideGuidelinesPanel(),
                (string)MainPanelManagerScript.result_message_hide_guidelines_panel_true);
        }

        [Test]
        public void MainFeedbackShow()
        {
            Assert.AreEqual(main_panel_manager_script.showMainFeedbackPanel(),
                (string)MainPanelManagerScript.result_message_show_feedback_panel_true);
        }

        [Test]
        public void MainFeedbackHide()
        {
            Assert.AreEqual(main_panel_manager_script.hideMainFeedbackPanel(),
                (string)MainPanelManagerScript.result_message_hide_feedback_panel_true);
        }

        [Test]
        public void MainAboutShow()
        {
            Assert.AreEqual(main_panel_manager_script.showAboutPanel(),
                (string)MainPanelManagerScript.result_message_show_about_panel_true);
        }

        [Test]
        public void MainAboutHide()
        {
            Assert.AreEqual(main_panel_manager_script.hideAboutPanel(),
                (string)MainPanelManagerScript.result_message_hide_about_panel_true);
        }

        [Test]
        public void SetPanel()
        {
            MethodInfo method = GetMethod(main_panel_manager_script, "setPanel");
            if (!main_panel_manager_script.mainPanel.activeSelf)
                Assert.Fail("The main panel should be active at start.");

            method.Invoke(main_panel_manager_script, new object[] { main_panel_manager_script.mainPanel, false });

            if (main_panel_manager_script.mainPanel.activeSelf)
                Assert.Fail("SetPanel did not make main_panel_manager_script inactive");

            Assert.Pass();
        }

        [Test]
        public void SendMessageAboutActive()
        {
            MethodInfo method = GetMethod(main_panel_manager_script, "sendMessageAboutActive");

            object passed = method.Invoke(main_panel_manager_script, new object[]
                { main_panel_manager_script.mainPanel, true, "passed", "haven't passed" });

            if (passed.ToString().Equals("passed")) Assert.Pass();
            else Assert.Fail();
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
