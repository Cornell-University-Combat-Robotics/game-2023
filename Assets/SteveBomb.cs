using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveBomb : MonoBehaviour
{

  private float _bombTimer = 2f;

  private Collider2D _explosionCollider;

  IEnumerator BombAnimation()
  {
    yield return new WaitForSeconds(_bombTimer);
    GetComponent<Collider2D>().enabled = false;
    GetComponent<ParticleSystem>().Play();
    _explosionCollider.enabled = true;
    GetComponent<SpriteRenderer>().enabled = false;
    yield return new WaitForFixedUpdate();
    _explosionCollider.enabled = false;
    yield return new WaitForSeconds(3f);
    Destroy(this);
  }

  void Start()
  {
    _explosionCollider = transform.GetChild(0).gameObject.GetComponent<Collider2D>();
    _explosionCollider.enabled = false;
    StartCoroutine(BombAnimation());
  }
}
