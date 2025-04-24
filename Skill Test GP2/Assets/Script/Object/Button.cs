using System.Collections;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject door;
    bool IsOpen;

    private void Awake()
    {
        IsOpen = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            scoreText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Player>().IsInteracting)
        {
            Debug.Log("open");
            StartCoroutine(Open());
        }
    }


    IEnumerator Open()
    {
        IsOpen = !IsOpen;
        door.SetActive(IsOpen);
        transform.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        transform.GetComponent<Collider>().enabled = true;
    }
}
