using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacaMuu : MonoBehaviour
{
    [SerializeField] private AudioClip muuu;
    [SerializeField] string colisor;
    [SerializeField] private float volumeMuuu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(muuu, volumeMuuu);
        }
    }
}
