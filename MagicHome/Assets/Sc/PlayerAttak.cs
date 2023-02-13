using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttak : MonoBehaviour
{
    public int AttakName;
    public int[] AttakNames;
    [SerializeField] private GameObject _weapond;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _startTimeBtwShots;
    private bool _TimeBtwShots = true;
    public GameObject[] magicAtaks;
    [SerializeField] private GameObject player;
    public GameObject atakButtn;
    public GameObject atakButtnIn;
    public GameObject atakJoystick;
    public GameObject aim;
    [SerializeField] private GameObject[] _displayingAbilities;
    [SerializeField] private GameObject Abilities;




    public void Start()
    {
        _displayingAbilities = new GameObject[3];
        AttakNames = new int[3];
    }
    public void Attak()
    {
       
        switch (AttakNames[0], AttakNames[1], AttakNames[2])
        {
            case (1,1,1):
                if (_TimeBtwShots == true)
                {
                    Instantiate(magicAtaks[0], player.transform.position, player.transform.rotation);
                    _startTimeBtwShots = 3f;
                    _TimeBtwShots = false;
                    StartCoroutine(LvTame());
                }
                
                break;
            case (1, 2, 1):
                atakButtn.SetActive(false);
                atakJoystick.SetActive(true);
                aim.SetActive(true);
                atakButtnIn.SetActive(true);
                aim.transform.position = player.transform.position;
                break;
            case (1, 2, 2):
                if (_TimeBtwShots == true  )
                {                
                Instantiate(magicAtaks[2], _shotPoint.position, _weapond.transform.rotation);
                    _TimeBtwShots = false;
                    _startTimeBtwShots = 0.1f;
                    StartCoroutine(LvTame());
                }
                
                break;

            default:
                break;

        }
        for (int i = 0; i < AttakNames.Length; i++)
        {
            AttakNames[i] = 0;
        }
        AttakName = 0;
    }
    private IEnumerator LvTame()
    {
        
        yield return new WaitForSeconds(_startTimeBtwShots);
        _TimeBtwShots = true;
    }


    public void Recharge()
    {
        
        atakButtn.SetActive(true);
        atakJoystick.SetActive(false);
        aim.SetActive(false);
        atakButtnIn.SetActive(false);
    }
    public void MagBild(int Zac) 
    {
        if (AttakName < 3)
        {
            _displayingAbilities[AttakName] = Abilities;
            AttakNames[AttakName] = Zac;
            AttakName++;

        }
        

     
    }

}
