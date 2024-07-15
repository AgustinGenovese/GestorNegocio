Public Class Venta
    Private _id As Integer
    Private _cliente As Cliente
    Private _fecha As DateTime
    Private _total As Decimal
    Private _items As List(Of VentaItem)

    ' TEMPORAL
    Public Sub New()
        _items = New List(Of VentaItem)()
        _total = CalcularTotal()

    End Sub

    Public Sub New(id As Integer, cliente As Cliente, fecha As DateTime, items As List(Of VentaItem))

        _id = id
        _cliente = cliente
        _fecha = fecha
        _items = items
        _total = CalcularTotal()

    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Cliente() As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Public Property Items() As List(Of VentaItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of VentaItem))
            _items = value
        End Set
    End Property

    Public Function CalcularTotal() As Decimal
        Dim totalVenta As Decimal = 0

        If _items IsNot Nothing Then
            For Each item As VentaItem In _items
                totalVenta += item.PrecioTotal
            Next
        End If

        _total = totalVenta
        Return _total
    End Function

End Class
