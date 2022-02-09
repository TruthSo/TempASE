using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGeneratorController : MonoBehaviour
{
    private void FixedUpdate()
    {
        float x;
        float y;
        Vector2 pos;

        x = Random.Range(-8.0f, 8.0f);
        y = Random.Range(-4.0f, 4.0f);
        pos = new Vector2(x, y);

        //TODO: avoid overlapping

        ObjectPooler.Instance.SpawnFromPool("Circle", pos);
    }
}
