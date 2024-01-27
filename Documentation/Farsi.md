![State Diagram](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/Revertible.svg?sort=semver)](https://github.com/pediRAM/Revertible/releases)
[![NuGet](https://img.shields.io/nuget/v/Revertible)](https://www.nuget.org/packages/Revertible)

***توجه : محتوای تولیدشده توسط هوش مصنوعی – این مستندات توسط ChatGPT-4 از نسخه انگلیسی ترجمه شده است.***

# قابل بازگشت (Revertible)
تسهیل تعریف کلاس‌ها با **ویژگی‌های قابل بازگشت (Revertible Properties)**.

- [قابل بازگشت (Revertible)](#قابل-بازگشت-revertible)
  - [ویژگی‌ها](#ویژگیها)
  - [مورد استفاده](#مورد-استفاده)
  - [چگونگی کارکرد](#چگونگی-کارکرد)
    - [نمودار حالت / خط زمان](#نمودار-حالت--خط-زمان)
  - [نمودار کلاس UML](#نمودار-کلاس-uml)
  - [کد نمونه](#کد-نمونه)

## ویژگی‌ها
- **ویژگی [Revertible]**: علامت‌گذاری ویژگی‌ها در یک کلاس به عنوان قابل بازگشت.
- **SaveRevertibleProperties()**: ذخیره مقادیر فعلی ویژگی‌های قابل بازگشت.
- **RevertRevertibleProperties()**: بازگرداندن ویژگی‌های قابل بازگشت به مقادیر ذخیره شده (در صورت وجود).
- **HasModifiedRevertibleProperties** (بولین): نشان دادن اینکه آیا مقدار هر ویژگی قابل بازگشت تغییر کرده است.

## مورد استفاده
ایده‌آل برای سناریوهایی که نیاز دارید تمام مقادیر تغییر یافته، مانند تنظیمات تغییر یافته توسط کاربر، را بدون ذخیره تغییرات در مدل یا فایل بازگردانید.

## چگونگی کارکرد
### نمودار حالت / خط زمان
پس از نمونه‌سازی یک نوع که **BaseRevertible** را گسترش می‌دهد و شامل ویژگی‌هایی با علامت‌گذاری **[Revertible]** است، می‌توانید وضعیت فعلی ویژگی‌های قابل بازگشت را ذخیره کنید تا در صورت نیاز بعداً آنها را بازگردانید.

همانطور که در نمودار زیر نشان داده شده است، در حالت 5، زمانی که متد بازگشت فراخوانی می‌شود، مقادیر به مقادیر قبلی ذخیره شده در حالت 3 (t2 == t1) بازمی‌گردند.

**توجه:** ویژگی‌هایی که علامت‌گذاری **[Revertible]** ندارند همیشه نادیده گرفته می‌شوند.

![نمودار حالت](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Timeline.drawio.png)

## نمودار کلاس UML
برای قابل بازگشت کردن کلاس خود، تنها کافی است **BaseRevertible** را گسترش دهید و ویژگی‌هایی که می‌خواهید قابل بازگشت باشند را

 با ویژگی **[Revertible]** علامت‌گذاری کنید:

![نمودار کلاس UML](https://raw.githubusercontent.com/pediRAM/Revertible/main/Documentation/Klassendiagramm.png)

## کد نمونه
در اینجا یک مثال ساده برای قابل بازگشت کردن یک کلاس آورده شده است:
```cs
با استفاده از Revertible؛

// اختصاص دادن [Revertible] به کلاس اختیاری است،
// مگر اینکه نیاز داشته باشید که متدهای IRevertible را از خارج کلاس دسترسی داشته باشید.
[Revertible]
public class RevertibleClass : BaseRevertible
{
    // فقط [Revertible] را به ویژگی‌هایی که می‌خواهید ذخیره و بازگردانید اختصاص دهید.
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

    // ویژگی‌هایی که [Revertible] نیستند نادیده گرفته می‌شوند
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** ذخیره و بازگردانی مقادیر ***/
// 
private RevertibleClass _revertibleField = new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";

    // ذخیره وضعیت فعلی ویژگی‌های قابل بازگشت:
    _revertibleField.SaveRevertibleProperties();

    // برخی کدهای دیگر...
    _revertibleField.Enabled = false;
    _revertibleField.Name = "Something else!";

    // بازگرداندن مقادیر ویژگی‌های قابل بازگشت:
    _revertibleField.RevertRevertibleProperties();
    // حالا: Enabled == true و Name == "John Doe".
}
```
