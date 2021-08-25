using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("/GameObjects/Player").GetComponent<PlayerController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        playerController.setCanCreateSpringBox(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playerController.setCanCreateSpringBox(true);
    }
}
