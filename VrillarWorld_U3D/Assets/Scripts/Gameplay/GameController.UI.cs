using System.Collections;
using System.Collections.Generic;
using StormStudio.Common.UI;
using UnityEngine;
using Vrillar;

namespace Vrillar
{
    public partial class GameController : IPlayViewListener
    {
        PlayUI _playUI;
        public void Setup()
        {
            ShowUI();
        }
        public void ShowUI()
        {
            _playUI = UIManager.Instance.ShowUIOnTop<PlayUI>("PlayUI");
            _playUI.Setup(this, this, onUpdatePos);
        }
        public void EnableSetTimeUI()
        {
            var setTimeUI = UIManager.Instance.ShowUIOnTop<SetTimeUI>("SetTimeUI");
            setTimeUI.Setup(onUpdateTime,
            () =>
            {
                UIManager.Instance.ReleaseUI(setTimeUI, true);
            });
        }

        public void onUpdateTime(TimeData data)
        {
            _playUI.UpdateTime(data);
            GGameplay.Lighting.SetPosSun(data);
        }

        public void onUpdatePos(float X, float Y)
        {
            GGameplay.Controller.SetPosition(X, Y);
        }
    }
}
