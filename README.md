MusicAppAPI

Kako bi se osigurao rad backend-a molim vas da u datoteci appsettings.json navigirate do stavke "defaultConnection" i pod polje "serve" da upišete link za vas lokalni sql server.

Nakon toga izvršite jedan database update koristeći komandu:
  'dotnet ef database update' 
  
  , dok se nalazite u package menager konzoli.
  
  Možete i po želji prvo jednu migraciju izvršiti ali postoji već jedna u projektu.
