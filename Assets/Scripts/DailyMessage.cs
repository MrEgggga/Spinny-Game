using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DailyMessage : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] messages;
    public static DateTime initialDate = new DateTime(2022, 2, 10);

    // Start is called before the first frame update
    void Start()
    {
        DateTime today = DateTime.Today;
        TimeSpan sinceInitial = today.Subtract(initialDate);
        int days = sinceInitial.Days % messages.Length;
        text.text = messages[days];
    }
}
