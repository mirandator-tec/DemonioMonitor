Imports System.IO



Public Class Form1
    Dim fs As StreamReader
    Dim myBuffer As String
    Dim Ds As New DatosSensados
    Dim ultimo As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = ""
        lblReloj.Text = Now.TimeOfDay.ToString
        Dim myArreglo() As String
        fs = New StreamReader("C:\Ejemplo\20220905.CHK")
        myBuffer = fs.ReadToEnd
        myArreglo = Split(myBuffer, vbCr)
        Label1.Text = myBuffer
        Dim i As Integer

        For i = ultimo To UBound(myArreglo) - 1
            Ds.Registro = myArreglo(i)
            Ds.guardar()
            Application.DoEvents()

        Next
        If ultimo <> UBound(myArreglo) Then
            Ds.grid(dtgSensados)
        End If


        ultimo = i
        fs.Close()


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ultimo = 0
        Label1.Text = ""
        Ds.grid(dtgSensados)
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        dtgSensados.Height = Me.Height - 200
    End Sub
End Class
