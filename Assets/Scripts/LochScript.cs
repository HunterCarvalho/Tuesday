using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LochScript : MonoBehaviour
{
    public GameObject Player;

    public bool flip;
    public float speed;

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (Player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime, y: 0, z: 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

    }
}
