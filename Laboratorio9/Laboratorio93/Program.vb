Imports System

Module Module1
    Sub Main()
        Dim a, b, c As Double

        ' Ingreso de datos
        Console.Write("Ingrese el lado A: ")
        a = Val(Console.ReadLine())

        Console.Write("Ingrese el lado B: ")
        b = Val(Console.ReadLine())

        Console.Write("Ingrese el lado C: ")
        c = Val(Console.ReadLine())

        ' Validar si se puede formar un triángulo
        If (a + b > c) And (a + c > b) And (b + c > a) Then
            ' Clasificación
            If a = b And b = c Then
                Console.WriteLine("El triángulo es Equilátero.")
            ElseIf a = b Or a = c Or b = c Then
                Console.WriteLine("El triángulo es Isósceles.")
            Else
                Console.WriteLine("El triángulo es Escaleno.")
            End If
        Else
            Console.WriteLine("Los valores no forman un triángulo válido.")
        End If

        Console.WriteLine("Presione cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module
