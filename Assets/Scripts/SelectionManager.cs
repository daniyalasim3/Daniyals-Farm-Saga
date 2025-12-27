using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;


public class SelectionManager : MonoBehaviour
{

    public GameObject InteractionUI;
    TextMeshProUGUI interaction_text;
    public bool cursorPointing;
    public static SelectionManager Instance { get; set; }
    private void Start()
    {
        cursorPointing = false;
        interaction_text = InteractionUI.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            var Interactable = hit.collider.GetComponentInParent<InteractableObject>();
            if (Interactable && Interactable.playerInRange)
            {
                interaction_text.text = Interactable.GetItemName();
                InteractionUI.SetActive(true);
                cursorPointing = true;
            }
            else
            {
                InteractionUI.SetActive(false);
                cursorPointing = false;
            }

        }
        else
        {
            InteractionUI.SetActive(false);
            cursorPointing = false;
        }
    }
}