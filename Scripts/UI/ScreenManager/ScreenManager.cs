﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ScreenManager : Singleton<ScreenManager>
{

	private static ScreenManager _instance;
	
	public BaseScreen openingScreen;
	
	private Dictionary<Type, BaseScreen> screens;
	
	private Stack<BaseScreen> screenStack;
	
	private void Awake ()
	{	
		screens = new Dictionary<Type, BaseScreen> ();
		screenStack = new Stack<BaseScreen> ();
		
		foreach (BaseScreen screen in GetComponentsInChildren<BaseScreen>(true)) {
            if (!screens.ContainsKey(screen.GetType ())) {

                screens.Add (screen.GetType (), screen);
                screen.gameObject.SetActive (false);
            }
		}
		instance.Push (openingScreen.GetType ());
	}
	
	public T Push<T> () where T : BaseScreen
	{
		return Push (typeof(T)) as T;
	}
	
    public BaseScreen Push (Type screenType)
	{
        BaseScreen screen;

        if(screens.ContainsKey(screenType))
        {
            screen = screens [screenType];
        }
        else
        {
            UnityEngine.Object[] screenPrefabs = Resources.LoadAll("UI/Screens/", screenType);
            BaseScreen baseScreen = screenPrefabs[0] as BaseScreen;

            GameObject obj = GameObject.Instantiate(baseScreen.gameObject) as GameObject;
            obj.transform.SetParent(this.transform, false);
            obj.SetActive(false);

            screens.Add(screenType, obj.GetComponent<BaseScreen>());
            screen = screens[screenType];
        }
		
		if (screenStack.Count != 0) {
			screenStack.Peek ().OnLeave (screen);
		}
		
		screenStack.Push (screen);
		screen.OnPush ();
		
		return screen;
	}
	
	public void Pop ()
	{
		BaseScreen screen = screenStack.Pop ();
		screen.OnPop ();
		screenStack.Peek ().OnReturn (screen);
	}
	
}
