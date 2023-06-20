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
<<<<<<< Updated upstream
        public void Setup(IGameController controller, IPlayViewListener listener)
=======
        System.Action<float, float> _onConfirm = null;

        public void Setup(IGameController controller, IPlayViewListener listener, System.Action<float, float> onConfirm)
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======
        public void TouchedConfirm()
        {
            _onConfirm?.Invoke(float.Parse(_posX.text), float.Parse(_posY.text));
        }

>>>>>>> Stashed changes


    }
}