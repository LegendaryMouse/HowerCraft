using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool isTimeSlowed = false; // переменная отвечающая за состояние замедления времени

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isTimeSlowed)
            {
                // замедление времени
                Time.timeScale = 0.00f;
                isTimeSlowed = true;
            }
            else
            {
                // возврат к нормальной скорости времени
                Time.timeScale = 1.0f;
                isTimeSlowed = false;
            }
        }
    }
}