using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Vrillar
{
    public interface IGameController
    {
    }

    public partial class GameController : IGameController
    {
        private static GameController instance;
        public GGameplay GGameplay;


        private GameController() { }

        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        public async Task Initialize()
        {
            GGameplay = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Gameplay")).GetComponent<GGameplay>();
            GGameplay.Setup(this);
        }
    }
}
