using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class GlobalSceneManager : MonoBehaviour
{
    [SerializeField] SceneAsset sceneInitial;
    public static Action<SceneAsset> CargarScene;
    public static Action<SceneAsset> DescargarScene;
    public static Action<SceneAsset, bool> SetActiveObjecScene;

    private void OnEnable()
    {
        CargarScene += SceneCargar;
        DescargarScene += SceneDescargar;
        SetActiveObjecScene += ObjetscSceneSetActive;
    }
    private void OnDisable()
    {
        CargarScene -= SceneCargar;
        DescargarScene -= SceneDescargar;
        SetActiveObjecScene -= ObjetscSceneSetActive;
    }
    private void Start()
    {
        CargarScene?.Invoke(sceneInitial);
    }
    private void SceneCargar(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
    }
    private void SceneDescargar(SceneAsset scene)
    {
        SceneManager.UnloadSceneAsync(scene.name);
    }
    private void ObjetscSceneSetActive(SceneAsset scene, bool active)
    {
        GameObject sceneObjectReferences = GameObject.Find(scene.name);
        sceneObjectReferences.SetActive(active);
    }
}
