using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerScript : MonoBehaviour
{
    private static Dictionary<string, string> save_data;

    // Start is called before the first frame update
    void Start()
    {
        save_data = new Dictionary<string, string>();
    }

    public static void AddData(string key, string value)
    {
        save_data.Add(key, value);
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

    public static void SendAllData()
    {
        string data = GetAllData();
        //send mail with data to server OR my e-mail.
    }


}
