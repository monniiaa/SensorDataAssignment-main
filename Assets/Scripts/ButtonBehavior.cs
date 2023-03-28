using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBehavior: MonoBehaviour
{
    public Button startButton;
    public Text buttonText;
    public bool record = false;
    // Start is called before the first frame update
    private void Start()
    {
        startButton.onClick.AddListener(SetRecording);
    }

    /// <summary>
    /// Sets the recording state when pressing the button
    /// </summary>
    public void SetRecording()
    {
        record = !record;
    }

    /// <summary>
    /// Set the text for the button
    /// </summary>
    /// <param name="text">The text for the button</param>

    public void SetButtonText(string text)
    {
       buttonText.text = text;
    }

}