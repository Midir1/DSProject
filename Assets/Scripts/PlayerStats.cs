﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midir
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10, maxHealth, currentHealth, staminaLevel = 10, maxStamina, currentStamina;

        public HealthBar healthBar;
        StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        private void Awake()
        {
            staminaBar = FindObjectOfType<StaminaBar>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Death_01", true);
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina -= damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }
    }
}