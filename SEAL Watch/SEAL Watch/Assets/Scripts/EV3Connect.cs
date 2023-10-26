using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MonoBrick.EV3;
using System.IO.Ports;

public class EV3Connect : MonoBehaviour
{
    [SerializeField] public TMP_Text status;

    private void Update()
    {
        StartCoroutine(Ev3());
    }

    IEnumerator Ev3()
    {
        var ev3 = new Brick<Sensor, Sensor, Sensor, Sensor>("com13");
        ev3.Connection.Open();

        yield return new WaitForSeconds(1f);
        ev3.MotorA.On(50,360,true);
        status.text = "Motor's running";

        yield return new WaitForSeconds(1f);
        System.Threading.Thread.Sleep(3000);
        status.text = "Motor's sleeping";

        yield return new WaitForSeconds(1f);
        ev3.MotorA.Off();
        status.text = "Motor turned off";
    }
}