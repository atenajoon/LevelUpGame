using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpark : MonoBehaviour
{
    public ParticleSystem spark;

    void Start()
    {
        spark.Emit(Random.Range(1, 3));
    }
}
