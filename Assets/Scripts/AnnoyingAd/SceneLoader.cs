using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventSystem;
    public void LoadRelatedScene(string scene)
    {
        eventSystem.SetActive(false);
        MMTimeManager.Instance.SetTimeScaleTo(0f);
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
    public void UnloadRelatedScene(string scene)
    {
        MMTimeManager.Instance.SetTimeScaleTo(MMTimeManager.Instance.NormalTimeScale);
        SceneManager.UnloadSceneAsync(scene);
    }
}
