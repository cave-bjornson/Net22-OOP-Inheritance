# Om uppgiften

I denna uppgift kommer du öva på att använda arv inom objektorientering. Uppgiften handlar till stor del om att tänka ut en struktur för arv men också om att delvis implementera den i kod.

## Vad du ska göra

Tänk dig att du ska skapa en grund för ett program som hanterar djur på ett zoo.

- [x]  Det ska finnas en basklass som är `Djur`
    - [x]  Klassen ska ha minst fem egenskaper som alla djur delar med varandra
    - [x]  Klassen ska också minst tre metoder som alla djuren delar med varandra
- [x]  Du ska skapa minst tre olika djur som ärver från Djur-klassen
    - [x]  Dessa djur ska implementera minst en ny egenskap vardera och minst en ny metod vardera
    - [x]  Dessa djur ska också ha defaultvärden för egenskaperna, både de som sätts i klassen och i basklassen
    - [x]  Alla djur måste ha en metod som heter `makeSound()` och som ska skriva ut djurets läte i consolen
    - [x]  Det ska finnas en constructor som vi kan användas för att skapa nya djur
- [ ]  En av djuren du skapat ovan ska du sedan dela upp i två nya klasser som ärver från det specifika djuret.
    - [ ]  Exempelvis kanske du har Hund och då kan vi skapa Bulldog och Chihuahua. Resultatet blir arv i två nivåer.
    - [ ]  Dessa djurvarianter ska också implementera någon unik egenskap och någon unik metod eller i alla fall en överlagring som gör dem unika.
- [ ]  I din main-metod ska du initiera ett flertal olika djur och se till att dem gör sina ljud så det syns i konsolen att djuren har låtit

## Extra utmaning

Vill du ha lite mer utmaning så kan du försöka implementera följande:

- [ ]  Få in så att även människa finns som ett djur
- [ ]  Utöka strukturen så att det finns skillnad på däggdjur och reptiler
- [ ]  Utöka så att det även finns märkning av djur kring om de är vilda eller tama djur
- [ ]  Utöka så att strukturen även omfattar växter

[Changelog](CHANGELOG.md)
