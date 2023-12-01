using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// wobbles the text characters
public class WobbleText : MonoBehaviour
{

    TMP_Text textMesh;
    Mesh mesh;
    Vector3[] vertices;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        
        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);
            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time * 5f), Mathf.Cos(time * 5f));
    }
}
