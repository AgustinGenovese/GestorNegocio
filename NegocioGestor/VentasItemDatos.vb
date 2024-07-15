Imports DominioGestor

Public Class VentasItemDatos

    Public Function listarPorId(id As String) As List(Of VentaItem)

        ' Obtiene una lista de ítems de venta asociados a una venta específica según su ID.
        ' Recibe como parámetro el ID de la venta.
        ' Devuelve una lista de objetos VentaItem que representan los ítems de venta asociados a la venta especificada.

        Dim datos As New AccesoDatos()
        Dim datosVentas As New VentasDatos()
        Dim datosProductos As New ProductoDatos()
        Dim listaVentasItems As New List(Of VentaItem)()

        Try
            datos.setearConsulta("SELECT ID, IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal FROM ventasitems where IDVENTA = '" & id & " '  ")
            datos.ejecutarLectura()

            While datos.Lector.Read()
                Dim ventaItems As New VentaItem()
                ventaItems.Id = Convert.ToInt32(datos.Lector("Id"))
                ventaItems.VentaAsociada = ObtenerVenta(datos, datosVentas)
                ventaItems.Producto = ObtenerProducto(datos, datosProductos)
                ventaItems.PrecioUnitario = Convert.ToDecimal(datos.Lector("PrecioUnitario"))
                ventaItems.Cantidad = Convert.ToInt32(datos.Lector("Cantidad"))
                ventaItems.PrecioTotal = Convert.ToDecimal(datos.Lector("PrecioTotal"))
                listaVentasItems.Add(ventaItems)
            End While

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

        Return listaVentasItems
    End Function

    Public Sub Eliminar(id As Integer)

        ' Elimina un ítem de venta específico según su ID.
        ' Recibe como parámetro el ID del ítem de venta a eliminar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("DELETE FROM ventasitems WHERE id = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub EliminarPorIdVentaGeneral(id As Integer)

        ' Elimina todos los ítems de venta asociados a una venta específica según su ID.
        ' Recibe como parámetro el ID de la venta cuyos ítems se desean eliminar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("DELETE FROM ventasitems WHERE IDVenta = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Agregar(nuevo As VentaItem, Total As String)

        ' Agrega un nuevo ítem de venta a la base de datos y actualiza el total de la venta asociada.
        ' Recibe como parámetros un objeto de tipo VentaItem con los datos del nuevo ítem de venta y el nuevo total de la venta.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal);")
            datos.setearParametro("@IDVenta", nuevo.VentaAsociada.Id)
            datos.setearParametro("@IDProducto", nuevo.Producto.Id)
            datos.setearParametro("@PrecioUnitario", nuevo.PrecioUnitario)
            datos.setearParametro("@Cantidad", nuevo.Cantidad)
            datos.setearParametro("@PrecioTotal", nuevo.PrecioTotal)
            datos.ejecutarAccion()


            datos.setearConsulta("UPDATE ventas SET Total = @Total WHERE id = '" & nuevo.VentaAsociada.Id & " ' ")
            datos.setearParametro("@Total", Total)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

    Public Function ObtenerVenta(datos As AccesoDatos, datosVenta As VentasDatos) As Venta

        ' Obtiene la venta asociada a un ítem de venta específico.
        ' Recibe como parámetros un objeto de acceso a datos y un objeto VentasDatos.
        ' Devuelve un objeto de tipo Venta que representa la venta asociada al ítem de venta.

        Dim listaVentas As List(Of Venta) = datosVenta.Listar()
        Dim seleccionado As Venta = Nothing

        For Each venta As Venta In listaVentas
            If venta.Id = Convert.ToInt32(datos.Lector("IDVenta")) Then
                seleccionado = venta
                Exit For
            End If
        Next

        Return seleccionado
    End Function


    Public Function ObtenerProducto(datos As AccesoDatos, datosProductos As ProductoDatos) As Producto

        ' Obtiene el producto asociado a un ítem de venta específico.
        ' Recibe como parámetros un objeto de acceso a datos y un objeto ProductoDatos.
        ' Devuelve un objeto de tipo Producto que representa el producto asociado al ítem de venta.

        Dim listaProductos As List(Of Producto) = datosProductos.Listar()
        Dim seleccionado As Producto = Nothing

        For Each producto As Producto In listaProductos
            If producto.Id = Convert.ToInt32(datos.Lector("IDProducto")) Then
                seleccionado = producto
                Exit For
            End If
        Next

        Return seleccionado
    End Function

End Class
