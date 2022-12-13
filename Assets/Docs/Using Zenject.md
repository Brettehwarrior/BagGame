To avoid using the singleton pattern, Zenject was added to the project. Zenject is a plugin/library that allows for Dependency Injection in Unity.

Full documentation in the very long readme: https://github.com/modesttree/Zenject
This tutorial outlines a few of the use cases pretty well: https://youtu.be/Bcj35ceGCn0

# Singleton vs. Dependency Injection

The main advantages of using Dependency Injection over singletons are:
- Classes won't rely on concrete implementations of globally accessible instances
- Project and Scene specific contexts can be made to guarantee certain objects are always loaded when running any scene, or a specific scene in the project
- It's cool

This was how a singleton is usually implemented:
```cs
public class SingletonExample : MonoBehaviour  
{
	public static SingletonExample Instance { get; private set; }

	private void Awake()  
	{  
	    if (Instance == null)  
	    {
		    Instance = this;  
	    }
	    else  
	    {  
	        Destroy(gameObject);  
	    }
	}
}
```

Using Zenject it can be implemented like this

# Issues
For any object created at runtime that needs dependency injections (i.e. anything with the `[Inject]` attribute spawned after a scene is already loaded), injections will not work using the usual Unity `GameObject.Instantiate()` methods. Instead, a factory needs to be created which Zenject will use to handle injecting before instantiation. Zenject has a recommended method 
See this video for help setting this up: https://youtu.be/Gp2_8ihvnvA
