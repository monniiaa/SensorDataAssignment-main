using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.InputSystem;


public class Attitude : MonoBehaviour
{
    [SerializeField]
    ButtonBehavior button;
    CSVWriter csvWriter;
    GyroScopeReader sensorReader;

    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI zText;
    public TextMeshProUGUI debugText;

    public List<Vector3> accDataList = new List<Vector3>();
    int filenumber = 1;

    private void Start()
    {
        sensorReader = new GyroScopeReader(0.03f, 0.07f);
        InputSystem.EnableDevice(Accelerometer.current);
        InputSystem.EnableDevice(AttitudeSensor.current);
        csvWriter = new CSVWriter();
    }

    private void Update() {

        SetDebuggingTest();

        if (button.record && !sensorReader.IsFlat() && accDataList.Count < 700)
        {
            accDataList.Add(sensorReader.RecordAccelrometerValues());
            button.SetButtonText("Recording");
        } 
        else if (button.record && sensorReader.IsFlat() && accDataList.Count > 0)
        {
            button.record = false;
            csvWriter.WriteCSV("Sensordata" + filenumber, accDataList);
            filenumber++;
            accDataList.Clear();
        }
        
        if (!button.record)
        {
            button.SetButtonText("Start");
            accDataList.Clear();
        } 
    }

    public void SetDebuggingTest()
    {
        if (SystemInfo.supportsGyroscope)
        {
            xText.text = "x:" + AttitudeSensor.current.attitude.ReadValue().x.ToString();
            yText.text = "y:" + AttitudeSensor.current.attitude.ReadValue().y.ToString();
            zText.text = "z:" + AttitudeSensor.current.attitude.ReadValue().z.ToString();
            debugText.text = sensorReader.IsFlat().ToString();
        }
    }
}
