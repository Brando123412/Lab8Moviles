using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControllerSceneMenu : MonoBehaviour
{
    [SerializeField] SceneAsset sceneGame;
    [SerializeField] SceneAsset sceneResult;
    private void Start()
    {
        GoToGame();
        Invoke("Confia", 2);
    }
    public void GoToGame()
    {
        GlobalSceneManager.CargarScene?.Invoke(sceneGame);
        GlobalSceneManager.CargarScene?.Invoke(sceneResult);
    }
    public void Confia(){

        GlobalSceneManager.SetActiveObjecScene?.Invoke(sceneResult, false);
    }
}
