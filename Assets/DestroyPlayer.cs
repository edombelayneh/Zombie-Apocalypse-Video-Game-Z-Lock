using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // target impact on game
    public int scoreAmount = 0;
    public int healthPoints = 0;
    public float timeAmount = 0.0f;

    // explosion when hit?
    public GameObject explosionPrefab;
    // SFX when hit?
    public AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D newnCollision)
    {

        if (newnCollision.gameObject.CompareTag("Player"))
        {

            if (soundEffect)
            {
                // if the SFX is provided, play it
                Debug.Log("Played the SFX");
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }

            // if game manager exists, make adjustments based on target properties
            if (GameManager.gm)
            {

                GameManager.gm.targetHit(scoreAmount, timeAmount, healthPoints);

            }

            // destroy self
            Destroy(gameObject);
        }

    }
}
// when collided with another gameObject
//    void OnCollisionEnter(Collision newCollision)
//    {
//        // only do stuff if collided with the Player
//        if (newCollision.gameObject.CompareTag("Player"))
//        {
//            if (explosionPrefab)
//            {
//                // Instantiate an explosion effect at the gameObjects position and rotation
//                Instantiate(explosionPrefab, transform.position, transform.rotation);
//            }
//            if (soundEffect)
//            {
//                // if the SFX is provided, play it
//                Debug.Log("Played the SFX");
//                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
//            }

//            // if game manager exists, make adjustments based on target properties
//            if (GameManager.gm)
//            {

//                GameManager.gm.targetHit(scoreAmount, timeAmount, healthPoints);

//            }

//            // destroy self
//            Destroy(gameObject);
//        }
//    }
//}
