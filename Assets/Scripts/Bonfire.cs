using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public Transform smoke;

    void Start () {
        ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
            var em = ps.emission;
            em.enabled = true;
            StartCoroutine (stopSmoke());

            other.GetComponent<PlayerController>().Burn();
        }
    }
    
    IEnumerator stopSmoke()
    {
        yield return new WaitForSeconds(.2f);
        ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;
    }
}
