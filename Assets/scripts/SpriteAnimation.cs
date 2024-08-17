using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] frames; // Array of sprites for the animation
    public float framesPerSecond = 10f; // Animation speed

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());

        Destroy(gameObject, 1);
    }

    IEnumerator PlayAnimation()
    {
        int currentFrame = 0;

        while (currentFrame < frames.Length)
        {
            // Set the sprite to the current frame
            spriteRenderer.sprite = frames[currentFrame];

            Color tmp = spriteRenderer.color;
            tmp.a = 1f - (currentFrame/10);
            spriteRenderer.color = tmp;

            // Wait for the next frame based on the speed
            yield return new WaitForSeconds(1f / framesPerSecond);

            // Move to the next frame, looping back if necessary
            currentFrame = (currentFrame + 1) % frames.Length;
        }
    }
}