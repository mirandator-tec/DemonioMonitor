Public Class DatosSensados
    Private pIDRegistro As Integer
    Private pRegistro As String
    Private Conn As New Conexion
    Public Property IdRegistro As Integer
        Get
            Return pIDRegistro
        End Get
        Set(value As Integer)
            pIDRegistro = value
        End Set
    End Property
    Public Property Registro As String
        Get
            Return pRegistro
        End Get
        Set(value As String)
            pRegistro = value
        End Set
    End Property

    Public Sub guardar()
        Conn.SQL = "Exec sp_AddUpdDatosSensados " & pIDRegistro & ",'" & pRegistro & "';"
        Conn.Ejecutar()

    End Sub

    Public Sub grid(dtgGrid As DataGridView)
        Conn.SQL = "Select * from DatosSensados Order by IdRegistro "
        Conn.Grid(dtgGrid)
    End Sub




End Class
