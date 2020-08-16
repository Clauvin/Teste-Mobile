using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using UnityEngine;

public class SaveManagerScript : MonoBehaviour
{
    public static string save_file_address { get; private set; }

    public static Dictionary<string, string> save_data;
    public static List<string> to_save_and_load;

    public static int amount_of_accesses_to_from_save_to_likert = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitializingSaveFileAddress();
        save_data = new Dictionary<string, string>();
        to_save_and_load = new List<string>();

        //Debug.Log("1");
        FromSaveFileToData();
        //Debug.Log("2");
        EraseSaveFile();
        //Debug.Log("3");
        to_save_and_load.Clear();
        //Debug.Log("4");

    }

    public void InitializingSaveFileAddress()
    {
        save_file_address = Application.persistentDataPath + "/save_file.txt";
    }

    public static void AddData(string key, string value)
    {
        if (save_data == null) save_data = new Dictionary<string, string>();
        if (save_data.ContainsKey(key)) save_data.Remove(key);

        save_data.Add(key, value);
    }

    public static bool SendAllData()
    {
        string data = GetAllData();

        MailMessage mail_message = new MailMessage("almeidaclauvin@gmail.com",
            "almeidaclauvin@gmail.com");
        mail_message.Subject = "Guidelines Comments";
        mail_message.Body = data;

        SmtpClient smtpServer = new SmtpClient("email-smtp.sa-east-1.amazonaws.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("AKIA4RGKW2JFOPB3HA3X",
            "BEggZxh3/R2g6U9wyWBcv7cKowHXudnU0B/FhLwmpewB");
        smtpServer.EnableSsl = true;

        try
        {
            //Debug.Log("sending");
            smtpServer.Send(mail_message);
            //Debug.Log("sent!");
            return true;
        }
        catch (SmtpException smtp_ex)
        {
            return false;
        }

    }

    public bool SendMail()
    {
        return SendAllData();
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
        foreach (KeyValuePair<string, string> data_pair in save_data)
        {
            to_save_and_load.Add(data_pair.Key + "|" + data_pair.Value);
        }

        PassDataToSaveFile();
    }

    public void PassDataToSaveFile()
    {
        try
        {
            StreamWriter writer = new StreamWriter(save_file_address, true);

            foreach (string key_value in to_save_and_load)
            {
                writer.WriteLine(key_value);
            }
            writer.Close();
        }
        catch (IOException ioe)
        {
            
        }
        
    }

    public bool FromSaveFileToData()
    {
        try
        {
            StreamReader reader = new StreamReader(save_file_address, true);
            while (reader.Peek() >= 0)
            {
                if (to_save_and_load == null) to_save_and_load = new List<string>();
                to_save_and_load.Add(reader.ReadLine());
            }
            reader.Close();

            if (save_data == null) save_data = new Dictionary<string, string>();

            if (to_save_and_load == null) to_save_and_load = new List<string>();

            foreach(string key_value in to_save_and_load)
            {
                string[] key_and_value_separated = key_value.Split(new char[] { '|' });
                if (!save_data.ContainsKey(key_and_value_separated[0]))
                {
                    save_data.Add(key_and_value_separated[0], key_and_value_separated[1]);
                }
                
            }

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

    public static void EraseSaveFile()
    {
        try
        {
            File.Delete(save_file_address);
            if (File.Exists(save_file_address)) Debug.Log("DAMN");
        }
        catch (IOException ioe)
        {

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
