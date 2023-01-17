using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldIn : MonoBehaviour
{
    [SerializeField] private Text text;
    private int gold;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.onEnemyDied.AddListener(GoldUp);
    }

    // Update is called once per frame
    
    public void GoldUp()
    {
        gold++;
        text.text = "Gold = " + gold;
    } 
}
