using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public GameObject bullet;

    public float speed;

    private void Update()
    {
        FireShoot();
        InputMove();
        return;
    }

    private void FireShoot()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(this.bullet, this.transform.position, this.transform.rotation);
        }

        return;
    }

    private void InputMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        }

        return;
    }
}
