using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    [Author("Cláuvin", "")]
    public class AboutPanelTestScript
    {

        [OneTimeSetUp]
        public void WriteStartOfLog()
        {
            WriteTestLogScript.WriteString("AboutPanelTestScript tests starting.");
        }

        [SetUp]
        public void ResetScene()
        {
            TestContext.WriteLine("Setup started");
            TestContext.WriteLine("Setup finished");
        }


        // A Test behaves as an ordinary method
        [Test]
        public void BackButtonWorks()
        {
            Action del = this.BackButtonWorks;
            string ret = del.Method.Name;

            try
            {
                WriteTestLogScript.WriteString("Starting " + ret + " test.");
                GameObject main_panel = GameObject.Find("Main Panel");
                Assert.AreEqual(main_panel.activeSelf,
                    true);
            }
            catch (AssertionException ae)
            {
                WriteTestLogScript.TestFailed(ret);
                Assert.Fail();
                return;
            }

            WriteTestLogScript.TestPassed(ret);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator AboutPanelTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
