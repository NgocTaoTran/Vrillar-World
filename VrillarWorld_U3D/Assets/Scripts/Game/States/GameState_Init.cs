using System.Collections;
using System.Collections.Generic;
using StormStudio.Common;
using StormStudio.Common.UI;
using StormStudio.Common.Utils;
using UnityEngine;
using static StormStudio.Common.GSMachine;
using System.Threading.Tasks;

namespace Vrillar
{
    public partial class GameFlow : MonoBehaviour
    {
        GameController _gameController;
        async void GameState_Init(StateEvent stateEvent)
        {
            if (stateEvent == StateEvent.Enter)
            {
                _gameController = GameController.Instance;
                await InitGame();
            }
            else if (stateEvent == StateEvent.Exit)
            {
            }
        }

        public async Task InitGame()
        {
            await _gameController.Initialize();
            OnInitFinished();
        }

        public void OnInitFinished()
        {
            GameFlow.Instance.SceneTransition(() =>
            {
                _gsMachine.ChangeState(GameState.Gameplay);

            });
        }
    }
}