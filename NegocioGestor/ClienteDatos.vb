Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports DominioGestor


Public Class ClienteDatos

    Public Function Listar() As List(Of Cliente)

        ' Retorna una lista de todos los clientes almacenados en la base de datos.
        ' No recibe parámetros.

        Dim clientes As New List(Of Cliente)()
        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("SELECT Id, Cliente, Telefono, Correo FROM clientes")
            datos.ejecutarLectura()

            While datos.Lector.Read()
                Dim cliente As New Cliente()
                cliente.Id = Convert.ToInt32(datos.Lector("Id"))
                cliente.Nombre = datos.Lector("Cliente").ToString()
                cliente.Telefono = datos.Lector("Telefono").ToString()
                cliente.Correo = datos.Lector("Correo").ToString()
                clientes.Add(cliente)
            End While

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

        Return clientes

    End Function

    Public Sub Agregar(nuevo As Cliente)

        ' Inserta un nuevo cliente en la base de datos.
        ' Recibe un parámetro de tipo Cliente que representa al nuevo cliente a agregar.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo);")
            datos.setearParametro("@Nombre", nuevo.Nombre)
            datos.setearParametro("@Telefono", nuevo.Telefono)
            datos.setearParametro("@Correo", nuevo.Correo)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Sub

    Public Sub Eliminar(id As Integer)

        ' Elimina un cliente de la base de datos según su ID.
        ' Recibe un parámetro de tipo Integer que representa el ID del cliente a eliminar

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("DELETE FROM clientes WHERE id = @id")
            datos.setearParametro("@id", id)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Modificar(nuevo As Cliente)

        ' Modifica los datos de un cliente en la base de datos según su ID.
        ' Recibe un parámetro de tipo Cliente que representa al cliente con los datos modificados.

        Dim datos As New AccesoDatos()

        Try
            datos.setearConsulta("UPDATE CLIENTES SET Cliente = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID = @id")
            datos.setearParametro("@id", nuevo.Id)
            datos.setearParametro("@Nombre", nuevo.Nombre)
            datos.setearParametro("@Telefono", nuevo.Telefono)
            datos.setearParametro("@Correo", nuevo.Correo)
            datos.ejecutarAccion()

        Catch ex As Exception
            Throw ex
        Finally
            datos.cerrarConexion()
        End Try

    End Sub

    Public Function Filtrar(campo As String, criterio As String, filtro As String) As List(Of Cliente)

        ' Retorna una lista de clientes filtrados según el campo, criterio y filtro especificados.
        ' Recibe tres parámetros: campo (String), criterio (String) y filtro (String).

        Dim lista As New List(Of Cliente)()
        Dim datos As New AccesoDatos()

        Try
            Dim consulta As String = "Select ID, Cliente, Telefono, Correo From Clientes where "

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
                        consulta += "Cliente like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "Cliente like '%" & filtro & "'"
                    Case Else
                        consulta += "Cliente like '%" & filtro & "%'"
                End Select
            ElseIf campo = "Telefono" Then
                Select Case criterio
                    Case "Comienza con"
                        consulta += "Telefono like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "Telefono like '%" & filtro & "'"
                    Case Else
                        consulta += "Telefono like '%" & filtro & "%'"
                End Select
            Else
                Select Case criterio
                    Case "Comienza con"
                        consulta += "Correo like '" & filtro & "%' "
                    Case "Termina con"
                        consulta += "Correo like '%" & filtro & "'"
                    Case Else
                        consulta += "Correo like '%" & filtro & "%'"
                End Select
            End If

            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()

                Dim aux As New Cliente()
                aux.Id = Convert.ToInt32(datos.Lector("Id"))
                aux.Nombre = Convert.ToString(datos.Lector("Cliente"))
                aux.Telefono = Convert.ToString(datos.Lector("Telefono"))
                aux.Correo = Convert.ToString(datos.Lector("Correo"))

                lista.Add(aux)
            End While

            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarPorId(id As String) As Cliente

        ' Retorna un cliente específico de la base de datos según su ID.
        ' Recibe un parámetro de tipo String que representa el ID del cliente a buscar.

        Dim datos As New AccesoDatos()
        Dim seleccionado As New Cliente()

        Try
            Dim consulta As String = "Select ID, Cliente, Telefono, Correo From Clientes where ID = '" & id & " '  "
            datos.setearConsulta(consulta)
            datos.ejecutarLectura()

            While datos.Lector.Read()
                seleccionado.Id = Convert.ToInt32(datos.Lector("Id"))
                seleccionado.Nombre = datos.Lector("Cliente").ToString()
                seleccionado.Telefono = datos.Lector("Telefono").ToString()
                seleccionado.Correo = datos.Lector("Correo").ToString()

            End While

            datos.cerrarConexion()
            Return seleccionado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
