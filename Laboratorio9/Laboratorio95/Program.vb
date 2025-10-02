Module Module1
    Sub Main()
        Dim obj As New Aleatorios()

        ' Generar dos números aleatorios para los límites
        Dim min As Integer = obj.GenerarNumero(1, 30)
        Dim max As Integer = obj.GenerarNumero(min + 1, 50) ' aseguramos que max > min

        Console.WriteLine("Rango generado: " & min & " - " & max)

        ' Generar un arreglo de 5 números no repetidos dentro de ese rango
        Dim arreglo() As Integer = obj.GenerarArregloNoRepetido(5, min, max)

        Console.WriteLine("Arreglo de números aleatorios SIN repetidos:")
        For Each n In arreglo
            Console.Write(n & " ")
        Next

        Console.WriteLine()
        Console.WriteLine("Presione cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module
