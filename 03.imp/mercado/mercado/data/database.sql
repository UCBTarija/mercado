drop table producto;
drop table categoria;
drop table marca;

CREATE TABLE categoria (
	id INT IDENTITY NOT NULL PRIMARY KEY,
	nombre VARCHAR (30) NOT NULL
);

CREATE TABLE marca (
    id INT IDENTITY NOT NULL PRIMARY KEY,
    nombre VARCHAR (30) NOT NULL
);

CREATE TABLE producto (
    id INT IDENTITY NOT NULL PRIMARY KEY,
    codigo VARCHAR (30) NOT NULL,
    cantidad_minima NUMERIC (7, 2) NOT NULL,
    precio NUMERIC (7, 2) NOT NULL,
    descripcion VARCHAR (100)  NOT NULL,
    categoria_id INT NOT NULL,
    marca_id INT NOT NULL,
    FOREIGN KEY (categoria_id) REFERENCES categoria (id),
    FOREIGN KEY (marca_id) REFERENCES marca (id)
);


