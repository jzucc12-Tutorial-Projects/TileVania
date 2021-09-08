using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] int scoreAmount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().IncreaseScore(scoreAmount);
        Destroy(gameObject);
    }
}
