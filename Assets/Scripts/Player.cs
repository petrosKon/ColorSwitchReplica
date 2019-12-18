using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan, colorYellow, colorMagenta, colorPink;

    private void Start()
    {
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        int index = UnityEngine.Random.Range(0, 4);

        switch (index)
        {
            case 0:

                currentColor = "Cyan";
                sr.color = colorCyan;
                break;

            case 1:

                currentColor = "Yellow";
                sr.color = colorYellow;
                break;

            case 2:

                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;

            case 3:

                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collider.gameObject);
            return;
        }

        if(collider.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log(collider.tag);
    }
}
