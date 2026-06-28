# Pong Game - Εργασία Σχολης ΙΕΚ 
---

<div align="center">

![Screenshot](images/photo-1.png)

![Screenshot](images/photo-2.png)

![Screenshot](images/photo-3.png)



</div>

# Περιγραφή Project
Το συγκεκριμένο project είναι ένα παιχνίδι τύπου Pong, υλοποιημένο σε C# Windows Forms.
Το παιχνίδι είναι multiplayer για 2 παίκτες και βασίζεται στην κλασική λογική του retro Pong game.
Οι παίκτες χειρίζονται δύο ρακέτες και προσπαθούν να αποκρούσουν την μπάλα ώστε να σκοράρουν απέναντι στον αντίπαλο.
---
# Στόχοι της Εφαρμογής
---
Εξοικείωση με την C#

Χρήση Windows Forms

Διαχείριση keyboard input

Δημιουργία game loop

Collision Detection

Χρήση αντικειμένων Rectangle

Χρήση γραφικών μέσω Graphics

Ανάπτυξη λογικής παιχνιδιού
---
# Τεχνολογίες
---
Γλώσσα: C#

Framework: .NET Windows Forms

IDE: Visual Studio


Gameplay
Το παιχνίδι περιλαμβάνει:

2 ρακέτες

1 μπάλα

Σύστημα score

Collision system

Game Over screen

Restart λειτουργία

Ο πρώτος παίκτης που θα φτάσει τους 5 πόντους κερδίζει το παιχνίδι.

# Χειρισμός Παιχνιδιού
ΠαίκτηςΚίνηση ΠάνωΚίνηση ΚάτωLeft PlayerWSRight Player↑ Arrow↓ Arrow
Restart

Πατήστε R μετά το Game Over για επανεκκίνηση.

# Λογική Κώδικα
---
Το παιχνίδι χρησιμοποιεί ένα Timer που λειτουργεί σαν game loop και ενημερώνει συνεχώς:

την κίνηση της μπάλας
τις ρακέτες
το score
τα collisions

Για τα collisions χρησιμοποιείται η κλάση Rectangle και η μέθοδος:

IntersectsWith()

Όταν η μπάλα χτυπά ρακέτα αλλάζει κατεύθυνση και αυξάνεται λίγο η ταχύτητα.

Τα γραφικά σχεδιάζονται μέσα από τη μέθοδο:

OnPaint()
Features
2 Player Gameplay
Score System
Collision Detection
Game Over Screen
Restart Function
Increasing Difficulty

# Τι Έμαθα
---
Μέσα από το project έγινε εξάσκηση σε:

Variables
Conditions
Methods
Events
Game Logic
Graphics
Collision Detection

# Pong Game - IEK School Project

---

<div align="center">

![Screenshot](images/photo-1.png)

![Screenshot](images/photo-2.png)

![Screenshot](images/photo-3.png)

</div>

## Project Description

This project is a classic **Pong Game** developed using **C# Windows Forms**.

It is a local multiplayer game for two players based on the original retro Pong gameplay. Each player controls a paddle and tries to prevent the ball from passing while scoring points against the opponent.

---

## Project Objectives

The purpose of this project was to practice and improve the following programming concepts:

- C# Programming
- Windows Forms Development
- Keyboard Input Handling
- Game Loop Implementation
- Collision Detection
- Using the `Rectangle` Class
- Graphics Rendering with `Graphics`
- Game Logic Development

---

## Technologies

- **Language:** C#
- **Framework:** .NET Windows Forms
- **IDE:** Visual Studio

---

## Gameplay

The game includes:

- Two player paddles
- One moving ball
- Score system
- Collision detection
- Game Over screen
- Restart functionality

The first player to reach **5 points** wins the game.

---

## Controls

| Player | Move Up | Move Down |
|---------|---------|-----------|
| Left Player | **W** | **S** |
| Right Player | **↑ Arrow** | **↓ Arrow** |

### Restart

After the **Game Over** screen appears, press **R** to restart the game.

---

## Code Logic

The game uses a **Timer** as the main game loop, which continuously updates:

- Ball movement
- Paddle movement
- Score
- Collision detection

Collision detection is implemented using the `Rectangle` class and the following method:

```csharp
IntersectsWith()
```

Whenever the ball hits a paddle:

- Its direction changes.
- Its speed slightly increases, making the game progressively more challenging.

All graphics are rendered inside the `OnPaint()` method.

---

## Features

- Two-Player Gameplay
- Score System
- Collision Detection
- Game Over Screen
- Restart Functionality
- Progressive Difficulty
- Smooth Ball Physics
- Keyboard Controls

---

## What I Learned

Through this project, I gained practical experience with:

- Variables
- Conditional Statements
- Methods
- Events
- Game Logic
- Graphics Rendering
- Collision Detection
- Object-Oriented Programming Basics
- Windows Forms Application Development

---

## Screenshots

Gameplay screenshots are available above.

---

## Author

Developed as a school project for **IEK** using **C# Windows Forms**.
