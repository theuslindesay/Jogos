using UnityEngine;

public class ColetarMoeda2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moeda 2D coletada!");

            if (GameManager.instance != null)
            {
                GameManager.instance.AddCoin();
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado na cena! A contagem de vitória não vai funcionar.");
            }

            Destroy(gameObject);
        }
    }
}
