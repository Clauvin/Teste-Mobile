using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using UnityEngine;

/// <summary>
/// SaveManagerScript v1.0.0
/// 
/// What it does: takes care of all things related to the save file where the feedback about the guidelines is.
///     That includes saving, loading, erasing the file and also sending the info through the internet to be analyzed later.
/// </summary>
public class SaveManagerScript : MonoBehaviour
{
    public static string save_file_address { get; private set; }

    public static Dictionary<string, string> data_dictionary;
    public static List<string> list_used_to_save_and_load_stuff;

    public static int amount_of_accesses_to_from_save_to_likert = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitializingSaveFileAddress();
        data_dictionary = new Dictionary<string, string>();
        list_used_to_save_and_load_stuff = new List<string>();

        FromSaveFileToDataDictionary();
        EraseSaveFile();
        list_used_to_save_and_load_stuff.Clear();
    }

    public void InitializingSaveFileAddress()
    {
        save_file_address = Application.persistentDataPath + "/save_file.txt";
    }

    public bool FromSaveFileToDataDictionary()
    {
        try
        {
            PassDataFromSaveFileToListUsedToSaveAndLoadStuff();

            AvoidingNullExceptionsWhileTesting();

            PassDataFromListUsedToSaveAndLoadStuffToDataDictionary();

            return true;
        }
        catch (ArgumentNullException ane)
        {
            Debug.Log(ane.Message);
            return false;
        }
        catch (IOException ioe)
        {
            Debug.Log(ioe.Message);
            return false;
        }
    }

    private void PassDataFromSaveFileToListUsedToSaveAndLoadStuff()
    {
        StreamReader reader = new StreamReader(save_file_address, true);
        while (reader.Peek() >= 0)
        {
            if (list_used_to_save_and_load_stuff == null) list_used_to_save_and_load_stuff = new List<string>();
            list_used_to_save_and_load_stuff.Add(reader.ReadLine());
        }
        reader.Close();
    }

    private void AvoidingNullExceptionsWhileTesting()
    {
        if (data_dictionary == null) data_dictionary = new Dictionary<string, string>();

        if (list_used_to_save_and_load_stuff == null) list_used_to_save_and_load_stuff = new List<string>();
    }

    private void PassDataFromListUsedToSaveAndLoadStuffToDataDictionary()
    {
        foreach (string key_value in list_used_to_save_and_load_stuff)
        {
            string[] key_and_value_separated = key_value.Split(new char[] { '|' });
            if (!data_dictionary.ContainsKey(key_and_value_separated[0]))
            {
                data_dictionary.Add(key_and_value_separated[0], key_and_value_separated[1]);
            }

        }
    }

    public static void EraseSaveFile()
    {
        try
        {
            File.Delete(save_file_address);
            if (File.Exists(save_file_address)) Debug.LogError("DAMN");
        }
        catch (IOException ioe)
        {
            Debug.Log("So, you really should take a look at why the save file is not being erased.");
        }
    }

    public static void AddDataToDictionary(string key, string value)
    {
        if (data_dictionary == null) data_dictionary = new Dictionary<string, string>();

        if (data_dictionary.ContainsKey(key)) data_dictionary.Remove(key);

        data_dictionary.Add(key, value);
    }

    public bool SendMail()
    {
        return SendAllData();
    }

    public static bool SendAllData()
    {
        string message_body = GetAllDictionaryData();

        MailMessage mail_message = CreatingMailMessage(message_body);

        SmtpClient smtpClient = CreatingSmtpClient();

        try
        {
            smtpClient.Send(mail_message);
            return true;
        }
        catch (SmtpException smtp_ex)
        {
            return false;
        }

    }

    private static MailMessage CreatingMailMessage(string message_body)
    {
        MailMessage mail_message = new MailMessage("gamification.feedback@gmail.com", "gamification.feedback@gmail.com");
        mail_message.Subject = "Guidelines Comments";
        mail_message.Body = message_body;

        return mail_message;
    }

    private static SmtpClient CreatingSmtpClient()
    {
        SmtpClient smtpClient = new SmtpClient("email-smtp.sa-east-1.amazonaws.com");
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential("AKIA4RGKW2JFOPB3HA3X",
            "BEggZxh3/R2g6U9wyWBcv7cKowHXudnU0B/FhLwmpewB");
        smtpClient.EnableSsl = true;

        return smtpClient;
    }

    public static string GetAllDictionaryData()
    {
        string data = "";
        const string new_line = "\r\n";
        foreach(KeyValuePair<string,string> data_pair in data_dictionary)
        {
            data += data_pair.Key + "|" + data_pair.Value;
            data += new_line;
        }

        return data;
    }

    public void FromDictionaryDataToSaveFile()
    {
        foreach (KeyValuePair<string, string> data_pair in data_dictionary)
        {
            list_used_to_save_and_load_stuff.Add(data_pair.Key + "|" + data_pair.Value);
        }

        PassDictionaryDataToSaveFile();
    }

    public void PassDictionaryDataToSaveFile()
    {
        try
        {
            StreamWriter writer = new StreamWriter(save_file_address, true);

            foreach (string key_value in list_used_to_save_and_load_stuff)
            {
                writer.WriteLine(key_value);
            }
            writer.Close();
        }
        catch (IOException ioe)
        {
            
        }
        
    }

    private static void CleanDictionaryData()
    {
        data_dictionary.Clear();
    }

    void OnApplicationQuit()
    {
        FromDictionaryDataToSaveFile();
    }

}
