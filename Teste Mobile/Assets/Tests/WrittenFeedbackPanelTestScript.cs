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

        //Test 1: back button.
        //Test 2: loading info.
        //Test 3: saving info.
        //Test 4: loading and saving info to Likert. (the other chat)
        //Test 5: Writing name and info works.
    }

}
