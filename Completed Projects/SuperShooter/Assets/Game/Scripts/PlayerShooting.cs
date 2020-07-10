﻿
    using System;
    using UnityEngine;

    public class PlayerShooting : MonoBehaviour
    {
        void Start()
        {
            Debug.LogError("Testing Player Shooting Start");
        }
        
        Animator animator;

        public GameObject prefab;
        public GameObject shootPoint;
        public ParticleSystem muzzleEffect;
        public AudioSource shootSound;
        public int bulletsAmount;
        
        float lastShootTime;
        public float fireRate;
        
        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
            {
                Debug.Log("shoot");
                
                animator.SetBool("Shooting", true);

                var timeSinceLastShoot = Time.time - lastShootTime;
                if(timeSinceLastShoot < fireRate)
                    return;

                lastShootTime = Time.time;
                
                bulletsAmount--;
                muzzleEffect.Play();
                shootSound.Play();
                
                GameObject clone = Instantiate(prefab);
                clone.transform.position = shootPoint.transform.position;
                clone.transform.rotation = shootPoint.transform.rotation;
            }
            else
            {
                animator.SetBool("Shooting", false);
            }
        }
        
        void Awake()
        {
            animator = GetComponent<Animator>();
        }
    }
    
    