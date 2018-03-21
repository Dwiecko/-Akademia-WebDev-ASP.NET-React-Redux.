Praca domowa z ASP .Net MVC
1. Przykładowe rozwiązanie znajduje się pod adresem: http://webdevhomework.azurewebsites.net/
2. Potrzebujemy formularza, który umożliwi dodanie linka do listy.
3. Każdy element na liście składa się z oryginalnego i skróconego linka oraz przycisku usuń.
4. Po kliknięciu w skrócony link, w nowej zakładce otwiera się odpowiednia strona.
5. Każdy link można usunąć.
6. Wymagamy dwóch kontrolerów - jeden do operowania na liście linków oraz drugi do obsługi przekierowania.
7. Skrócony adres powinien być dostępny pod urlem adres_aplikacji/skrócony_link, np. localhost:5000/xQm0OBqE (wykorzystajcie routing atrybutowy).
8. W celu skrócenia adresu polecamy bibliotekę hashids.net 
9. Instalacja hashids: dotnet add package hasihds.net
10. *Zadanie dodatkowe: formularz do edycji linka.
11. *Zadanie dodatkowe: walidacja czy wpisany adres jest faktycznie linkiem
