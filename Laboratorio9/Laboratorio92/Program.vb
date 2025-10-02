Imports System

Module Module1
    Sub Main()
        Console.WriteLine("Números pares o divisibles entre 3 del 1 al 100:")

        For i As Integer = 1 To 100
            If i Mod 2 = 0 Or i Mod 3 = 0 Then
                Console.WriteLine(i)
            End If
        Next

        Console.WriteLine("Presione cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module
