using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;
using MoreMountains.CorgiEngine;
using Unity.VisualScripting;

public class BackGroundSpawner : TimedSpawner
{
    protected int nextindex = 0;
    public float addedXOffset = 24f;
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
        Vector3 offset = new Vector3(addedXOffset * nextindex, 0f, 0f);
        nextindex++;
        return offset;
    }
    public void ResetIndex()
    {
        nextindex = 0;
    }
}