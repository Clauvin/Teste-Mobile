﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SendingFeedbackScript v1.0.0
/// 
/// What it does: deals with sending a mail with the feedback and giving feedback to the user.
/// 
/// Also: the name of this class was a happy serendipity and will stay as it is. :)
/// </summary>
public class SendingFeedbackScript : MonoBehaviour
{
    public GameObject name_input_field;
    public GameObject considerations_input_field;

    public const string good_title_message = "Thanks";
    public const string good_body_message = "Thanks for your feedback, you can uninstall this app now. :)";

    public const string bad_title_message = "Something went wrong";
    public const string bad_body_message = "Something went wrong, please enter in contact with" +
        " gamification.feedback@gmail.com about it.";

    public void SendingFeedback()
    {
        bool sent_it = SaveManagerScript.SendAllData();

        if (sent_it)
        {
            name_input_field.GetComponent<InputField>().text = good_title_message;
            considerations_input_field.GetComponent<InputField>().text = good_body_message;
        }
        else
        {
            name_input_field.GetComponent<InputField>().text = bad_title_message;
            considerations_input_field.GetComponent<InputField>().text = bad_body_message;
            considerations_input_field.GetComponent<InputField>().text += "(Error code = ";
            considerations_input_field.GetComponent<InputField>().text += SaveManagerScript.smtp_exception.StatusCode;
            considerations_input_field.GetComponent<InputField>().text += ")";
        }
    }
}
