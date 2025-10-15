# 💼 Job Application Tracker (C# Console App)

Ett konsolprogram för att hålla koll på jobbansökningar – byggt med **C#, LINQ och OOP**.  
Projektet hanterar jobbansökningar, uppdateringar, statistik och filtrering direkt i terminalen.

---

## 🎯 Syfte
Syftet med projektet är att visa kunskap inom:
- Objektorienterad programmering (klasser, egenskaper och metoder)
- LINQ för filtrering, sortering och statistik
- Strukturering av menybaserade konsolapplikationer
- Versionshantering med Git & GitHub (branches, pull requests och branch protection)

---

## ⚙️ Funktioner

### Grundfunktioner
- ➕ Lägg till ny jobbansökan  
- 📋 Visa alla ansökningar  
- 🔍 Filtrera efter status (via LINQ)  
- 📅 Sortera efter ansökningsdatum  
- ✏️ Uppdatera status på befintlig ansökan  
- 🗑️ Ta bort ansökan  
- 💾 Avsluta programmet  

### Statistik (VG-del)
- 📊 Totalt antal ansökningar  
- 📈 Antal per status (grupperat med LINQ GroupBy)  
- 💰 Genomsnittlig löneförväntning  
- ⏱️ Genomsnittlig svarstid på ansökningar  
- 🕓 Filtrering: “Visa ansökningar utan svar äldre än 14 dagar”  

### Bonus
- 🎨 Färger i konsolen (grön = Accepted, röd = Rejected, gul = Applied)  
- 💡 Enkel inputvalidering (ogiltiga värden hanteras smidigt)  

---

## 🧠 Tekniker
- **C# .NET Console Application**
- **LINQ** (`Where`, `OrderBy`, `Average`, `GroupBy`)
- **Objektorienterad design**
- **Git & GitHub** (branches, pull requests, README, branch protection)

---

## 🚀 Så kör du programmet
1. Klona repot:
   ```bash
   git clone https://github.com/<ditt-användarnamn>/<repo-namn>.git


## Reflektion
1. Linq är användbart men jag föredrar vanliga loopar för läsbarhetens skull.
2. Switch cases. Jag hatar switch cases. De är fula och svårlästa och kräver massa scaffolding.