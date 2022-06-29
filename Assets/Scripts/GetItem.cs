using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public Text scoreTxt;
    private int score;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Cachecol") == true){
            Destroy(col.gameObject);
        }
    }
}
