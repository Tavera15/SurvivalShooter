using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float duration = 1;
    public float slowValue = 0.0f;
    public static TimeManager instance;
    float waitDelta = 0;

    void Start()
    {
        if (instance == null)
            instance = this;
        if (this != instance)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (waitDelta > duration)
            Time.timeScale = 1;
        else
        {
            Time.timeScale += (1f / duration) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
        }
    }

    public void SlowTime(float slowVal)
    {
        slowValue = slowVal;
        Time.timeScale = slowValue;
    }
}