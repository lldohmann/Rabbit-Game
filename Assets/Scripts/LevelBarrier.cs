using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.NextLevel();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
