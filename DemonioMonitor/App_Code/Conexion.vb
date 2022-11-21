Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data

Imports Microsoft.VisualBasic

Public Class Conexion

    Private pServidor As String = "."
    Private pUsuario As String = "sa"
    Private pBase As String = "PruebaDemonio"
    Private pPassword As String = "123456"

    Private pConnString As String = "UID=" & pUsuario & "; Pwd=" & pPassword & "; Data Source=" & pServidor & "; Initial Catalog=" & pBase
    Private pSQL As String
    Private pVacia As Boolean


    Private pConeccion As New SqlConnection
    Private pCmd As New SqlCommand
    Private pAdapter As New SqlDataAdapter
    Private pDataset As New DataSet

    Public Property SQL As String
        Get
            Return pSQL
        End Get
        Set(value As String)
            pSQL = value
        End Set
    End Property

    Public Property Vacia As Boolean
        Get
            Return pVacia
        End Get
        Set(value As Boolean)
            pVacia = value
        End Set
    End Property

    Public Property Tabla As DataSet
        Get
            Return pDataset
        End Get
        Set(value As DataSet)
            pDataset = value
        End Set
    End Property


    Public Sub Ejecutar()
        Try
            pConeccion = New SqlConnection(pConnString)
            pCmd = New SqlCommand(pSQL, pConeccion)
            pCmd.Connection.Open()
            pCmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Public Sub Grid(dtgGrid As DataGridView)
        pConeccion = New SqlConnection(pConnString)
        pCmd = New SqlCommand(pSQL, pConeccion)
        pAdapter = New SqlDataAdapter(pCmd)
        pAdapter.Fill(pDataset)

        dtgGrid.DataSource = pDataset.Tables(0).DefaultView
        dtgGrid.Refresh()

        pConeccion.Close()
        pDataset.Tables.Clear()
        pAdapter.Dispose()

    End Sub

    Public Sub Llenar()
        pConeccion = New SqlConnection(pConnString)
        pCmd = New SqlCommand(pSQL, pConeccion)
        pAdapter = New SqlDataAdapter(pCmd)
        pAdapter.Fill(pDataset)


    End Sub

    Public Function VariableNombre(Campo As String) As String

        Return pDataset.Tables(0).Rows(0).Item(Campo).ToString
    End Function
End Class
