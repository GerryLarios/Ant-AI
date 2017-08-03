﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Evade : MonoBehaviour {      public float radius;     public LayerMask searchLayers;     public string tagToLookFor;     public Collider2D closest;     float distance;      void Start()     {         //Detecting();     }  	void DoAIBehaviour()     {         Detecting();                  if (closest == null)         {             return; //We have nothing to eat;         }          Vector3 direction = closest.transform.position - this.transform.position;         direction *= -1; //We are running away from "closest";          float weight = 10 / (distance * distance);          WeightedDirection wd = new WeightedDirection(direction, weight);         GetComponent<Insects>().desiredDirections.Add(wd);     }      void Detecting()     {         var objectsHit = Physics2D.OverlapCircleAll(this.transform.position,radius,searchLayers);         closest = null;         float dist = Mathf.Infinity;          foreach (var item in objectsHit)         {             if (item.CompareTag(tagToLookFor))             {                 float d = Vector3.Distance(this.transform.position, item.transform.position);                 if(closest == null || d < dist)                 {                     closest = item;                     dist = d;                 }             }         }          distance = dist;     } } 