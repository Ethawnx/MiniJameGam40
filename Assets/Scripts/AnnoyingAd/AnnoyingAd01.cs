using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;
public class AnnoyingAd01 : MonoBehaviour
{
    public string SceneNameToTransition;

    public SceneLoader SceneLoaderObject;

    public void LoadRelatedScene()
    {
        SceneLoaderObject.LoadRelatedScene(SceneNameToTransition);
    }
}
