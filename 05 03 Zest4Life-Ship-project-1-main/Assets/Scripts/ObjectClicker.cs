using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private GameObject mainBuildingMenu;
    [SerializeField] private GameObject villagerHouseMenu;
    [SerializeField] private GameObject oilTowerMenu;
    [SerializeField] private GameObject storageMenu;
    [SerializeField] private GameObject docksMenu;

    [SerializeField] private AudioManager audioManager;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider)
                {
                    audioManager.Play("OpenMenu");
                    
                    mainBuildingMenu.SetActive(hit.collider.CompareTag("MainBuilding"));
                    villagerHouseMenu.SetActive(hit.collider.CompareTag("VillagerHouse"));
                    oilTowerMenu.SetActive(hit.collider.CompareTag("OilTower"));
                    storageMenu.SetActive(hit.collider.CompareTag("Storage"));
                    docksMenu.SetActive(hit.collider.CompareTag("Docks"));
                }
            }

            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("CloseMenu")))
            {
                Debug.Log("ek");
                mainBuildingMenu.SetActive(false);
                villagerHouseMenu.SetActive(false);
                oilTowerMenu.SetActive(false);
                docksMenu.SetActive(false);
            }
        }
    }
}
