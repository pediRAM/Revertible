![State Diagram](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/Revertible.svg?sort=semver)](https://github.com/pediRAM/Revertible/releases)
[![NuGet](https://img.shields.io/nuget/v/Revertible)](https://www.nuget.org/packages/Revertible)

***ВАЖНОЕ ПРИМЕЧАНИЕ: Контент, сгенерированный искусственным интеллектом – Эта документация была переведена с помощью ChatGPT-4 с английского языка.***

# Возвратимый (Revertible)
Облегчает определение классов с **Возвратимыми Свойствами (Revertible Properties)**.

- [Возвратимый (Revertible)](#возвратимый-revertible)
  - [Особенности](#особенности)
  - [Пример использования](#пример-использования)
  - [Как это работает](#как-это-работает)
    - [Диаграмма состояний / Хронология](#диаграмма-состояний--хронология)
  - [Диаграмма классов UML](#диаграмма-классов-uml)
  - [Пример кода](#пример-кода)

## Особенности
- **Атрибут [Revertible]**: Отмечает свойства в классе как возвратимые.
- **SaveRevertibleProperties()**: Сохраняет текущие значения возвратимых свойств.
- **RevertRevertibleProperties()**: Возвращает возвратимые свойства к их сохраненным значениям (если таковые имеются).
- **HasModifiedRevertibleProperties** (Булево): Указывает, было ли изменено значение какого-либо возвратимого свойства.

## Пример использования
Идеально подходит для сценариев, когда вам нужно просто отменить все измененные значения, например, настройки, измененные пользователем, не сохраняя изменения в модели или файле.

## Как это работает
### Диаграмма состояний / Хронология
После создания экземпляра типа, который расширяет **BaseRevertible** и включает свойства, аннотированные как **[Revertible]**, вы можете сохранить текущее состояние возвратимых свойств, чтобы при необходимости вернуть их позже.

Как показано на диаграмме ниже, на шаге 5, когда вызывается метод возврата, значения возвращаются/устанавливаются обратно на ранее сохраненные значения на шаге 3 (t2 == t1).

**Примечание:** Свойства без аннотации **[Revertible]** всегда игнорируются.

![Диаграмма состояний](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Timeline.drawio.png)

## Диаграмма классов UML
Чтобы сделать ваш класс возвратимым, просто расширьте **BaseRevertible** и аннотируйте свойства, которые вы хотите сделать возвратимыми, используя атрибут **[Revertible]**:

![Диаграмма классов UML](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Klassendiagramm.png)

## Пример кода
Вот простой пример создания возвратимого класса:
```cs
используя Revertible;

// Присвоение [Revertible] классу является необязательным,
// если вам не нужно обращаться к методам IRevertible за пределами класса.
[Revertible]
public class RevertibleClass : BaseRevertible
{
    // Просто присвойте [Revertible] свойствам, которые вы хотите сохранить и вернуть.
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

    // Свойства без [Revertible] игнорируются
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** Сохранение и возврат значений ***/
// 
private RevertibleClass _revertibleField =

 new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";

    // Сохраните текущее состояние возвратимых свойств:
    _revertibleField.SaveRevertibleProperties();

    // Другой код...
    _revertibleField.Enabled = false;
    _revertibleField.Name = "Что-то другое!";

    // Верните значения возвратимых свойств:
    _revertibleField.RevertRevertibleProperties();
    // Теперь: Enabled == true и Name == "John Doe".
}
```
