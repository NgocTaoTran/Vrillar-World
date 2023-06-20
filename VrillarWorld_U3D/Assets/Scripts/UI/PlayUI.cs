using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StormStudio.Common.UI;
using TMPro;

namespace Vrillar
{
    public interface IPlayViewListener
    {
        void EnableSetTimeUI();
    }
    public class PlayUI : UIController
    {

        [SerializeField] OclockUI _uiClock;
        [SerializeField] TMP_InputField _posX;
        [SerializeField] TMP_InputField _posY;
        IPlayViewListener _listener;
        IGameController _controller;
        System.Action<int, int> _onConfirm = null;

        public void Setup(IGameController controller, IPlayViewListener listener, System.Action<int, int> onConfirm)
        {
            _listener = listener;
            _controller = controller;
            _onConfirm = onConfirm;
        }

        public void TouchedOLock()
        {
            _listener?.EnableSetTimeUI();
        }

        public void UpdateTime(TimeData data)
        {
            _uiClock.UpdateTime(data);
        }

        public void TouchedConfirm()
        {
            _onConfirm?.Invoke(int.Parse(_posX.text), int.Parse(_posY.text));
        }



    }
}