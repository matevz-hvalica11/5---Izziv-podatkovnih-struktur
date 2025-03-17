Ta seminarska naloga se osredotoča na zgoščevalno tabelo. 
Funkcija zgoščevanja, obravnavanja trkov in osnovnih operacij
Program omogoča: 
Vstavljanje elementov v hash tabelo
Iskanje elementov
Brisanje elementov in
Izpis celotne hash tabele
Program deluje tako, da vstavimo podatke, npr: ("Ime", "Avgust"), "Priimek", "Mlakar", "Kraj", "Stari trg pri Lozu", "Država", "Slovenija".
Vsaka vrednost gre skozi hash funkcijo in se shrani v določenem "bucketu".
Izpis hash tabele:
Po vstavljanju se prikaže struktura hash tabele in kam so bili podatki shranjeni.
Iskanje vrednosti po ključu: 
Če poiščeš "Ime", ti vrne "Avgust",
Če poiščeš "Država", ti vrne "Slovenija",
Če iščeš neobstoječ ključ, ti vrne "Ni najdeno".
Brisanje podatkov:
Ko pobrišeš "Priimek", se preveri, če je seznam prazen ali če je treba prilagoditi kazalce.
Ponoven izpis hash tabele pokakže, da "Priimek" manjka
