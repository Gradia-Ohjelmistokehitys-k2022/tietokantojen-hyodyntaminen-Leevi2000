# Opiskelija ja opiskelijaryhmä

Tutustu teoria osioon, jossa neuvotaan miten saat hyödynnettyä MsSQL palvelinta Windows forms sovelluksessa. Voit käyttää myös MySQl-tietokantaa.
[Tietokanta ja c#](https://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C) 

Tehtävässä tehdään lomake -sovellus, jolla saa lisättyä nimen tietokannassa olevaan opiskelija tauluun. 
+ Luodaan tietokanta ja siihen taulu nimeltä opiskelija ja siihen kentät id, etunimi ja sukunimi
+ WindowsForms-sovellus, jonka avulla lisätään, haetaan ja poistetaan tietoja tietokannasta.
+ Selvitä miten sovelluksen ja tietokannan välinen yhteys muodostetaan.
 
## Vaihe 1. 

Lisää lomakkeelle komponentti, johon tulostat kaikki taulun nimet. Tulosta nimet DatagridView -rakenteeseen. 
 
## Vaihe 2. 

Lisää lomakkeelle toiminne missä saat poistettua vaiheen 2 taulunäkymässä valitun nimen tietokantataulusta. 

 
## Vaihe 3.

Luo tietokantaan opiskelijaryhmä -taulu ja sille viiteavain opiskelija -tauluun. Lisää esimerkki opiskelijaryhmä -tauluun. Lisää combobox, jolle haet kaikki tietokannan opiskelijaryhmät. Muuta ohjelmaa, jotta opiskelija saadaan sidottua luomisen yhteydessä valittuun opiskelijaryhmään.

Combobox:ssa haluamme usein näyttää esim. ryhmän nimen, mutta jatkohaussa käytämme opiskelijaryhmän Id:tä hakuehtona. Tai ensimmäisessä tehtävässä käyttäjä valitsee opiskelijaryhmän, mutta opiskelija –tauluun tallennetaan opiskelijaryhmän ID.

[Comboxin tietojen lisäys](https://www.c-sharpcorner.com/UploadFile/0f68f2/programmatically-binding-datasource-to-combobox-in-multiple/)
