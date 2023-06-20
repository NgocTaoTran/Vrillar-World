using System.Collections;
using System.Collections.Generic;
using StormStudio.Common;
using StormStudio.Common.UI;
using StormStudio.Common.Utils;
using UnityEngine;
using Vrillar;
using static StormStudio.Common.GSMachine;

namespace Vrillar
{
    public partial class GameFlow : MonoBehaviour
    {
        void GameState_Gameplay(StateEvent stateEvent)
        {
            if (stateEvent == StateEvent.Enter)
            {
                GameController.Instance.Setup();
            }
            else if (stateEvent == StateEvent.Exit)
            {
            }
        }
    }
}