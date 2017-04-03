using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

    public float speed;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    void MoveParallax(float playerMovement)
    {
        render.material.mainTextureOffset = new Vector2(Time.time * speed * playerMovement, 0);
    }
}
