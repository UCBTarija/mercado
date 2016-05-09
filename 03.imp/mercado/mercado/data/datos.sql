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

insert into cliente(nombre, num_doc) values
('XXXX', 1000),
('YYYY', 2000),
('ZZZZ', 3000);

insert into proveedor(razon_social, num_doc) values
('AAAA', 1000),
('BBBB', 2000),
('CCCC', 3000);


insert into compra (fecha, suma_items, descuento, importe, proveedor_id) values
('20160101 10:10', 0, 0, 0, 1);

insert into detalle_transaccion(cantidad, precio_u, subtotal, 
  saldo_cantidad, producto_id, compra_id) values
(10, 5, 0, 0, 1, 1),
(10, 4, 0, 0, 2, 1),
(10, 6, 0, 0, 3, 1);

insert into venta(fecha, suma_items, descuento, importe, cliente_id) values
('20160301 10:10', 0, 0, 0, 1),
('20160302 10:10', 0, 0, 0, 2),
('20160303 10:10', 0, 0, 0, 2);

insert into detalle_transaccion(cantidad, precio_u, subtotal, 
  saldo_cantidad, producto_id, venta_id) values
(1, 0, 0, 0, 1, 1),
(1, 0, 0, 0, 2, 1),
(2, 0, 0, 0, 1, 2),
(1, 0, 0, 0, 3, 3);


--select * from detalle_transaccion

update detalle_transaccion set
precio_u = (select precio from producto where id = producto_id);

update detalle_transaccion set
precio_u = producto.precio
from producto
where producto.id = detalle_transaccion.producto_id;

update detalle_transaccion set
subtotal = cantidad * precio_u;


update venta set
suma_items = (select sum(subtotal) from detalle_transaccion where detalle_transaccion.venta_id = venta.id)

/*
select top 1 * 
from detalle_transaccion
where producto_id = 1
order by id desc

select * from detalle_transaccion
select sum(subtotal)
from detalle_transaccion

exec demo 1

alter procedure demo (
@id int) AS
declare
@x varchar(10);
begin
  
  set @x = 'xx';
  select * from detalle_transaccion;

  select @x;
  
end


select top 1 *
from detalle_transaccion
where producto_id = 1
order by id desc

select * from
(select producto_id, max(id) as det_tran_id
from detalle_transaccion
group by producto_id) A
JOIN detalle_transaccion ON detalle_transaccion.id = A.det_tran_id;

SELECT d1.*
FROM detalle_transaccion d1
LEFT JOIN detalle_transaccion d2
	ON d1.producto_id = d2.producto_id
	AND d1.id < d2.id
WHERE d2.id is null;

select * from detalle_transaccion




select * from detalle_transaccion

select producto_id, producto.descripcion, count(*) as num
from detalle_transaccion
join producto on producto.id = detalle_transaccion.producto_id
group by producto_id, producto.descripcion
having count(*) = 2


select * 
from detalle_transaccion
join producto on producto.id = detalle_transaccion.producto_id



select * 
from 
	(select *
	from detalle_transaccion) xx

