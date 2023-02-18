CREATE TABLE USER_ECO(
	ID_USER SMALLSERIAL,
	NAME VARCHAR(20) NOT NULL,
	PATERNAL_LAST_NAME VARCHAR(20) NOT NULL,
	MATERNAL_LAST_NAME VARCHAR(20) NULL,
	PHONE VARCHAR(10) NOT NULL,
	PRIMARY KEY(ID_USER)
);
DELETE FROM USER_ECO WHERE ID_USER = 4;

--INSERT INTO USER_ECO(NAME, PATERNAL_LAST_NAME, MATERNAL_LAST_NAME, PHONE)
--VALUES('Marcos', 'Torresss', 'Mazza', 1123438475);



CREATE TABLE USER_PROFILE(
 ID_USER_PROFILE SMALLSERIAL,
 ID_USER INT NOT NULL,
 ID_LOCATION SMALLINT NOT NULL,
 USER_PASSWORD VARCHAR(10) NOT NULL,
 EMAIL VARCHAR(30) NOT NULL,
 CREATION_DATE TIMESTAMP NOT NULL,
 PRIMARY KEY(ID_USER_PROFILE),
 FOREIGN KEY(ID_USER)
 	REFERENCES USER_ECO(ID_USER)
  	ON DELETE CASCADE,
 FOREIGN KEY(ID_LOCATION)
  	REFERENCES USER_LOCATION(id_location)
  	ON DELETE CASCADE
);

SELECT * FROM USER_PROFILE;
INSERT INTO USER_PROFILE (ID_USER, ID_LOCATION, USER_PASSWORD, EMAIL, CREATION_DATE)
VALUES 
  (5, 2, 'contra123', 'usuario1@ejemplo.com', '2023-02-18 10:00:00.000');
  (2, 3, 'password456', 'usuario2@ejemplo.com', '2023-02-18 11:30:00'),
  (3, 1, 'secreto789', 'usuario3@ejemplo.com', '2023-02-18 14:45:00'),
  (4, 2, 'clave123', 'usuario4@ejemplo.com', '2023-02-18 16:00:00'),
  (5, 1, 'contraseña789', 'usuario5@ejemplo.com', '2023-02-18 17:30:00'),
  (6, 3, 'password123', 'usuario6@ejemplo.com', '2023-02-18 18:45:00'),
  (7, 2, 'secreto456', 'usuario7@ejemplo.com', '2023-02-18 19:00:00'),
  (8, 1, 'clave789', 'usuario8@ejemplo.com', '2023-02-18 21:15:00'),
  (9, 3, 'contraseña456', 'usuario9@ejemplo.com', '2023-02-18 22:30:00'),
  (10, 1, 'secreto123', 'usuario10@ejemplo.com', '2023-02-18 23:45:00');


SELECT * from PROVINCE;
SELECT * FROM USER_ECO;
SELECT * FROM USER_PROFILE;
SELECT * FROM USER_LOCATION;
SELECT * from ROL_USER;
SELECT * FROM USER_PERMISSION;
SELECT * FROM USER_STATUS;





SELECT * FROM USER_LOCATION;

SELECT * FROM USER_ECO;

INSERT INTO USER_ECO (NAME, PATERNAL_LAST_NAME, MATERNAL_LAST_NAME, CELL_PHONE) 
VALUES
('Juan', 'Pérez', 'García', '1155521234'),
('María', 'López', 'González', '1155535678'),
('Pedro', 'Martínez', 'Sánchez', '1155539012'),
('Sofía', 'Hernández', 'Fernández', '1155523456'),
('Luis', 'García', 'Pérez', '1155567890'),
('Ana', 'Romero', 'Jiménez', '1155522345'),
('José', 'Díaz', 'Vázquez', '1155526789'),
('Laura', 'Torres', 'Ramírez', '1155570123'),
('Miguel', 'Gutiérrez', 'Navarro', '1155564567'),
('Carmen', 'Vargas', 'Castillo', '1155568901');


SELECT * FROM USER_PROFILE;

SELECT * FROM PROVINCE;
















































