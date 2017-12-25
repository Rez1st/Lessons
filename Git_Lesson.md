#### Тема нашего урока - SVC(Source Version Control)

1. Что такое SVC? И Зачем он нужен?
2. Apache Subversion(SVN), Team Foundation Server(TFS) или Git?
3. Жизнь без SVC и с, какие проблемы решает?
4. Что бы вы делали без SVC, локально, как происходило бы версионирование?
5. Начало работы

  - Создаем аккаунт на https://github.com (Вдруг кому-то надо - https://git-scm.com/book/en/v2)
  - Формат имени при создании аккаунтов: level-{lastName}-{firstName}, без фигурных скобок пример: level-pupkin-vasiliy
  - SSH Ключи - зачем их использовать?
  - Загружаем и устанавливаем клиент: https://git-scm.com/


#### <Practice>

1 - В корне диска C:/ или D:/  создаем папку Projects - заходим в нее, созадаем папку git-practice,
​	заходим в нее.

2 - Выполняем команду **git init** [Создание пустого гит-репозитория или переинициализация существующего], у вас появится скрытая папка в корне(.git), которая внутри и будет хранить всю локальную историю, версии файлов и прочее необходимое Git для работы, удаление ее повлечет потерю локальных данных, не синхронизированных с Github репозиторием.

<!--А теперь представим, у вас есть задание - написать функцию деления одного цисла на другое, что мы и сделаем.-->

3 - Создадим текстовый файл file.js c таким содержимым:

``` javascript
function Devison(arg1, arg2)	{
  return arg1 / arg2;
}
```

4 - Выполним команду **git status**[Отображает статус в текущей ветке], а у нас (master) и увидим:

```
Untracked files:
(use "git add <file>..." to include in what will be committed)

file.js
```

​	git status нам показывает, что есть файл за изменениями которого git не следит и как видно предлагает выпонить комманду git add <file>.

5 - Выполним команду **git add** {full path from root folder with file name} [Добавление файла в текущий коммит], т.к мы находмися в корневом каталоге, то можем просто выполнить git add file.js

​	Если мы выполним git status сейчас, увидим следущую картину:

```
Changes to be committed:
(use "git rm --cached <file>..." to unstage)

      new file:   file.js

```
​	Как видите файл стал зеленого цвета и он "готов" к тому, чтобы мы его залили.

6 - Что мы и сделаем, **git commit** [Запись изменений в локальный репозиторий]  

​	И попадаем в VI редактор,  [Документация](https://www.cs.colostate.edu/helpdocs/vi.html)

​	Нажимаем [I](Button, stands for Insert)

​	И набираем краткий комментарий к тому, что вы сделали,

​	к примеру **"added division function"**

​	Далее, нажимаем [Esc](Escape button), и набираем такую комбинацию **:wq**

​	[Enter](Enter button)

​	Альтернативный быстрый путь: option **-m**

```
  git commit -m "added division function"
```

7 - Коммандой **git log** мы можем просмотреть историю комитов

<!--Допустим что этот файл - один из многих в Вашем проекте, и вот мы его сделали, молодцы, отдаем говорим что сделано, отдаем на проверку QA  -->

​	Через 10 минут ваш QA говорит - что есть баг 

``` javascript
Devison(2, 0);
```

​	Деление на 0

8 - Открываем наш файл file.js и добавляем проверку, теперь наш код выглядит вот так:
​	

``` javascript
function Devision(arg1, arg2)	{
  	if (arg2 == 0)
    {
      throw "Devision by zero"
    }
  
    return arg1 / arg2; 
}
```

​	git status после сохранения нам скажем вот что:
​	

```
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   file.js

no changes added to commit (use "git add" and/or "git commit -a")
```

​	После того как Git начал следить за файлом - мы можем увидеть что 							файл помечен как modified.

9 - Давайте посмотрим какие же изменения вы внесли,
комманда [**git diff**](Показывает изменения) покажет наши изменения.

10 - Сделаем то-же самое но в Visual Studio или в Visual Studio Code, добавим новый файл textFile2.txt

## <Conflict Resolve>

Смоделируем ситуацию конфликта...



### <In Addition>

- Замена встроенного текстового редактора VI:

  **git config core.editor notepad**


- Удобные клиенты для работы с SVC

    SourceTree,
    GitHub,
    TortoiseGit

- Так же можно использовать 

    VisualStudio,

    VisualStudioCode

- Замена стандартного инструмента Мерджа:

   git config merge.tool <program>

  tortoisemerge - удобная программа для разрешения конфликтов мерджа

  пример :  git config merge.tool tortoisemerge 

 
