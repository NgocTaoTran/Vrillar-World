using System.Collections;
using System.Collections.Generic;
using StormStudio.Common;
using StormStudio.Common.UI;
using StormStudio.Common.Utils;
using UnityEngine;
using static StormStudio.Common.GSMachine;

public partial class GameFlow : MonoBehaviour
{
    void GameState_Init(StateEvent stateEvent)
    {
        if (stateEvent == StateEvent.Enter)
        {
        }
        else if (stateEvent == StateEvent.Exit)
        {
        }
    }
}