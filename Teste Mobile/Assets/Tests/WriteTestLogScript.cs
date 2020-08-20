using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// WriteTestLogScript v1.0.0
/// 
/// What it does: writes strings to the test log.
/// 
/// </summary>
public class WriteTestLogScript : MonoBehaviour
{
    public static void WriteString(string text)
    {
        string path;

        if (Application.platform == RuntimePlatform.Android)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/testing/");
            path = Application.persistentDataPath + "/testing/test.txt";
        }
        else
        {
            path = "Assets/Resources/test.txt";
        }

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(text);
        writer.Close();
    }

    public static void TestPassed(string name_of_the_test)
    {
        WriteString(name_of_the_test + " test passed.");
    }

    public static void TestFailed(string name_of_the_test)
    {
        WriteString("WARNING! " + name_of_the_test + " test failed.");
    }

}
