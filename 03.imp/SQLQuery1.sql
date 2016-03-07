SELECT producto.codigo, 
 producto.descripcion,
 producto.unidad_id, 
 categoria.descripcion AS categoria,
 marca.descripcion AS marca
FROM producto
JOIN categoria ON categoria.id = producto.categoria_id
JOIN marca ON marca.id = producto.marca_id
WHERE unidad_id = 'KG'
AND (
   producto.descripcion LIKE '%TORTA%'
   OR 
   producto.codigo LIKE '%01%'
   OR
   marca.descripcion LIKE '%STEGE%'
)

