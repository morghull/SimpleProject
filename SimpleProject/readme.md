**Структура проекту:**

* /DataObjects/ - містить класи, що описують дані, та класи, що слугують для генерації початкових даних
* /Helpers/ - містить класи "помічники", для зберігання даних у xml-файл, читання даних з xml-файлу, зберігання налаштувань для параметрів класу тощо
* /Interfaces/ - містить класи інтерфейсів
* /Resources/ - містить медіа контент: картинки для кнопок та іконки

Для того, щоб розібратись у програмному коді використовуйте або пошукові сервіси або ChatGPT




Головним файлом проекту є `Program.cs`.
```
static void Main()
        {
        .
        .
        .
        }
```
Функція **Main()** у ньому запускає головну форму `frmMain.cs`:

```
Application.Run(new frmMain());
```

![Add button](/Resources/24px_png_add.png)
![Add button](/Resources/24px_png_edit.png)
![Add button](/Resources/24px_png_save.png)
![Add button](/Resources/24px_png_replace.png)