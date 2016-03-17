USE mercado;

insert into categoria(nombre) values
('LÁCTEOS'),
('FIAMBRES'),
('GALLETAS');

insert into marca(nombre) values
('CREMOSITA'),
('MEDIA TARDE'),
('PIL TARIJA'),
('PIL ANDINA');

insert into producto (codigo, cantidad_minima, precio, descripcion, categoria_id, marca_id) values
('001', 5, 2.5,'GALLETA CREMOSITA 1 PAQUETE DE 4 GALLETAS', 3, 1),
('002', 5, 7,'GALLETA MEDIA TARDE EN PAQUETES DE 3 UNIDADES', 3, 2),
('003', 10, 7,'LECHE PIL TARIJA LIQUIDA DE 1 LITRO', 1, 3);