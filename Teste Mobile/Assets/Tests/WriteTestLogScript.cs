using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class WriteTestLogScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void WriteString(string text)
    {
        string path;

        if (Application.platform == RuntimePlatform.Android)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/testing/");
            path = Application.persistentDataPath + "/testing/test.txt";
            Debug.Log(path);
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
        WriteTestLogScript.WriteString(name_of_the_test + " test passed.");
    }

    public static void TestFailed(string name_of_the_test)
    {
        WriteTestLogScript.WriteString("WARNING! " + name_of_the_test + " test failed.");
    }

    public static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
