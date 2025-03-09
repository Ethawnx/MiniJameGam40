using MoreMountains.CorgiEngine;
using UnityEngine;

public class Respawn : AutoRespawn
{
    PlatformSpawner platformSpawner;
    BackGroundSpawner backGroundSpawner;
    ObstaclePlatformeSpawner obstaclePlatformeSpawner;
    protected override void Start()
    {
        base.Start();

        platformSpawner = GetComponent<PlatformSpawner>();
        backGroundSpawner = GetComponent<BackGroundSpawner>();
        obstaclePlatformeSpawner = GetComponent<ObstaclePlatformeSpawner>();
    }
    public override void OnPlayerRespawn(CheckPoint checkpoint, Character player)
    {
        base.OnPlayerRespawn(checkpoint, player);
        OutsideWorldGameManager.Instance.ResetGameValues();
        if (platformSpawner != null)
        {
            platformSpawner.ResetIndex();
            PlatformPoolabeObject[] platformgameObjects = GetComponentsInChildren<PlatformPoolabeObject>();
            foreach (PlatformPoolabeObject gameObject in platformgameObjects)
            {
                if (gameObject.isActiveAndEnabled)
                {
                    gameObject.Destroy();
                }
            }
        }
        if (backGroundSpawner != null)
        {
            backGroundSpawner.ResetIndex();
            BackGroundPoolableObject[] platformgameObjects = GetComponentsInChildren<BackGroundPoolableObject>();
            foreach (BackGroundPoolableObject gameObject in platformgameObjects)
            {
                if (gameObject.isActiveAndEnabled)
                {
                    gameObject.Destroy();
                }
            }
        }
        if (obstaclePlatformeSpawner != null)
        {
            obstaclePlatformeSpawner.ResetIndex();
            ObstaclePlatformPoolableObject[] platformgameObjects = GetComponentsInChildren<ObstaclePlatformPoolableObject>();
            foreach (ObstaclePlatformPoolableObject gameObject in platformgameObjects)
            {
                if (gameObject.isActiveAndEnabled)
                {
                    gameObject.Destroy();
                }
            }
        }
    }
}
