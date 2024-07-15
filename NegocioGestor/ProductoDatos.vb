Imports DominioGestor

Public Class ProductoDatos
    Public Function Listar() As List(Of Producto)

        ' Retorna una lista de todos los productos almacenados en la base de datos.
        ' No recibe parámetros.

        Dim productos As New List(Of Producto)()
        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("SELECT Id, Nombre, Precio, Categoria FROM productos")
            datos.ejecutarLectura()

            While datos.Lector.Read()
                Dim producto As New Producto()
                producto.Id = Convert.ToInt32(datos.Lector("Id"))
                producto.Nombre = datos.Lector("Nombre").ToString()
                producto.Precio = datos.Lector("Precio").ToString()
                producto.Categoria = datos.Lector("Categoria").ToString()
                productos.Add(producto)
            End While

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

        Return productos

    End Function

    Public Function Filtrar(campo As String, criterio As String, filtro As String) As List(Of Producto)

        ' Retorna una lista de productos filtrados según el campo, criterio y filtro especificados.
        ' Recibe tres parámetros: campo (String), criterio (String) y filtro (String).

        Dim lista As New List(Of Producto)()
        Dim datos As New AccesoDatos()

        Try
            Dim consulta As String = "Select ID, Nombre, Precio, Categoria From productos where "

            If campo = "ID" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "CAST(ID AS VARCHAR) like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "CAST(ID AS VARCHAR) like '%" & filtro & "'"
                    Case Else
                        consulta += "CAST(ID AS VARCHAR) like '%" & filtro & "%'"
                End Select
            ElseIf campo = "Nombre" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "Nombre like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "Nombre like '%" & filtro & "'"
                    Case Else
                        consulta += "Nombre like '%" & filtro & "%'"
                End Select
            ElseIf campo = "Categoria" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "Categoria like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "Categoria like '%" & filtro & "'"
                    Case Else
                        consulta += "Categoria like '%" & filtro & "%'"
                End Select
            Else
                Select Case criterio
                    Case "Igual a"
                        consulta += "Precio = " & filtro
                    Case "Mayor a"
                        consulta += "Precio > " & filtro
                    Case Else
                        consulta += "Precio < " & filtro
                End Select
            End If

            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()

                Dim aux As New Producto()
                aux.Id = Convert.ToInt32(datos.Lector("Id"))
                aux.Nombre = Convert.ToString(datos.Lector("Nombre"))
                aux.Categoria = Convert.ToString(datos.Lector("Categoria"))
                aux.Precio = Convert.ToString(datos.Lector("Precio"))

                lista.Add(aux)
            End While

            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub Agregar(nuevo As Producto)

        ' Inserta un nuevo producto en la base de datos.
        ' Recibe un parámetro de tipo Producto que representa al nuevo producto a agregar.

        Dim datos As New AccesoDatos()

        Try
            ' Configuración de la consulta SQL para insertar un nuevo cliente
            datos.setearConsulta("INSERT INTO productos (Nombre, Categoria, Precio) VALUES (@Nombre, @Categoria, @Precio);")
            datos.setearParametro("@Nombre", nuevo.Nombre)
            datos.setearParametro("@Categoria", nuevo.Categoria)
            datos.setearParametro("@Precio", nuevo.Precio)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Sub

    Public Sub Eliminar(id As Integer)

        ' Elimina un producto de la base de datos según su ID.
        ' Recibe un parámetro de tipo Integer que representa el ID del producto a eliminar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("DELETE FROM productos WHERE id = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Modificar(nuevo As Producto)

        ' Modifica los datos de un producto en la base de datos según su ID.
        ' Recibe un parámetro de tipo Producto que representa al producto con los datos modificados.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("UPDATE productos SET Nombre = @Nombre, Categoria = @Categoria, Precio = @Precio WHERE ID = @id")
            datos.setearParametro("@id", nuevo.Id)
            datos.setearParametro("@Nombre", nuevo.Nombre)
            datos.setearParametro("@Categoria", nuevo.Categoria)
            datos.setearParametro("@Precio", nuevo.Precio)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Sub

    Public Function listarPorId(id As String) As Producto

        ' Retorna un producto específico de la base de datos según su ID.
        ' Recibe un parámetro de tipo String que representa el ID del producto a buscar.

        Dim datos As New AccesoDatos()
        Dim seleccionado As New Producto()

        Try
            Dim consulta As String = "Select ID, Nombre, Categoria, Precio From productos where ID = '" & id & " '  "
            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()
                seleccionado.Id = Convert.ToInt32(datos.Lector("Id"))
                seleccionado.Nombre = datos.Lector("Nombre").ToString()
                seleccionado.Categoria = datos.Lector("Categoria").ToString()
                seleccionado.Precio = datos.Lector("Precio").ToString()

            End While

            datos.cerrarConexion()
            Return seleccionado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
