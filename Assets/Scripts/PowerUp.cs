using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioSource itemSound;
    public void Start()
    {
        switch(type)
        {
            case Type.ExtraLife:
                itemSound.Play();
                break;
            case Type.MagicMushroom:
                itemSound.Play();
                break;
            case Type.Starpower:
                itemSound.Play();
                break;
            case Type.PoisonMushroom:
                itemSound.Play();
                break;
            case Type.Clock:
                itemSound.Play();
                break;
        }
    }
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
        PoisonMushroom,
        Clock
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;

            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                player.GetComponent<Player>().Starpower();
                break;
            case Type.PoisonMushroom:
                player.GetComponent<Player>().Hit();
                break;
            case Type.Clock:
                GameManager.Instance.AddTime();
                break;
        }

        Destroy(gameObject);
    }

}
