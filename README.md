# ZombieShooter

**Автор**: Во Минь Тхиен Лонг.

## Обзор

Я построил этот проект на основе инструкции в этой [ссылка](https://habr.com/ru/company/otus/blog/485210/).

Для создания игры я использовал **Unity** с **C#**, а в качестве ассеты использовал из **Unity Asset Store**.

- [Toony Tiny People](https://assetstore.unity.com/packages/3d/characters/toony-tiny-people-demo-113188#publisher).
- [RPG/FPS Game Assets for PC/Mobile](https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v2-0-86679#publisher).
- [Crosshairs Plus](https://assetstore.unity.com/packages/2d/gui/icons/crosshairs-plus-139902).

<div align="center">
  <img width="1500" src="images/game-play.png" alt="Game play">
</div>

<div align="center">
  <i>Игра.</i>
</div>

## Новые особенности

Помимо туториала, я использовал свои знания и добавил в игру несколько новых функций:

- Добавить **стартовый экран**.
- Добавить **экран настроек** (`Setting`).
- Добавить **экран кредитов** (`Credits`).
- Добавить **баллы**, когда `Player` убить зомби и сохранить _высокий балл_ (`High score`).
- Добавить **звук** и **музыку** во время игры (`Music` и `Sound`)
- Теперь у `Player` _3 жизни_ (`3 сердца` ❤).
- Использование `NavMesh` - **Navigation Mesh** - _алгоритм ИИ_ для поиска пути.


Некоторые фотографии с новых особенностей:

<div align="center">
  <img width="1500" src="images/start-screen.png" alt="Start screen">
</div>

<div align="center">
  <i>Стартовый экран (с High score, Settings и Credits).</i>
</div>

<div align="center">
  <img width="1500" src="images/setting-screen.png" alt="Setting screen">
</div>

<div align="center">
  <i>Экран настроек (настройка Music и Sound - ON).</i>
</div>

<div align="center">
  <img width="1500" src="images/setting-screen-2.png" alt="Setting screen 2">
</div>

<div align="center">
  <i>Экран настроек (настройка Music и Sound - OFF).</i>
</div>

<div align="center">
  <img width="1500" src="images/credits-screen.png" alt="Credits screen">
</div>

<div align="center">
  <i>Экран кредитов.</i>
</div>


<div align="center">
  <img width="1500" src="images/game-play-2.png" alt="Game play 2">
</div>

<div align="center">
  <img width="1500" src="images/game-play-3.png" alt="Game play 3">
</div>

<div align="center">
  <img width="1500" src="images/game-play.png" alt="Game play">
</div>

<div align="center">
  <i>Вы можете видеть сердечко - оставшиеся жизни в игре и баллы - количество зомби, убитых игрой.</i>
</div>

<div align="center">
  <img width="1500" src="images/game-over.png" alt="Game over">
</div>

<div align="center">
  <i>Когда у Player не останется жизней (нет сердец), игра будет окончена (Game Over).</i>

  <i>Нажмите кнопку, чтобы начать игру снова.</i>
</div>