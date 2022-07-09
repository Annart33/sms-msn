CREATE TABLE Messages
(
    Id         int NOT NULL AUTO_INCREMENT,
    Date       DATE,
    Content    varchar(32765) NOT NULL,
    Number     varchar(30) NOT NULL,
    PRIMARY KEY (Id)
)