Public Class Aleatorios
    ' Random
    Private rnd As Random

    Public Sub New()
        rnd = New Random()
    End Sub

    ' Método 1
    Public Function GenerarNumero(min As Integer, max As Integer) As Integer
        Return rnd.Next(min, max + 1)
    End Function

    ' Método 2
    Public Function GenerarArreglo(tamaño As Integer, min As Integer, max As Integer) As Integer()
        Dim arreglo(tamaño - 1) As Integer
        For i As Integer = 0 To tamaño - 1
            arreglo(i) = rnd.Next(min, max + 1)
        Next
        Return arreglo
    End Function
End Class

