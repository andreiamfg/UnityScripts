using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SalaryMan.UI
{
	public class TabViewController : MonoBehaviour 
	{
        [Serializable]
		public class Config
		{
            internal int        Id;
            public TabButton 	TabButton;
            public TabView 	    TabView;
		}

        private List<Config> _tabs = new List<Config>();

        private int _currentTab = -1;

        internal ITabViewDelegate Delegate;

        public void CreateTabs(List<Config> tabs, int defaultTab = 0)
        {
            _tabs = tabs;
            for (int i = 0; i < tabs.Count; i++)
            {
                int index = i;

                if (_tabs[i].TabView != null)
                {
                    _tabs[i].TabView.OnLeave();
                }

                if (_tabs[i].TabButton != null)
                {
                    _tabs[i].TabButton.onClick.AddListener(()=> {
                        TabButtonClick(index);
                    });
                }
            }

            SelectTab(defaultTab);
        }

        private void TabButtonClick(int index)
        {
            SelectTab(index);
        }

        public void SelectTab(int tab)
        {
            if (_currentTab == -1)
            {
                _currentTab = tab;
                // Select this tab
                _tabs[_currentTab].TabView.OnReturn();
                return;
            }

            if (tab == _currentTab)
            {
                return;
            }

            _tabs[_currentTab].TabView.OnLeave();
            Delegate.OnTabLoseFocus(_tabs[_currentTab]);

            _currentTab = tab;

            Delegate.OnTabWillGainFocus(_tabs[_currentTab]);
            _tabs[_currentTab].TabView.OnReturn();
        }
	}

    public interface ITabViewDelegate
    {
        void OnTabLoseFocus(TabViewController.Config lastTab);
        void OnTabWillGainFocus(TabViewController.Config newTab);
    }
}

