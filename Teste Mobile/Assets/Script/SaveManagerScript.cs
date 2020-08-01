using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManagerScript : MonoBehaviour
{
    public static Dictionary<string, string> save_data;
    private static List<string> to_save_and_load;

    // Start is called before the first frame update
    void Start()
    {
        save_data = new Dictionary<string, string>();
        to_save_and_load = new List<string>();
    }

    public static void AddData(string key, string value)
    {
        if (save_data.ContainsKey(key)) save_data.Remove(key);

        save_data.Add(key, value);
    }

    public static void SendAllData()
    {
        string data = GetAllData();
        //send mail with data to server OR my e-mail.
    }

    public static string GetAllData()
    {
        string data = "";
        foreach(KeyValuePair<string,string> data_pair in save_data)
        {
            data += data_pair.Key + "|" + data_pair.Value;
            data += "\r\n";
        }

        return data;
    }

    public void FromDictionaryToSave()
    {
        Debug.Log(save_data.Count);
       
        foreach (KeyValuePair<string, string> data_pair in save_data)
        {
            to_save_and_load.Add(data_pair.Key + "|" + data_pair.Value);
        }

        PassLikertToSaveFile();
    }

    public void PassLikertToSaveFile()
    {
        string path = "Assets/Resources/save_file.txt";

        StreamWriter writer = new StreamWriter(path, true);
        foreach(string key_value in to_save_and_load)
        {
            writer.WriteLine(key_value);
        }
        writer.Close();
    }

    

    private static void CleanData()
    {
        save_data.Clear();
    }


}
