using System.Collections;
using System.Collections.Generic;
using CopperDevs.Tools.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CopperDevs.Tools.Scenes.Transitioner
{

[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
public class SceneTransitioner : SingletonMonoBehaviour<SceneTransitioner>
{
    private Canvas transitionCanvas;
    [SerializeField] private List<Transition> transitions = new();
    
    private AsyncOperation loadLevelOperation;
    private BaseTransition activeTransition;

    private void Awake()
    {
        SceneManager.activeSceneChanged += HandleSceneChange;
        DontDestroyOnLoad(gameObject);
        
        transitionCanvas = GetComponent<Canvas>();
        transitionCanvas.enabled = false;
    }

    public void LoadScene(string scene, TransitionMode transitionMode = TransitionMode.None, LoadSceneMode mode = LoadSceneMode.Single)
    {
        loadLevelOperation = SceneManager.LoadSceneAsync(scene);

        var transition = transitions.Find( (transition) => transition.mode == transitionMode );

        if (transition != null)
        {
            loadLevelOperation.allowSceneActivation = false;
            transitionCanvas.enabled = true;
            activeTransition = transition.animation;
            StartCoroutine(Exit());
        }
        else
        {
            Debug.LogWarning($"No transition found for TransitionMode {transitionMode}! Maybe you are misssing a configuration?");
        }
    }

    private IEnumerator Exit()
    {
        yield return StartCoroutine(activeTransition.Exit(transitionCanvas));
        loadLevelOperation.allowSceneActivation = true;
    }

    private IEnumerator Enter()
    {
        yield return StartCoroutine(activeTransition.Enter(transitionCanvas));
        transitionCanvas.enabled = false;
        loadLevelOperation = null;
        activeTransition = null;
    }

    private void HandleSceneChange(Scene oldScene, Scene newScene)
    {
        if (activeTransition != null)
        {
            StartCoroutine(Enter());
        }
    }

    [System.Serializable]
    public class Transition
    {
        public TransitionMode mode;
        public BaseTransition animation;
    }
}

}