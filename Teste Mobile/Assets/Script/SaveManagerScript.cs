using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManagerScript : MonoBehaviour
{
    private const string save_file_address = "Assets/Resources/save_file.txt";

    public static Dictionary<string, string> save_data;
    private static List<string> to_save_and_load;

    // Start is called before the first frame update
    void Start()
    {
        save_data = new Dictionary<string, string>();
        to_save_and_load = new List<string>();

        FromSaveToLikert();
        
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
        if (File.Exists(save_file_address))
        {
            File.Delete(save_file_address);
        }

        StreamWriter writer = new StreamWriter(save_file_address, true);
        foreach(string key_value in to_save_and_load)
        {
            writer.WriteLine(key_value);
        }
        writer.Close();
    }

    public bool FromSaveToLikert()
    {
        try
        {
            StreamReader reader = new StreamReader(save_file_address, true);
            while (reader.Peek() >= 0)
            {
                to_save_and_load.Add(reader.ReadLine());
            }
            reader.Close();

            foreach(string key_value in to_save_and_load)
            {
                string[] key_and_value_separated = key_value.Split(new char[] { '|' });
                save_data.Add(key_and_value_separated[0], key_and_value_separated[1]);
            }
            Debug.Log(GetAllData());

            return true;
        }
        catch (ArgumentNullException e)
        {
            return false;
        }
        
    }

    private static void CleanData()
    {
        save_data.Clear();
    }

    void OnApplicationQuit()
    {
        FromDictionaryToSave();
    }

}
