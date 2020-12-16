using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    [SerializeField] private Transform[] shootPointsL;
    [SerializeField] private Transform[] shootPointsR;
    private bool currentEye = false;
    Vector3 _instantiateLocation;

    [SerializeField] private GameObject Projectile;
    public int shootDirection;
    [SerializeField] private float shootDelay;
    private float shootTimer;
    [SerializeField] private Animator shootAnim;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        
    }

    void Update()
    {
        shootTimer -= 1f * Time.deltaTime;
        if (shootTimer <= 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                shootDirection = 1;
                Shoot(0);
                playRandomAudio();
                shootAnim.SetTrigger("ShootDown");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                shootDirection = 2;
                Shoot(1);
                playRandomAudio();
                shootAnim.SetTrigger("ShootRight");
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                shootDirection = 3;
                Shoot(2);
                playRandomAudio();
                shootAnim.SetTrigger("ShootLeft");
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                shootDirection = 4;
                Shoot(3);
                playRandomAudio();
                shootAnim.SetTrigger("ShootUp");
            }
            
            
        }
        //Debug.Log(shootTimer);
    }

    void playRandomAudio()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    void Shoot(int _shootpoint)
    {
        
        if (currentEye == false)
        {
            Vector3 _instantiateLocation = new Vector3(shootPointsL[_shootpoint].transform.position.x, shootPointsL[_shootpoint].transform.position.y, shootPointsL[_shootpoint].transform.position.z);
            currentEye = true;
            Instantiate(Projectile, _instantiateLocation, this.gameObject.transform.rotation);
        }
        else if (currentEye == true)
        {
            Vector3 _instantiateLocation = new Vector3(shootPointsR[_shootpoint].transform.position.x, shootPointsR[_shootpoint].transform.position.y, shootPointsR[_shootpoint].transform.position.z);
            currentEye = false;
            Instantiate(Projectile, _instantiateLocation, this.gameObject.transform.rotation);
        }
        //Instantiate(Projectile, _instantiateLocation, this.gameObject.transform.rotation);
        shootTimer = shootDelay;
    }
}
