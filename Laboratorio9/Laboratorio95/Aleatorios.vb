Public Class Aleatorios

    Private rnd As Random

    Public Sub New()
        rnd = New Random()
    End Sub

    ' Método 1: Generar un número entre dos números
    Public Function GenerarNumero(min As Integer, max As Integer) As Integer
        Return rnd.Next(min, max + 1)
    End Function

    ' Método 2: 
    Public Function GenerarArreglo(tamaño As Integer, min As Integer, max As Integer) As Integer()
        Dim arreglo(tamaño - 1) As Integer
        For i As Integer = 0 To tamaño - 1
            arreglo(i) = rnd.Next(min, max + 1)
        Next
        Return arreglo
    End Function

    ' Método 3:
    Public Function GenerarArregloNoRepetido(tamaño As Integer, min As Integer, max As Integer) As Integer()

        If (max - min + 1) < tamaño Then
            Throw New ArgumentException("El rango es demasiado pequeño para generar números no repetidos.")
        End If

        Dim lista As New List(Of Integer)()
        While lista.Count < tamaño
            Dim num As Integer = rnd.Next(min, max + 1)
            If Not lista.Contains(num) Then
                lista.Add(num)
            End If
        End While

        Return lista.ToArray()
    End Function
End Class
