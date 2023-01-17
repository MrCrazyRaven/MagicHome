using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttak : MonoBehaviour
{
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
    public enum magicAtak
    {
        fireball = 1,
        bubble = 2,
        bullet = 3
    }
    
    public magicAtak mAtak;

    public void AttakType(int value)
    {
        switch (value)
        {
            case 0:
                mAtak = magicAtak.fireball;
                break;
            case 1:
                mAtak = magicAtak.bubble;
                break;
            default:
                mAtak = magicAtak.bullet;
                break;
        }
        
    }
    
    public void Attak()
    {
        switch (mAtak)
        {
            case magicAtak.bullet:
                if (_TimeBtwShots == true)
                {
                    Instantiate(magicAtaks[0], player.transform.position, player.transform.rotation);
                    _startTimeBtwShots = 3f;
                    _TimeBtwShots = false;
                    StartCoroutine(LvTame());
                }
                
                break;
            case magicAtak.bubble:
                atakButtn.SetActive(false);
                atakJoystick.SetActive(true);
                aim.SetActive(true);
                atakButtnIn.SetActive(true);
                aim.transform.position = player.transform.position;
                break;
            case magicAtak.fireball:
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
}
