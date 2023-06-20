using System.Collections;
using System.Collections.Generic;
using StormStudio.Common;
using StormStudio.Common.UI;
using StormStudio.Common.Utils;
using UnityEngine;

namespace Vrillar
{
    public partial class GameFlow : MonoBehaviour
    {
        public static GameFlow Instance { get; private set; }

        // [SerializeField] LoadingUI _loadingUI;
        private GSMachine _gsMachine = new GSMachine();

        void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

#if !BUILD_DEV || DISABLE_LOGS
            Debug.unityLogger.logEnabled = false;
#endif
            Input.multiTouchEnabled = false;

#if UNITY_STANDALONE && !UNITY_EDITOR
        Screen.SetResolution(720, 1280, false);
#endif

            if (Application.isEditor)
                Application.runInBackground = true;

            Application.targetFrameRate = 60;
        }

        IEnumerator Start()
        {
            yield return null;

            HideLoading();

            _gsMachine.Init(OnStateChanged, GameState.Init);

            while (true)
            {
                _gsMachine.StateUpdate();
                yield return null;
            }
        }

        void ShowLoading()
        {
            // UIManager.Instance.ShowUIOnTop(_loadingUI, 1);
        }

        void HideLoading()
        {
            // UIManager.Instance.ReleaseUI(_loadingUI, false);
        }

        public T ShowUI<T>(string uiPath, bool overlay = false) where T : UIController
        {
            return UIManager.Instance.ShowUIOnTop<T>(uiPath, overlay);
        }

        public void SceneTransition(System.Action onSceneOutFinished)
        {
            UIManager.Instance.SetUIInteractable(false);
            SceneDirector.Instance.Transition(new TransitionFade()
            {
                duration = 0.667f,
                tweenIn = TweenFunc.TweenType.Sine_EaseInOut,
                tweenOut = TweenFunc.TweenType.Sine_EaseOut,
                onStepOutDidFinish = () =>
                {
                    onSceneOutFinished.Invoke();
                },
                onStepInDidFinish = () =>
                {
                    UIManager.Instance.SetUIInteractable(true);
                }
            });
        }

        #region GSMachine
        GSMachine.UpdateStateDelegate OnStateChanged(System.Enum state)
        {
            switch (state)
            {
                case GameState.Init:
                    return GameState_Init;
                case GameState.Gameplay:
                    return GameState_Gameplay;
                    // case GameState.Tutorial:
                    // return GameState_Tutorial;
            }

            return null;
        }
        #endregion
    }
}