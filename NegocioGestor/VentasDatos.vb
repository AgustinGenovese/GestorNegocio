Imports DominioGestor

Public Class VentasDatos
    Public Function Listar() As List(Of Venta)

        ' Retorna una lista de todas las ventas almacenadas en la base de datos, incluyendo el cliente asociado a cada venta.
        ' No recibe parámetros.

        Dim datos As New AccesoDatos()
        Dim datosCliente As New ClienteDatos()
        Dim ventas As New List(Of Venta)()

        Try
            datos.setearConsulta("SELECT ID, IDCliente, Fecha, Total FROM ventas")
            datos.ejecutarLectura()

            While datos.Lector.Read()
                Dim venta As New Venta()
                venta.Id = Convert.ToInt32(datos.Lector("Id"))
                venta.Cliente = ObtenerCliente(datos, datosCliente, venta)
                venta.Fecha = Convert.ToDateTime(datos.Lector("Fecha"))
                venta.Total = Convert.ToDecimal(datos.Lector("Total"))
                ventas.Add(venta)
            End While

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

        Return ventas

    End Function

    Public Function listarPorId(id As String) As Venta

        ' Retorna una venta específica de la base de datos según su ID, incluyendo el cliente asociado a la venta.
        ' Recibe un parámetro de tipo String que representa el ID de la venta a buscar.

        Dim datos As New AccesoDatos()
        Dim datosCliente As New ClienteDatos()
        Dim seleccionado As New Venta()

        Try
            Dim consulta As String = "Select ID, IDCliente, Fecha, Total From ventas where ID = '" & id & " '  "
            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()
                seleccionado.Id = Convert.ToInt32(datos.Lector("Id"))
                seleccionado.Cliente = ObtenerCliente(datos, datosCliente, seleccionado)
                seleccionado.Fecha = Convert.ToDateTime(datos.Lector("Fecha"))
                seleccionado.Total = Convert.ToDecimal(datos.Lector("Total"))

            End While

            datos.cerrarConexion()
            Return seleccionado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerCliente(datos As AccesoDatos, datosCliente As ClienteDatos, venta As Venta) As Cliente

        ' Obtiene el cliente asociado a una venta específica.
        ' Recibe tres parámetros: datos (AccesoDatos), datosCliente (ClienteDatos), venta (Venta).
        ' Retorna un objeto de tipo Cliente que representa al cliente asociado a la venta.

        Dim listaClientes As List(Of Cliente) = datosCliente.Listar()
        Dim seleccionado As Cliente = Nothing

        For Each cliente As Cliente In listaClientes
            If cliente.Id = Convert.ToInt32(datos.Lector("IDCliente")) Then
                seleccionado = cliente
                Exit For
            End If
        Next

        Return seleccionado
    End Function

    Public Function Filtrar(campo As String, criterio As String, filtro As String) As List(Of Venta)

        ' Retorna una lista de ventas filtradas según el campo, criterio y filtro especificados, incluyendo el nombre del cliente asociado.
        ' Recibe tres parámetros: campo (String), criterio (String) y filtro (String).

        Dim listaVentasFiltrada As New List(Of Venta)()
        Dim datos As New AccesoDatos()

        Try
            Dim consulta As String = "Select v.ID, v.IDCliente, v.Fecha, v.Total, c.Id, c.Cliente From ventas v, clientes c where v.IDCliente = c.ID And "

            If campo = "ID" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "CAST(v.ID AS VARCHAR) like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "CAST(v.ID AS VARCHAR) like '%" & filtro & "'"
                    Case Else
                        consulta += "CAST(v.ID AS VARCHAR) like '%" & filtro & "%'"
                End Select
            ElseIf campo = "Cliente" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "c.Cliente like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "c.Cliente like '%" & filtro & "'"
                    Case Else
                        consulta += "c.Cliente like '%" & filtro & "%'"
                End Select
            Else
                filtro = filtro.Replace(",", ".")
                Select Case criterio
                    Case "Igual a"
                        consulta += "Total = " & filtro
                    Case "Mayor a"
                        consulta += "Total > " & filtro
                    Case Else
                        consulta += "Total < " & filtro
                End Select
            End If

            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()

                Dim aux As New Venta()
                aux.Id = Convert.ToInt32(datos.Lector("ID"))

                Dim auxCliente As New Cliente
                auxCliente.Nombre = datos.Lector("Cliente")
                aux.Cliente = auxCliente
                aux.Fecha = Convert.ToDateTime(datos.Lector("Fecha"))

                aux.Total = Convert.ToDecimal(datos.Lector("Total"))

                listaVentasFiltrada.Add(aux)
            End While

            Return listaVentasFiltrada
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function FiltrarPorFecha(fecha As DateTime)

        ' Retorna una lista de ventas filtradas según la fecha especificada, incluyendo el nombre del cliente asociado.
        ' Recibe un parámetro de tipo DateTime que representa la fecha a filtrar.

        Dim fechaFormateada As String = fecha.ToString("yyyy-MM-dd")
        Dim listaVentasFiltrada As New List(Of Venta)()
        Dim datos As New AccesoDatos()

        Try
            Dim consulta As String = "Select v.ID, v.IDCliente, v.Fecha, v.Total, c.Id, c.Cliente From ventas v, clientes c where v.IDCliente = c.ID and CONVERT(date, v.Fecha) = '" & fechaFormateada & "' "

            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()

                Dim aux As New Venta()
                aux.Id = Convert.ToInt32(datos.Lector("ID"))

                Dim auxCliente As New Cliente
                auxCliente.Nombre = datos.Lector("Cliente")
                aux.Cliente = auxCliente
                aux.Fecha = Convert.ToDateTime(datos.Lector("Fecha"))
                aux.Total = Convert.ToDecimal(datos.Lector("Total"))

                listaVentasFiltrada.Add(aux)
            End While

            Return listaVentasFiltrada
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub Eliminar(id As Integer)

        ' Elimina una venta específica según su ID.
        ' Recibe como parámetro el ID de la venta a eliminar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("DELETE FROM ventas WHERE id = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Agregar(nuevo As Venta)

        ' Agrega una nueva venta a la base de datos.
        ' Recibe como parámetro un objeto de tipo Venta que contiene los datos de la nueva venta a agregar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("INSERT INTO ventas (IDCliente, Fecha, Total) VALUES (@IDCliente, @Fecha, @Total);")
            datos.setearParametro("@IDCliente", nuevo.Cliente.Id)
            datos.setearParametro("@Fecha", nuevo.Fecha)
            datos.setearParametro("@Total", nuevo.Total)
            datos.ejecutarAccion()
        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try
    End Sub

End Class


