﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public bool invinsible = false;
	private float timeInvincible = 2f;
	float timer;
	public int killNumber = 0;
	
	Animator anim;
	AudioSource playerAudio;
	PlayerMovement playerMovement;
	PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;
		if (!invinsible) {
			timer = 0f;
		} else {
			if (timer >= timeInvincible) {
				timer = 0f;
				invinsible = false;
			}
		}
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		playerAudio.Play ();
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;
		
		playerShooting.DisableEffects ();
		
		anim.SetTrigger ("Die");
		
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		
		playerMovement.enabled = false;
		playerShooting.enabled = false;
	}
	
	
	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}

