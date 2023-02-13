# Facilities

This file logs the development of facility modules in the **Reve** studio.

## Unity Editor Facilities
### Read-only Field Attribute for Inspector 
#### Background
The inspector in the Unity editor can only automatically display public members in the class. It doesn't work on properties such as the following code.
``` c#
public float Health {get; set;}
```
To display the property in the inspector, we can generate a private member variable for the class and annotate it with the `SerializeField` attribute, like the following code.
``` c#
public float Health {get => this._health; set=>this._health = value;}
[SerializeField]
private float _health = 0;
```
Or by doing this:
```
[field: SerializeField]
public float Health {get; set;}
```

The `[xxx]` is an attribute. Attributes are used to attach metadata to the class. The metadata is used to provide additional information and context for program elements, which can be used to modify their behavior or appearance at compile-time or runtime.

#### Development

We need to generate two classes to create the "read-only field" attribute. One is the attribute itself. Another is the field drawer used to display the data which owns the attribute in a read-only form.
```
[System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class ReadOnlyFieldAttribute : PropertyAttribute { }
```

```



```





