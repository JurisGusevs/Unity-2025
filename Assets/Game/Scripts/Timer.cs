using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float _currentTime = 0f;

    public bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _currentTime = _currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);

            timerText.text = time.ToString("mm':'ss");
        }
    }
}
