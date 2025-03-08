using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventSystem;
    public string _scene;
    public void LoadRelatedScene()
    {
        eventSystem.SetActive(false);
        MMTimeManager.Instance.SetTimeScaleTo(0f);
        SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
    }
    public void UnloadRelatedScene()
    {
        GameObject[] persistentObjects = GameObject.FindGameObjectsWithTag("Persistent");
        foreach (GameObject obj in persistentObjects)
        {
            Destroy(obj);
        }
        SceneManager.UnloadSceneAsync(_scene);
        eventSystem.SetActive(true);
        MMTimeManager.Instance.SetTimeScaleTo(MMTimeManager.Instance.NormalTimeScale);
    }
}
