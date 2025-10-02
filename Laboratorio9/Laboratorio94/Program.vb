Imports System

Module Module1
    Sub Main()
        Dim obj As New Aleatorios()


        Dim num As Integer = obj.GenerarNumero(10, 50)
        Console.WriteLine("Número aleatorio entre 10 y 50: " & num)


        Dim arreglo() As Integer = obj.GenerarArreglo(5, 1, 100)
        Console.WriteLine("Arreglo de 5 números aleatorios entre 1 y 100:")
        For Each n In arreglo
            Console.Write(n & " ")
        Next

        Console.WriteLine()
        Console.WriteLine("Presione cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module

