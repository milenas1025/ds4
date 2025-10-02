Imports System

Module Module1
    Sub Main()
        Dim precio As Double
        Dim formaPago As String
        Dim numeroCuenta As String

        ' Pedir precio positivo
        Do
            Console.Write("Ingrese el precio del producto (valor positivo): ")
            precio = Val(Console.ReadLine())
            If precio <= 0 Then
                Console.WriteLine("El precio debe ser un valor positivo.")
            End If
        Loop While precio <= 0

        ' Pedir forma de pago
        Do
            Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ")
            formaPago = Console.ReadLine().ToLower()
            If formaPago <> "efectivo" And formaPago <> "tarjeta" Then
                Console.WriteLine("Forma de pago inválida. Intente nuevamente.")
            End If
        Loop While formaPago <> "efectivo" And formaPago <> "tarjeta"

        ' Si es tarjeta, pedir número de cuenta
        If formaPago = "tarjeta" Then
            Do
                Console.Write("Ingrese el número de cuenta (16 dígitos): ")
                numeroCuenta = Console.ReadLine()
                If numeroCuenta.Length <> 16 Or Not IsNumeric(numeroCuenta) Then
                    Console.WriteLine("Número de cuenta inválido. Debe tener 16 dígitos numéricos.")
                End If
            Loop While numeroCuenta.Length <> 16 Or Not IsNumeric(numeroCuenta)
        End If

        '  Resumen
        Console.WriteLine(vbCrLf & "--- Resumen ---")
        Console.WriteLine("Precio: " & precio)
        Console.WriteLine("Forma de pago: " & formaPago)
        If formaPago = "tarjeta" Then
            Console.WriteLine("Número de cuenta: " & numeroCuenta)
        End If

        Console.WriteLine("Presione cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module
