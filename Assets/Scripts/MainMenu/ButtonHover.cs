using UnityEngine;
using UnityEngine.EventSystems;

internal class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [field: SerializeField] GameObject PlanetGif;
    public void OnPointerEnter(PointerEventData pointer)
    {
        if (!PlanetGif.activeInHierarchy)
            PlanetGif.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointer)
    {
        if (PlanetGif.activeInHierarchy)
            PlanetGif.SetActive(false);
    }
}