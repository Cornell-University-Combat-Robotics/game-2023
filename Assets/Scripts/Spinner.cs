using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Spinner : MonoBehaviour
{
    public ParticleSystem Sparks;

    private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Sparks.transform.position = (other.transform.position + transform.position) / 2;
        Sparks.Play();
    }

}
