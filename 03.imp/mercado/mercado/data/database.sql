drop table detalle_transaccion;
drop table venta;
drop table compra;
drop table ingreso;
drop table salida;
drop table cliente;
drop table proveedor;
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


create table cliente(
	id int identity not null primary key,
	num_doc bigint,
	nombre varchar(100) not null,
);

create table proveedor(
	id int identity not null primary key,
	num_doc bigint,
	razon_social varchar(100) not null
)

create table venta(
	id int identity not null primary key,
	fecha smalldatetime not null,
	suma_items numeric(7,2) not null,
	descuento numeric(7,2) not null,
	importe numeric(7,2) not null,
	cliente_id int not null,
	foreign key(cliente_id) references cliente(id)
);

create table compra(
	id int identity not null primary key,
	fecha smalldatetime not null,
	suma_items numeric(7,2) not null,
	descuento numeric(7,2) not null,
	importe numeric(7,2) not null,
	proveedor_id int not null,
	foreign key(proveedor_id) references proveedor(id)
);

create table salida(
	id int identity not null primary key,
	fecha smalldatetime not null,
	glosa text not null,
	importe numeric(7,2) not null
);

create table ingreso(
	id int identity not null primary key,
	fecha smalldatetime not null,
	glosa text not null,
	importe numeric(7,2) not null
);

create table detalle_transaccion(
	id int identity not null primary key,
	cantidad int not null,
	precio_u numeric(7,2) not null,
	subtotal numeric(7,2) not null,
	saldo_cantidad int not null,
	producto_id int not null,
	venta_id int,
	compra_id int,
	ingreso_id int,
	salida_id int,
	foreign key(producto_id) references producto(id),
	foreign key(venta_id) references venta(id),
	foreign key(compra_id) references compra(id),
	foreign key(ingreso_id) references ingreso(id),
	foreign key(salida_id) references salida(id)
);
