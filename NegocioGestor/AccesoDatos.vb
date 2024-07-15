Imports System.Data.SqlClient
Imports System.Configuration

Public Class AccesoDatos
    Private _conexion As SqlConnection
    Private _comando As SqlCommand
    Private _lector As SqlDataReader

    ' Propiedad de solo lectura para acceder al lector desde fuera de la clase
    Public ReadOnly Property Lector As SqlDataReader
        Get
            Return _lector
        End Get
    End Property

    ' Constructor de la clase AccesoDatos
    Public Sub New()
        _conexion = New SqlConnection(ConfigurationManager.AppSettings("cadenaConexion"))
        _comando = New SqlCommand()
    End Sub

    ' Establece la consulta SQL que se ejecutará y configura el tipo de comando como texto
    Public Sub setearConsulta(consulta As String)
        _comando.CommandType = System.Data.CommandType.Text
        _comando.CommandText = consulta
    End Sub

    ' Añade parámetros a la colección de parámetros del comando
    Public Sub setearParametro(nombreParametro As String, valor As Object)
        Dim parametro As New SqlParameter()
        parametro.ParameterName = nombreParametro
        parametro.Value = valor
        _comando.Parameters.Add(parametro)
    End Sub

    ' Ejecuta una lectura de datos y asigna el resultado al lector
    Public Sub ejecutarLectura()
        _comando.Connection = _conexion

        Try
            _conexion.Open()
            _lector = _comando.ExecuteReader()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' Ejecuta un comando que no devuelve datos
    Public Sub ejecutarAccion()
        _comando.Connection = _conexion
        Try
            _conexion.Open()
            _comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            _conexion.Close()
        End Try
    End Sub

    ' Ejecuta un comando que devuelve un valor escalar
    Public Function ejecutarAccionScalar() As Integer
        _comando.Connection = _conexion
        Try
            _conexion.Open()
            Return Integer.Parse(_comando.ExecuteScalar().ToString())
        Catch ex As Exception
            Throw ex
        Finally
            _conexion.Close()
        End Try
    End Function

    ' Cierra el lector de datos si está abierto y cierra la conexión a la base de datos
    Public Sub cerrarConexion()
        If lector IsNot Nothing Then
            lector.Close()
        End If
        _conexion.Close()
    End Sub
End Class
