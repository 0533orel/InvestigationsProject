# 🕵️‍♂️ InvestigationsProject

**InvestigationsProject** is a console-based investigation game developed in C#. The player takes the role of a counterintelligence investigator attempting to expose Iranian agents by strategically attaching sensors that match their hidden weaknesses.

---

## 📌 Project Overview

This project is designed as a multi-level, interactive text game. It includes:

- Persistent player progress using a MySQL database.
- Multiple enemy agent types with varying behaviors and ranks.
- Sensor mechanics and life cycle management.
- Custom logic for attack-counterattack dynamics.
- Clean separation of layers using OOP and SOLID principles.

---

## 🎮 Gameplay Summary

- Each level presents the player with a new enemy agent.
- The agent has secret weaknesses that must be uncovered using sensors.
- The player selects and applies sensors strategically.
- Agents may strike back and damage sensors over time.
- At the end of each level, the game displays real-world intelligence data based on the exposed agent's rank.

---

## 🧱 Project Structure

```
InvestigationsProject/
│
├── Game/               # Main game logic (GameControl, Helper)
├── Classes/            # Core domain models (Agent, Player, etc.)
├── IranianAgents/      # Specific agent types by rank
├── Sensors/            # Sensor types and behavior
├── DAL/                # Database access layer for players and agents
├── Factories/          # Factory classes for dynamic creation
├── Program.cs          # Application entry point
├── ArabicPeople.sql    # SQL script for initializing agents table
└── README.md           # Project documentation
```

---

## 💽 Database Setup

1. **Requirements:**
   - MySQL Server or MariaDB
   - .NET 6.0 or later

2. **Initialization:**
   - Run `ArabicPeople.sql` to create the `agents` table.
   - Make sure you also have a `players` table with the correct structure.
   - Example database name: `investigation`

3. **Connection Configuration:**
   Edit the following section inside `SQLConnection.cs`:

   ```csharp
   string connectionString = "server=localhost;user=root;password=your_password;database=investigation";
   ```

---

## 🏁 How to Run

1. Open the solution in Visual Studio or JetBrains Rider.
2. Set `Program.cs` as the startup file.
3. Run the project (Ctrl + F5).
4. Follow the menu instructions in the console.

---

## 🔧 Key Features

- ✔️ Interactive CLI gameplay
- ✔️ Dynamic agent creation with custom ranks
- ✔️ Multiple sensor types with upgradable logic
- ✔️ Strikeback mechanisms for advanced agents
- ✔️ MySQL integration with data persistence
- ✔️ Adaptive rank and level system per player
- ✔️ Real-world agent data revealed after each level

---

## 🚀 Planned Enhancements

- GUI version (Windows Forms / WPF)
- Multiplayer mode
- Enhanced story-driven progression
- Achievements and statistics tracking
- Admin panel for adding/editing agents

---

## 📖 Technologies Used

- C# (.NET 6)
- MySQL / MariaDB
- OOP Design Patterns (Factory, Interface Segregation, Abstraction)
- Layered Architecture (Domain, DAL, UI)

---

## 👤 Author

Developed by **[Your Name]**  
This project is part of a personal learning journey focused on C#, software architecture, and cybersecurity simulations.

---

## 📄 License

This project is open-source and provided for **educational and non-commercial use** only.
