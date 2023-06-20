using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vrillar
{
    public interface IGameInput
    {
    }

    public class GGameplay : MonoBehaviour, IGameInput
    {


        [SerializeField] GCamera _gCamera;
        [SerializeField] GLight _lighting;
        // [SerializeField] public PlayerController Controller;

        IGameController _gameController = null;
        [SerializeField] PlayerInput _gameInput;

        public void Setup(IGameController controller)
        {
            _gameController = controller;
            _lighting.Setup();
        }

        public void SetPosSun(TimeData data)
        {
            _lighting.SetPosSun(data);
        }
    }
}
