create table RolUsuario(
     idRolUsuario SMALLSERIAL,
     nombre varchar(15),
     PRIMARY KEY(idRolUsuario)
 );

-- Tabla Usuarios
create table Usuarios(
     idUsuario SMALLSERIAL,
     nombre varchar(15) not null,
     edad int not null,
     telefono varchar(40) not null,
     PRIMARY KEY(idRolUsuario)
 );