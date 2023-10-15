**Структура проекту:**

* /DataObjects/ - містить класи, що описують дані, та класи, що слугують для генерації початкових даних
* /Helpers/ - містить класи "помічники", для зберігання даних у xml-файл, читання даних з xml-файлу, зберігання налаштувань для параметрів класу тощо
* /Interfaces/ - містить класи інтерфейсів
* /Resources/ - містить медіа контент: картинки для кнопок та іконки

У тих випадках коли розібратись у програмному коді не вдалось, використовуйте або пошукові сервіси або ChatGPT




Головним файлом проекту є `Program.cs`.

Функція **Main()** у ньому запускає головну форму `frmMain.cs`

`frmMain.cs` має панель з кнопками та `DataGrid` для відображення.
Тут треба ввести такий термін як **Сутність**. Це термін для описання реального або умовного об'єкту з життя, наприклад: машина, людина, пацієнт, кіт тощо. У сутності в контексті программування ми повинні створити класс, а на основі цього классу - об'єкт - екземпляр классу.
Так от рядки у гріді формуються автоматично на основі властивостей класу сутності та аннотацій, що описують деякі опції цих властивостей.

`Детальну інформацію читайте у кожному класі цього проекту, там є коментарі.`

Щодо кнопок:
* ![Add button](/Resources/24px_png_add.png) - відкриває дочірню форму у режимі додавання нового запису
* ![Edit button](/Resources/24px_png_edit.png) - відкриває дочірню форму у режимі редагування
* ![Delete button](/Resources/24px_png_del.png) - видаляє вибрані рядки
* ![Save button](/Resources/24px_png_save.png) - зберігає таблицю у xml-файл
* ![Load button](/Resources/24px_png_replace.png) - читає дані з xml-файлу

Кнопки додавання та редагування запису відкривають дочірню форму `frmSub.cs` у певному режимі.
Елементи на формі, що відносяться до даних та з якими передбачається взаємодія користувача, формуються динамічно під час відкриття форми. Формування відбувається у відповідності до налаштувань, що отримані при зчитуванні классу сутності об'єектом екземпляром класу `EntitySettings`

Переваги такого підходу це те, що для переналаштування проекту на роботу з іншою сутністю достатньо створити класс для неї, описати цей клас за допомогою аннотацій, створити класс для ініціалізатора початкових даних та трошки змінити код головної форми, наприклад:
Реалізує функціональність з класом `Patient`:
```
    private EntitySettings<Patient> _entitySettings;
    private EntityHelper<Patient> _entityHelper;
    
    public frmMain()
    {
        InitializeComponent();
        _entitySettings = new EntitySettings<Patient>();
        PatiensDataInitializer dataInitializer = new PatiensDataInitializer();
        _entityHelper = new EntityHelper<Patient>(_entitySettings, dataInitializer);

        DataGridViewSetup();
        GetInitialData();
    }
```
Реалізує функціональність з класом `Movie`:
```
    private EntitySettings<Movie> _entitySettings;
    private EntityHelper<Movie> _entityHelper;
    
    public frmMain()
    {
        InitializeComponent();
        _entitySettings = new EntitySettings<Movie>();
        MoviesDataInitializer dataInitializer = new MoviesDataInitializer();
        _entityHelper = new EntityHelper<Movie>(_entitySettings, dataInitializer);

        DataGridViewSetup();
        GetInitialData();
    }
```