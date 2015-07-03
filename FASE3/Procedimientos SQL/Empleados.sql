select s.nombre as Sucursal, d.nombre as Departamento, count(e.cod_empleado) as Empleados, SUM(CONVERT(float,e.sueldo)) as Sueldos 
from ProyectoIPC2.dbo.Empleados e, ProyectoIPC2.dbo.Usuarios u, ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Departamentos d,
ProyectoIPC2.dbo.SucDep sd where s.cod_sucursal = sd.cod_sucursal and d.cod_departamento =sd.cod_departamento and 
e.cod_usuario = u.cod_usuario and sd.cod_Suc_Dep=e.cod_suc_dep group by s.nombre, d.nombre