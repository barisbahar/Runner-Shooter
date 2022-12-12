using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int kill;
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            Destroy(gameObject);
            Destroy(other.gameObject);
            //OUTPUT
            int x = GameManager.instance.AddScore(kill);
            Debug.Log(x);
        }
    }

}
