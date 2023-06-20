using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StormStudio.Common.UI;

namespace Vrillar
{
    public interface IPlayViewListener
    {
        void EnableSetTimeUI();
    }
    public class PlayUI : UIController
    {

        [SerializeField] UIClock _uiClock;
        IPlayViewListener _listener;
        IGameController _controller;
        public void Setup(IGameController controller, IPlayViewListener listener)
        {
            _listener = listener;
            _controller = controller;
        }

        public void TouchedOLock()
        {
            _listener?.EnableSetTimeUI();
        }

        public void UpdateTime(TimeData data)
        {
            _uiClock.UpdateTime(data);
        }



    }
}