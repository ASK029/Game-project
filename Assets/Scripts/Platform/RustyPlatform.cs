using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RustyPlatform : MonoBehaviour
{
    //initial duration before the platform dissapear
    public float initialDuration = 2f;
    //initial duration to reset the time after the platform dissapear
    public float resetDuration = 5f;

    public float shakeMagnitude = 0.1f;
    public TilemapRenderer tilemap2;
    private bool isActive = false;
    private bool isDissapear = false;
    private float timer;
    private float showTimer;
    private Vector2 originalPosition;
    #region Component
    private TilemapCollider2D tilemapCollider;
    private TilemapRenderer SR;
    #endregion
    void Start()
    {
        timer = initialDuration;
        showTimer = resetDuration;
        originalPosition = transform.position;
        tilemapCollider = GetComponent<TilemapCollider2D>();
        SR = GetComponent<TilemapRenderer>();
    }

    
    void Update()
    {
        if (isActive) {
            StartCoroutine(ShakeCube());
            timer -= Time.deltaTime;
            if (timer <= 0.1f)
            {
                DropPlatform();
            }
            if (timer <= 0f)
            {
                DropChunks();
            }
        }
        else if (isDissapear)
        {
            StopCoroutine(ShakeCube());
            showTimer -= Time.deltaTime;
            if (showTimer <= 0f)
            {
                ShowPlatform();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isActive)
            {
                isActive = true;
            }
        }
    }

    private void ShowPlatform()
    {
        tilemapCollider.enabled = true;
        SR.enabled = true;
        showTimer = resetDuration;
        isDissapear = false;
    }

    private void DropPlatform()
    {
        tilemapCollider.enabled = false;
        SR.enabled = false;
        isDissapear = true;
        tilemap2.enabled = true;
    }

    private void DropChunks()
    {
        timer = initialDuration;
        isActive = false;
        tilemap2.enabled = false;
    }

    private IEnumerator ShakeCube()
    {
        float elapsedTime = initialDuration;
        while (elapsedTime >= 0)
        {
            float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.position = originalPosition + new Vector2(offsetX, offsetY);
            elapsedTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
        print("hello ");
    }
}
