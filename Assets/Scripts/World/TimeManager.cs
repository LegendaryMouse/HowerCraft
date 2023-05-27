using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool isTimeSlowed = false; // ���������� ���������� �� ��������� ���������� �������

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isTimeSlowed)
            {
                // ���������� �������
                Time.timeScale = 0.00f;
                isTimeSlowed = true;
            }
            else
            {
                // ������� � ���������� �������� �������
                Time.timeScale = 1.0f;
                isTimeSlowed = false;
            }
        }
    }
}