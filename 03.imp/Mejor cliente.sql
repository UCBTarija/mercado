with t as (
select venta.cliente_id, detalle_transaccion.producto_id, sum(subtotal) total
	from detalle_transaccion 
	join venta on venta.id = detalle_transaccion.venta_id
	group by venta.cliente_id, detalle_transaccion.producto_id)

select cliente.nombre, producto.descripcion, m.total
from 
(select b.cliente_id, b.producto_id, b.total
from
(select cliente_id, max(total) total
from t
group by cliente_id ) a

join
	t b
on a.cliente_id = b.cliente_id and a.total = b.total
) m
join cliente on cliente.id = m.cliente_id 
join producto on producto.id = m.producto_id

select *
from cliente
where cliente.id  = any (
 select cliente_id from venta
 )

select producto.descripcion, sum(detalle_transaccion.subtotal) total
from producto 
left join detalle_transaccion on detalle_transaccion.producto_id = producto.id
left join venta on venta.id = detalle_transaccion.venta_id
group by producto.descripcion
