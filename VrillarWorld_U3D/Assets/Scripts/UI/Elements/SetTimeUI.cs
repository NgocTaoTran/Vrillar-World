using System;
using System.Collections;
using System.Collections.Generic;
using StormStudio.Common.UI;
using TMPro;
using UnityEngine;
namespace Vrillar
{
    public class SetTimeUI : UIController
    {
        [SerializeField] TMP_InputField _hourInputField;
        [SerializeField] TMP_InputField _minuteInputField;
        [SerializeField] TMP_InputField _secondInputField;
        [SerializeField] TMP_InputField _dayInputField;
        [SerializeField] TMP_InputField _monthInputField;
        [SerializeField] TMP_InputField _yearInputField;
        TimeData _data;

        System.Action<TimeData> _onConfirm = null;
        System.Action _onClose = null;

        public void Setup(System.Action<TimeData> onConfirm, System.Action onClose)
        {
            _onConfirm = onConfirm;
            _onClose = onClose;
        }

        public void TouchedClose()
        {
            _onClose?.Invoke();
        }

        public void TouchedConfirm()
        {
            _data = new TimeData();
            _data.Hour = int.Parse(_hourInputField.text);
            _data.Minute = int.Parse(_minuteInputField.text);
            _data.Second = int.Parse(_secondInputField.text);
            _data.Day = int.Parse(_dayInputField.text);
            _data.Month = int.Parse(_monthInputField.text);
            _data.Year = int.Parse(_yearInputField.text);

            _onConfirm?.Invoke(_data);
        }
    }
}