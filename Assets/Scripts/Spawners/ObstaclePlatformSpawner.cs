using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System;
using UnityEngine;

public class ObstaclePlatformeSpawner : TimedSpawner
{
    protected int nextindex = 0;
    public float addedXOffset = 24f;
    public float min_addedYOffset = 0f;
    public float max_addedYOffset = 2f;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Spawn()
    {
        GameObject nextGameObject = ObjectPooler.GetPooledGameObject();

        // mandatory checks
        if (nextGameObject == null) { return; }
        if (nextGameObject.GetComponent<MMPoolableObject>() == null)
        {
            throw new Exception(gameObject.name + " is trying to spawn objects that don't have a PoolableObject component.");
        }
        // we position the object
        nextGameObject.transform.position = this.transform.position + DetermineNextPosition();

        // we activate the object
        nextGameObject.gameObject.SetActive(true);
        nextGameObject.gameObject.MMGetComponentNoAlloc<MMPoolableObject>().TriggerOnSpawnComplete();

        // we check if our object has an Health component, and if yes, we revive our character
        Health objectHealth = nextGameObject.gameObject.MMGetComponentNoAlloc<Health>();
        if (objectHealth != null)
        {
            objectHealth.Revive();
        }

        // we reset our timer and determine the next frequency
        _lastSpawnTimestamp = Time.time;
        DetermineNextFrequency();

    }

    private Vector3 DetermineNextPosition()
    {
        float RandomYValue = UnityEngine.Random.Range(min_addedYOffset, max_addedYOffset);
        Vector3 Xoffset = new(addedXOffset * nextindex, 0f, 0f);
        Vector3 Yoffset = new(0f, RandomYValue, 0f);
        nextindex++;
        Vector3 Offset = new(Xoffset.x, Yoffset.y, 0f);
        return Offset;
    }
    public void ResetIndex()
    {
        nextindex = 0;
    }
}