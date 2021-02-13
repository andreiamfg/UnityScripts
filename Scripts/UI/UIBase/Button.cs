using UnityEngine;
using System.Collections;

namespace SalaryMan.UI
{
    [AddComponentMenu("UI/Button")]
    public class Button : UnityEngine.UI.Button 
    {
        public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            Debug.Log("Clicked custom button");
        }
    }
}
