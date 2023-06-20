using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vrillar
{
    public interface IGameInput
    {
        void OnHome();
        void OnEnter(bool enable);
        void OnSendMessage();
        void OnMouse();
    }

    public class GGameplay : MonoBehaviour, IGameInput
    {
        [SerializeField] public GLight Lighting;
        [SerializeField] public ThirdPersonController Controller;
        [SerializeField] public PlayerInput GameInput;
        IGameController _gameController;


<<<<<<< Updated upstream
        [SerializeField] public GCamera GCamera;
        // [SerializeField] public PlayerController Controller;

        IGameController _gameController = null;
        [SerializeField] PlayerInput _gameInput;

        public void Setup(IGameController controller)
        {
            _gameController = controller;
            // Controller.RegisterInput(this);
        }

        public void OnEnter(bool enable)
        {
            // _gameController?.TapEnter(enable);
        }

        public void OnHome()
        {
            // _gameController?.ForceHome();
        }

        public void OnSendMessage()
        {
            // _gameController?.OnSendMessage();
        }
        public void OnMouse()
        {
            // _gameController?.OnMouse();
=======
        public void Setup(IGameController controller)
        {
            _gameController = controller;
            Lighting.Setup();
>>>>>>> Stashed changes
        }
    }
}
