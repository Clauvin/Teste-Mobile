# Teste-Mobile

## Warning

Given the vast amount of mobile devices, while we tried our best to make sure that the app would work with any of those, bugs may appear. In this case, check "In Case of Problems", below.

## Description

An application that gets feedback about gamification guidelines (to be added to it when they're done) and send those to a research e-mail address.

## How to Install



## In Case of Problems

Please contact gamification.feedback@gmail.com.

## Design Patterns Used

*Facade* - MainPanelManagerScript and FeedbackPanelManagerScript are referenced a lot by all the buttons in the program to switch panels around, instead of each button doing the switching by themselves.

*Strategy* - Unity does it by default: basically ALL MonoBehaviour derived classes can be added to any GameObject, which makes Monobehaviour a father of a huge family of interchangeable scripts.

*Prototype* - Sort of. Prefabs in Unity are base objects which can be instantiated through a simple call to Instantiate(...). We used that to make testing easier a few times.

## Class Diagrams, Architecture, Hierarchy of The Main Menu, Requirements, Test Diagrams, etc

See [here](https://github.com/Clauvin/Teste-Mobile/wiki/).
