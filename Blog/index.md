---
title: Inventory System
layout: home
nav_order: 0
---

# Let's Make a Grid Based Inventory System
{: .no_toc }

![Inventory System](imgs/Inventory.png)

Hello coders! Captain Coder here with another learning series. On the Captain
Coder's Academy discord, it was proposed that I implement an inventory system
live on stream. I felt this fit into the current theme of prepping for the [2023
Dungeon Crawler Game Jam](https://itch.io/jam/dcjam2023) 

This site serves as a blog that will (hopefully) chronicle the streams for
anyone who missed them live and recap what we accomplished each day. I
hope someone finds this blog useful!

* Archived Streams Playlist: [Playlist]
* Catch the Captain Live on Twitch: [Twitch]
* Source Code: [Repository]

## Project Overview

The goal of this project is to create a functional grid based inventory system
similar to that of the original
[Diablo](https://en.wikipedia.org/wiki/Diablo_(video_game)):

![Diablo Inventory](imgs/diablo_inventory.webp)

More specifically, we would like to create a grid based inventory for which
items may occupy more than a single grid slot.

## Day 1 - Design Document and Project Scope

Today, we defined our learning goals, specified the scope of the project, setup
a unity project, class class library project, [xUnit] test project, and defined
two interfaces: `IInventoryItem` and `IInventoryGrid`.

* [Read More]({% link pages/01-day-1.md %})
* [Watch On YouTube](https://youtube.com/live/uRBIHAHNVMw?feature=share)

## Day 2 - Grid Logic System

Today, we implemented a simple version of the `IInventoryGrid` interface as well
as 4 unit tests to ensure our the interface can meet our needs. With that in
place, we were able to write scriptable objects to represent a player's
inventory or another container type.

* [Read More]({% link pages/02-day-2.md %})
* [Watch On YouTube](https://youtube.com/live/RL9k7JHkCGU?feature=share)

## Day 3: Grid Logic System

Today, we explored using the UI Toolkit once again to create parameterized
elements that can be reused in the UI Toolkit builder. More specifically, we
implemented a reusable `GridElement` component. Additionally, we explored how to
do 9-slicing on sprites within the UI Toolkit Builder to automatically resize 
our container borders to wrap the size of the grid.

* [Read More]({% link pages/03-day-3.md %})
* [Watch On YouTube](https://youtube.com/live/N9I2VYcUbsU?feature=share)

## Day 4: Clickable Items

Today, we used Leonaro.AI to generate equipment graphics, added a UI component
for items, and connected the inventory grid logic with the UI through a
controller script.

* [Read More]({% link pages/04-day-4.md %})
* [Watch On YouTube](https://www.youtube.com/watch?v=kMufcKTnmTQ)

# Day 5: Polish and Package

Today, we used Leonaro.AI to generate equipment graphics, added a UI component
for items, and connected the inventory grid logic with the UI through a
controller script.

* [Read More]({% link pages/05-day-5.md %})
* [Watch On YouTube](https://www.youtube.com/live/4ZiiWpHtYSo?feature=share)

{% include Links.md %}