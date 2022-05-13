DROP DATABASE IF EXISTS PJ_19001395_FAW;

CREATE DATABASE PJ_19001395_FAW;

USE PJ_19001395_FAW;

CREATE TABLE Sex(
    SexId INT AUTO_INCREMENT,
    Description VARCHAR(100),
    PRIMARY KEY (SexId)
);

CREATE PROCEDURE  SP_GetSexes()
    BEGIN
        SELECT * FROM Sex;
    END;

INSERT INTO Sex(Description) VALUES('Masculino');
INSERT INTO Sex(Description) VALUES('Femenino');

CREATE TABLE User(
    UserId INT AUTO_INCREMENT,
    SexId INT NOT NULL,
    UserName VARCHAR(100) NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Pass VARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    PRIMARY KEY (UserId),
    UNIQUE (UserName),
    FOREIGN KEY (SexId) REFERENCES Sex(SexId)
);

CREATE PROCEDURE SP_InsertUser(
    IN SexId INT,
    IN UserName VARCHAR(100),
    IN Name VARCHAR(255),
    IN Pass VARCHAR(100),
    IN BirthDate DATE)
    BEGIN
        INSERT INTO User(SexId, UserName, Name, Pass, BirthDate)
            VALUES(SexId, UserName, Name, MD5(Pass), BirthDate);
    END;

CALL SP_InsertUser(1, 'ottod', 'name', 'pass', NOW());

CREATE PROCEDURE SP_Get_Login(IN UserName VARCHAR(100), IN Pass VARCHAR(100))
    BEGIN
        SELECT * FROM User U WHERE
            U.UserName = UserName AND U.Pass = MD5(Pass);
    END;

CREATE TABLE Editorial(
    EditorialId INT AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY (EditorialId)
);

CREATE PROCEDURE SP_Get_Editorial()
    BEGIN
        SELECT * FROM Editorial;
    END;

INSERT INTO Editorial(Name) VALUES('MARVEL');
INSERT INTO Editorial(Name) VALUES('DC Comics');
INSERT INTO Editorial(Name) VALUES('IMAGE');

CREATE TABLE Comic(
    ComicId INT AUTO_INCREMENT,
    UserId INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    IdEditorial INT NOT NULL,
    PrintYear VARCHAR(4) NOT NULL,
    Sinopsis TEXT NOT NULL,
    PRIMARY KEY (ComicId),
    FOREIGN KEY (IdEditorial) REFERENCES Editorial(EditorialId),
    FOREIGN KEY (UserId) REFERENCES User(UserId)
);


CREATE PROCEDURE SP_InsertComic(
    IN Name VARCHAR(255),
    IN IdEditorial INT,
    IN UserId INT,
    IN PrintYear VARCHAR(4),
    IN Sinopsis TEXT
)
    BEGIN
        INSERT INTO Comic(Name, UserId, IdEditorial, PrintYear, Sinopsis)
            VALUES(Name, UserId, IdEditorial, PrintYear, Sinopsis);
    END;

CREATE PROCEDURE SP_GetComics(IN LastComicId INT)
    BEGIN
        SELECT ComicId, Name, IdEditorial, PrintYear, Sinopsis, UserId FROM Comic
            WHERE ComicId > LastComicId
            LIMIT 100;
    END;

CREATE PROCEDURE SP_UpdateComic(
    IN IdComic INT,
    IN ComicName VARCHAR(255),
    IN ComicEditorial INT,
    IN ComicPrintYear VARCHAR(4),
    IN ComicSinopsis TEXT
)
    BEGIN
        UPDATE Comic c SET c.Name = ComicName,
                c.IdEditorial = ComicEditorial,
                c.PrintYear = ComicPrintYear,
                c.Sinopsis = ComicSinopsis
        WHERE c.ComicId = IdComic;
    END;


CREATE PROCEDURE SP_DeleteComic(
    IN ComicId INT
)
    BEGIN
        DELETE FROM Comic c WHERE c.ComicId = ComicId;
    END;