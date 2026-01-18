![](2-no-48-no-more-islamic-republic.png)
## **IRAN IS BLEEDING --- AND THE WORLD IS SILENT**
BEGIN OF UPDATE: 2026-01-18

**The Slaughterer and Tyranny Regime of Mullahs is Slaughtering their protesting Nation and the Media was silent for a very long time!**

This Regime has killed at least 12000+ protestors in 48 hours (8th - 9th Jan. 2026),
after turning off the internet, Mobile-net, telephone-net and even electricity and the started to 
disturb the satellite frequencies by military jammers from china, to also turn off the internet connection through Starlink!

But some brave people which traveled to abroud smuggled a lot of images and videos, but also figures/statistics collected
by brave doctors in Iran. The figures/numbers currently after three weeks of protesting are:
- Death toll: 60000+
- Blined: 8000+

When the family of killed protestors try to get the dead body, they have to pay the "bullet-price" of 5000 to 7000 USD!
An average worker earns about 100 to 200 USD per month!

**The bodies of those whose relatives cannot afford the bullet-price are buried in mass graves without names or any other identifying information or markings at unknown locations.**

Car and ferniture are also confiscated.

**Now, after 120+ hours of internet-shuttdown, they turn it for some time on to transfere their BitCoins to wallets out of iran!**
[Netblocks.org Iran](https://mastodon.social/@netblocks/115916598029882510)

END OF UPDATE.


![State Diagram](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/Revertible.svg?sort=semver)](https://github.com/pediRAM/Revertible/releases)
[![NuGet](https://img.shields.io/nuget/v/Revertible)](https://www.nuget.org/packages/Revertible)

This is the english documentation. Following translations are available:
- [普通话 (Mandarin) :cn:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Mandarin.md)
- [Español :es:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Spanish.md)
- [Pусский :ru:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Russian.md)
- [Deutsch :de: :austria: :switzerland:](https://github.com/pediRAM/Revertible/blob/main/Documentation/German.md)
- [हिंदी :india:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Hindi.md)
- [Türkçe :tr:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Turkish.md)
- [فارسی :iran: :afghanistan: :tajikistan:](https://github.com/pediRAM/Revertible/blob/main/Documentation/Farsi.md)


# Revertible
Facilitates defining classes with **Revertible Properties**. 

- [Revertible](#revertible)
  - [Features](#features)
  - [Use Case](#use-case)
  - [How It Works](#how-it-works)
    - [State Diagram / Timeline](#state-diagram--timeline)
  - [UML Class Diagram](#uml-class-diagram)
  - [Example Code](#example-code)

## Features
- **[Revertible]** Attribute: Marks properties in a class as revertible.
- **SaveRevertibleProperties()**: Saves the current values of revertible properties.
- **RevertRevertibleProperties()**: Reverts revertible properties to their saved values (if any).
- **HasModifiedRevertibleProperties** (Boolean): Indicates if any revertible property's value has been changed.

## Use Case
Ideal for scenarios where you need to simply revert all changed values, like user-modified settings, without saving the changes to the model or file.

## How It Works
### State Diagram / Timeline
After instantiating a type that extends **BaseRevertible** and includes properties annotated with **[Revertible]**, you can save the current state of the revertible properties to revert them later if needed.

As shown in the diagram below, at state 5, when the revert method is invoked, the values are reverted/set back to the previously saved values at state 3 (t2 == t1).

**Note:** Properties without the **[Revertible]** annotation are always ignored.

![State Diagram](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Timeline.drawio.png)

## UML Class Diagram
To make your class revertible, simply extend **BaseRevertible** and annotate the properties you want to be revertible with the **[Revertible]** attribute:

![UML Class Diagram](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Klassendiagramm.png)

## Example Code
Here's a simple example of making a class revertible:
```cs
using Revertible;

// Assigning [Revertible] to the class is optional,
// unless you need to access IRevertible methods outside the class.
[Revertible]
public class RevertibleClass : BaseRevertible
{
    // Just assign [Revertible] to the properties you want to save and revert.
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

    // Properties without [Revertible] are ignored
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** Save and Revert values ***/
// 
private RevertibleClass _revertibleField = new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";

    // Save current state of revertible properties:
    _revertibleField.SaveRevertibleProperties();

    // Some other code...
    _revertibleField.Enabled = false;
    _revertibleField.Name = "Something else!";

    // Revert values of revertible properties:
    _revertibleField.RevertRevertibleProperties();
    // Now: Enabled == true and Name == "John Doe".
}
```

