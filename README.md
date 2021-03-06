# Feedback for Gamification Guidelines

![](https://github.com/Clauvin/Teste-Mobile/blob/master/For%20The%20Wiki/Image.png)

## Warning

Given the vast amount of mobile devices, while we tried our best to make sure that the app would work with any of those, bugs may appear. In this case, check "In Case of Problems", below.

## Description

An application that gets feedback about gamification guidelines (to be added to it when they're done) and send those to a research e-mail address, made with Unity 2019.3.13f1.

## Where the Code Is

Script code is [here](https://github.com/Clauvin/Teste-Mobile/tree/master/Teste%20Mobile/Assets/Script), test code is [here](https://github.com/Clauvin/Teste-Mobile/tree/master/Teste%20Mobile/Assets/Tests).

## Where to Download

[Desktop](https://github.com/Clauvin/Teste-Mobile/releases/tag/v1.0-Desktop) version.

[Mobile](https://github.com/Clauvin/Teste-Mobile/releases/tag/v1.0-Mobile) version.

## In Case of Problems

Please contact gamification.feedback@gmail.com.

## Design Patterns Used

*Facade* - MainPanelManagerScript and FeedbackPanelManagerScript are referenced a lot by all the buttons in the program to switch panels around, instead of each button doing the switching by themselves.

*Strategy* - Unity does it by default: basically ALL MonoBehaviour derived classes can be added to any GameObject, which makes Monobehaviour a father of a huge family of interchangeable scripts.

*Prototype* - Sort of. Prefabs in Unity are base objects which can be instantiated through a simple call to Instantiate(...). We used that to make testing easier a few times.

## Class Diagrams, Architecture, Hierarchy of The Main Menu, Requirements, Test Diagrams, etc

See [here](https://github.com/Clauvin/Teste-Mobile/wiki/).

## Lessons Learned

Design patterns should be considered for a software engineering project as soon as the first class diagram is done, not only as a tool while a project is refactored.

If you thought you had enough time to make a project, and you alotted extra time for inconveniences and unexpected hurdles, double that time, just to be sure.

Always make and test a build as soon as you have something that works inside your IDE.

Never forget the value of exploratory testing, specially if the exploratory testing is manual.

Always weight the pros and cons of doing an app from a relative zero vs. using a solution for the type of app that you want to do.

Never let the eagerness to fix a bug create commits that are less-than-optimal for future inspection.
