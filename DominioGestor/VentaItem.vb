Public Class VentaItem
    Private _id As Integer
    Private _ventaAsociada As Venta
    Private _producto As Producto
    Private _precioUnitario As Decimal
    Private _cantidad As Integer
    Private _precioTotal As Decimal

    Public Sub New()
        _ventaAsociada = New Venta
        _producto = New Producto
    End Sub

    Public Sub New(ByVal ventaAsociada As Venta, ByVal producto As Producto, ByVal precioUnitario As Decimal, ByVal cantidad As Integer)
        _ventaAsociada = ventaAsociada
        _producto = producto
        _precioUnitario = precioUnitario
        _cantidad = cantidad
        _precioTotal = precioUnitario * cantidad
    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property VentaAsociada() As Venta
        Get
            Return _ventaAsociada
        End Get
        Set(ByVal value As Venta)
            _ventaAsociada = value
        End Set
    End Property

    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property

    Public Property PrecioUnitario() As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Decimal)
            _precioUnitario = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property PrecioTotal() As Decimal
        Get
            Return _precioTotal
        End Get
        Set(ByVal value As Decimal)
            _precioTotal = value
        End Set
    End Property

    Public Sub CalcularTotal()
        _precioTotal = PrecioUnitario * Cantidad
    End Sub
End Class
