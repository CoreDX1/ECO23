CREATE TABLE ROL_USER(
     ID_ROL_USER  SMALLSERIAL,
     NAME VARCHAR(15),
     PRIMARY KEY(ID_ROL_USER)
 );

CREATE TABLE PROVINCIA(
    ID_PROVINCIA SMALLSERIAL,
    NOMBRE VARCHAR(20) NOT NULL,
    PRIMARY KEY(ID_PROVINCIA)
);

CREATE TABLE USER_STATUS(
    ID_USER_STATUS SMALLSERIAL,
    NOMBRE VARCHAR(20) NOT NULL,
    PRIMARY KEY(ID_USER_STATUS)
);

CREATE TABLE USER_LOCATION(
    ID_LOCATION SMALLSERIAL,
    STREET VARCHAR(20) NOT NULL,
    HEIGHT INT NOT NULL,
    ID_PROVINCE SMALLINT NOT NULL,
    FOREIGN KEY (ID_PROVICIA) REFERENCES PROVINCIA(ID_PROVINCIA) on delete cascade,
)

CREATE TABLE USER_PERMISSION(
    ID_USER_PERMISSION SMALLSERIAL,
    ID_USER_ECO SMALLINT NOT NULL,
    ID_USER_STATUS SMALLINT NOT NULL,
    PRIMARY KEY(ID_USER_PERMISSION),
    FOREIGN KEY (ID_USER_ECO) REFERENCES USER_ECO(ID_USER) no delete cascade,
    FOREIGN KEY (ID_USER_STATUS) REFERENCES USER_STATUS(ID_USER_STATUS) on delete cascade
);


--Como borra los CONSTRAINT
alter table user_location drop constraint localidad_id_provincia_fkey;

-- Como agregar una foreing key
alter table user_location add foreign key(id_province) references province(id_province) on delete cascade;

-- Cambiar el type
ALTER TABLE user_profile ALTER COLUMN id_user TYPE smallint;

-- Todas la provincias
INSERT INTO province (name)
VALUES ('BUENOS AIRES'),
       ('CATAMARCA'),
       ('CHACO'),
       ('CHUBUT'),
       ('CABA'),
       ('CÓRDOBA'),
       ('CORRIENTES'),
       ('ENTRE RÍOS'),
       ('FORMOSA'),
       ('JUJUY'),
       ('LA PAMPA'),
       ('LA RIOJA'),
       ('MENDOZA'),
       ('MISIONES'),
       ('NEUQUÉN'),
       ('RÍO NEGRO'),
       ('SALTA'),
       ('SAN JUAN'),
       ('SAN LUIS'),
       ('SANTA CRUZ'),
       ('SANTA FE'),
       ('SANTIAGO DEL ESTERO'),
       ('TIERRA DEL FUEGO'),
       ('TUCUMÁN');

insert into user_status(status)
values('ADMIN'),('CLIENT'),('EMPLOYEE');

insert into user_permission(id_user_eco,id_user_status)
values(11,2)

insert into user_eco(name,paternal_last_name,maternal_last_name,phone)
values('CAMILO','ALTARAZ','BEGON',1152192936);

insert 
	into 
	user_location (street, height, id_province)
	values('TRAVESIA ABREU', 295,17);

insert 
	into
	user_profile(id_user,id_location,user_password,creation_date,email)
	values(11,1,'index','2023-01-08 04:05:06','camilo@gmail.com')

select * from user_profile;


