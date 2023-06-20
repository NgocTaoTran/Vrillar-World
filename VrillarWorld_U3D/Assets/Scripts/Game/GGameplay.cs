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
        [SerializeField] public GLight Lighting;
        [SerializeField] public ThirdPersonController Controller;
        [SerializeField] public PlayerInput GameInput;
        IGameController _gameController = null;
        [SerializeField] PlayerInput _gameInput;
        public void Setup(IGameController controller)
        {
            _gameController = controller;
            Lighting.Setup();
        }
    }
}
