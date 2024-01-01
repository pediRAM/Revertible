***AVISO IMPORTANTE: Contenido Generado por IA - Esta documentación ha sido traducida por ChatGPT-4 de la versión en inglés.***

# Revertible
Facilita la definición de clases con **Propiedades Revertibles**.

- [Revertible](#revertible)
  - [Características](#características)
  - [Caso de Uso](#caso-de-uso)
  - [Cómo Funciona](#cómo-funciona)
    - [Diagrama de Estado / Cronología](#diagrama-de-estado--cronología)
  - [Diagrama de Clase UML](#diagrama-de-clase-uml)
  - [Código de Ejemplo](#código-de-ejemplo)

## Características
- **Atributo [Revertible]**: Marca propiedades en una clase como revertibles.
- **SaveRevertibleProperties()**: Guarda los valores actuales de las propiedades revertibles.
- **RevertRevertibleProperties()**: Revierte las propiedades revertibles a sus valores guardados (si los hay).
- **HasModifiedRevertibleProperties** (Booleano): Indica si el valor de alguna propiedad revertible ha sido cambiado.

## Caso de Uso
Ideal para escenarios donde necesitas simplemente revertir todos los valores cambiados, como configuraciones modificadas por el usuario, sin guardar los cambios en el modelo o archivo.

## Cómo Funciona
### Diagrama de Estado / Cronología
Después de instanciar un tipo que extiende **BaseRevertible** e incluye propiedades anotadas con **[Revertible]**, puedes guardar el estado actual de las propiedades revertibles para revertirlas más tarde si es necesario.

Como se muestra en el diagrama a continuación, en el estado 5, cuando se invoca el método de revertir, los valores se revierten/se restablecen a los valores previamente guardados en el estado 3 (t2 == t1).

**Nota:** Las propiedades sin la anotación **[Revertible]** siempre son ignoradas.

![Diagrama de Estado](Timeline.drawio.png)

## Diagrama de Clase UML
Para hacer tu clase revertible, simplemente extiende **BaseRevertible** y anota las propiedades que deseas sean revertibles con el atributo **[Revertible]**:

![Diagrama de Clase UML](Klassendiagramm.png)

## Código de Ejemplo
Aquí hay un ejemplo simple de cómo hacer una clase revertible:
```cs
using Revertible;

// Asignar [Revertible] a la clase es opcional,
// a menos que necesites acceder a métodos IRevertible fuera de la clase.
[Revertible]
public class RevertibleClass : BaseRevertible
{
    // Simplemente asigna [Revertible] a las propiedades que quieras guardar y revertir.
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

    // Las propiedades sin [Revertible] son ignoradas
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** Guardar y Revertir valores ***/
// 
private RevertibleClass _revertibleField = new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";

    // Guardar el estado actual de las propiedades revertibles:
    _revertibleField.SaveRevertibleProperties();

    // Algun otro código...
    _revertibleField.Enabled = false;
    _revertibleField.Name = "Algo más!";

    // Revertir los valores de las propiedades revertibles:
    _revertibleField.RevertRevertibleProperties();
    // Ahora: Enabled == true y Name == "John Doe".
}
```
