using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explosionGenerator : MonoBehaviour
{
    public GameObject explosionprefab;

    public float radius = 0.2f;

    public Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }
    
    public Quaternion RandomRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
    public void CreateObject()
    {
        Vector2 position = GetRandomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = RandomRotation();
    }
    public GameObject GetObject()
    {
        return Instantiate(explosionprefab);
    }

}
