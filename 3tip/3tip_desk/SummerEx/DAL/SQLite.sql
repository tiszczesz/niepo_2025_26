-- SQLite
CREATE TABLE Holidays(
 id Integer PRIMARY KEY,
 place Text,
 date_start Text,
 date_end Text,
 price Float,
 count Integer,
 isFoodIncluded Integer
);