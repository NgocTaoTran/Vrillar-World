using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Vrillar
{
    public class OclockUI : MonoBehaviour
    {
        [SerializeField] Transform _hourHand;
        [SerializeField] Transform _minuteHand;
        [SerializeField] Transform _secondHand;
        [SerializeField] TextMeshProUGUI _dateText;
        DateTime _currentTime;
        float _hourRotation;
        float _minuteRotation;
        float _secondRotation;
        string _date;

        private void Awake()
        {
            _currentTime = DateTime.Now;
        }

        private void Update()
        {
            _currentTime = _currentTime.AddSeconds(Time.deltaTime);

            _hourRotation = 360f * (_currentTime.Hour / 12f);
            _minuteRotation = 360f * (_currentTime.Minute / 60f);
            _secondRotation = 360f * (_currentTime.Second / 60f);
            // Debug.Log("_secondRotation" + _secondRotation);

            _date = _currentTime.ToString("dd/MM/yyyy");

            _hourHand.localRotation = Quaternion.Euler(0f, 0f, -_hourRotation);
            _minuteHand.localRotation = Quaternion.Euler(0f, 0f, -_minuteRotation);
            _secondHand.localRotation = Quaternion.Euler(0f, 0f, -_secondRotation);

            _dateText.text = _date;
        }

        public void UpdateTime(TimeData data)
        {
            _currentTime = new DateTime(data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second);
        }
    }
}