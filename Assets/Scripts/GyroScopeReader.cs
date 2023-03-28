using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GyroScopeReader
{
    public GyroScopeReader(float x, float z)
    {
        xTreshHold = x;
        zTreshHold = z;
    }

    float xTreshHold;
    float zTreshHold;

    /// <summary>
    /// Returns true if the phone is lying flat and false otherwise
    /// </summary>
    /// <returns></returns>
    public bool IsFlat()
    {
        if (AttitudeSensor.current.attitude.ReadValue().x <= xTreshHold && AttitudeSensor.current.attitude.ReadValue().x >= -xTreshHold &&
             AttitudeSensor.current.attitude.ReadValue().z >= -zTreshHold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 RecordAccelrometerValues()
    {
        return Accelerometer.current.acceleration.ReadValue();
    }
}
