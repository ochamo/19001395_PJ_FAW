DROP DATABASE IF EXISTS PJ_19001395_FAW;

CREATE DATABASE PJ_19001395_FAW;

USE PJ_19001395_FAW;

CREATE TABLE Sex(
    SexId INT AUTO_INCREMENT,
    Description VARCHAR(100),
    PRIMARY KEY (SexId)
);

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
            VALUES(@SexId, @UserName, @Name, MD5(@Pass), @BirthDate);
    END;

CREATE PROCEDURE SP_GET_LOGIN(IN UserName VARCHAR(100), IN Pass VARCHAR(100))
    BEGIN
        SELECT * FROM User WHERE
            UserName = @UserName AND Pass = MD5(@Pass);
    END;

CREATE TABLE Editorial(
    EditorialId INT AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    PRIMARY KEY (EditorialId)
);

INSERT INTO Editorial(Name) VALUES('MARVEL');
INSERT INTO Editorial(Name) VALUES('DC Comics');
INSERT INTO Editorial(Name) VALUES('IMAGE');

CREATE TABLE Comic(
    ComicId INT AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    IdEditorial INT NOT NULL,
    PrintYear VARCHAR(4) NOT NULL,
    Sinopsis TEXT NOT NULL,
    PRIMARY KEY (ComicId),
    FOREIGN KEY (ComicId) REFERENCES Editorial(EditorialId)
);


CREATE PROCEDURE SP_InsertComic(
    IN Name VARCHAR(255),
    IN IdEditorial INT,
    IN PrintYear VARCHAR(4),
    IN Sinopsis TEXT
)
    BEGIN
        INSERT INTO Comic(Name, IdEditorial, PrintYear, Sinopsis)
            VALUES(@Name, @IdEditorial, @PrintYear, @Sinopsis);
    END;

CREATE PROCEDURE SP_GetComics(IN ComicId INT)
    BEGIN
        SELECT * FROM Comic
            WHERE ComicId > @ComicId
            LIMIT 100;
    END;

CREATE PROCEDURE SP_UpdateComic(
    IN ComicId INT,
    IN Name VARCHAR(255),
    IN IdEditorial INT,
    IN PrintYear VARCHAR(4),
    IN Sinopsis TEXT
)
    BEGIN
        UPDATE Comic SET Name = @Name,
                IdEditorial = @IdEditorial,
                PrintYear = @PrintYear,
                Sinopsis = @Sinopsis
        WHERE ComicId = @ComicId;
    END;

CREATE PROCEDURE SP_DeleteComic(
    IN ComicId INT
)
    BEGIN
        DELETE FROM Comic WHERE ComicId = @ComicId;
    END;