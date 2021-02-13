using UnityEngine;
using System.Collections;

namespace SalaryMan.UI
{
    public class TabView : MonoBehaviour 
    {
        public void Init()
        {
            this.gameObject.SetActive(true);
        }

        private void Refresh()
        {
            
        }

        public void OnReturn()
        {
            this.gameObject.SetActive(true);
            this.Refresh();
        }

        public void OnLeave()
        {
            this.gameObject.SetActive(false);
        }
    }
}

